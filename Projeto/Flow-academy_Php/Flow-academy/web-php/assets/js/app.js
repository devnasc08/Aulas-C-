document.addEventListener('DOMContentLoaded', () => {
  // Este arquivo cuida dos comportamentos visuais que nao precisam consultar o banco.
  const body = document.body;
  const toast = document.querySelector('[data-toast-root]');
  let toastTimer;

  function showToast(message) {
    // Mostra uma mensagem temporaria no canto da tela.
    if (!toast) return;
    toast.textContent = message || 'Acao concluida.';
    toast.classList.add('show');
    clearTimeout(toastTimer);
    toastTimer = setTimeout(() => toast.classList.remove('show'), 2600);
  }

  // Abre o menu lateral em telas pequenas.
  document.querySelectorAll('.js-sidebar-toggle').forEach((button) => {
    button.addEventListener('click', () => body.classList.toggle('sidebar-open'));
  });

  // Fecha o menu lateral quando o usuario clica no fundo escuro.
  document.querySelectorAll('.js-sidebar-close').forEach((button) => {
    button.addEventListener('click', () => body.classList.remove('sidebar-open'));
  });

  // Alterna senha entre visivel e escondida no login/cadastros.
  document.querySelectorAll('[data-password-toggle]').forEach((button) => {
    button.addEventListener('click', () => {
      const input = document.querySelector(button.getAttribute('data-password-toggle'));
      if (!input) return;
      input.type = input.type === 'password' ? 'text' : 'password';
      button.textContent = input.type === 'password' ? 'Mostrar' : 'Ocultar';
    });
  });

  function onlyDigits(value) {
    // Remove tudo que nao for numero, usado nas mascaras.
    return value.replace(/\D/g, '');
  }

  function maskCpf(value) {
    // Aplica formato 000.000.000-00 enquanto o usuario digita.
    return onlyDigits(value).slice(0, 11)
      .replace(/(\d{3})(\d)/, '$1.$2')
      .replace(/(\d{3})(\d)/, '$1.$2')
      .replace(/(\d{3})(\d{1,2})$/, '$1-$2');
  }

  function maskPhone(value) {
    // Aplica formato de telefone fixo ou celular conforme quantidade de digitos.
    const digits = onlyDigits(value).slice(0, 11);
    if (digits.length <= 10) {
      return digits.replace(/(\d{2})(\d)/, '($1) $2').replace(/(\d{4})(\d)/, '$1-$2');
    }
    return digits.replace(/(\d{2})(\d)/, '($1) $2').replace(/(\d{5})(\d)/, '$1-$2');
  }

  // Ativa mascaras nos inputs marcados com data-mask="cpf" ou data-mask="phone".
  document.querySelectorAll('[data-mask]').forEach((input) => {
    input.addEventListener('input', () => {
      input.value = input.getAttribute('data-mask') === 'cpf' ? maskCpf(input.value) : maskPhone(input.value);
    });
  });

  // Permite adicionar ou remover linhas de Unidade Curricular no formulario de curso.
  document.querySelectorAll('[data-uc-editor]').forEach((editor) => {
    const list = editor.querySelector('[data-uc-list]');
    const template = document.querySelector(editor.getAttribute('data-uc-template'));
    const addButton = editor.querySelector('[data-add-uc]');

    if (!list || !template || !addButton) return;

    addButton.addEventListener('click', () => {
      // Clona o modelo HTML para manter os mesmos campos e nomes de formulario.
      const fragment = template.content.cloneNode(true);
      list.appendChild(fragment);
      const lastInput = list.querySelector('[data-uc-row]:last-child input');
      if (lastInput) lastInput.focus();
    });

    list.addEventListener('click', (event) => {
      const button = event.target.closest('[data-remove-uc]');
      if (!button) return;

      const row = button.closest('[data-uc-row]');
      const rows = list.querySelectorAll('[data-uc-row]');
      if (!row) return;

      // Mantem uma linha vazia para o usuario conseguir cadastrar a primeira UC.
      if (rows.length === 1) {
        row.querySelectorAll('input').forEach((input) => { input.value = ''; });
        return;
      }

      row.remove();
    });
  });

  function normalizeSearch(value) {
    // Normaliza texto para buscas sem diferenciar maiusculas ou acentos.
    return String(value || '').toLowerCase().normalize('NFD').replace(/[\u0300-\u036f]/g, '');
  }

  function applyTurmaFilter(turmaSelect) {
    // Filtra selects dependentes usando o id da turma escolhida.
    const turmaId = turmaSelect.value;
    const selectors = [
      turmaSelect.getAttribute('data-filter-students'),
      turmaSelect.getAttribute('data-filter-ucs'),
    ].filter(Boolean);

    selectors.forEach((selector) => {
      const select = document.querySelector(selector);
      if (!select) return;

      Array.from(select.options).forEach((option) => {
        if (!option.value) {
          option.hidden = false;
          option.disabled = false;
          return;
        }

        // O PHP coloca data-turma em cada option; aqui mostramos so a turma escolhida.
        const blockedBySearch = option.dataset.searchHidden === '1';
        const visible = turmaId !== '' && option.dataset.turma === turmaId && !blockedBySearch;
        option.hidden = !visible;
        option.disabled = !visible;
      });

      const selected = select.selectedOptions[0];
      if (!turmaId || (selected && selected.value && selected.dataset.turma !== turmaId)) {
        select.value = '';
      }
    });
  }

  function applyStudentSearch(input) {
    // Filtra o select de alunos por nome ou matricula digitada.
    const select = document.querySelector(input.getAttribute('data-student-search'));
    if (!select) return;

    const query = normalizeSearch(input.value);
    Array.from(select.options).forEach((option) => {
      if (!option.value) return;
      const searchable = normalizeSearch((option.dataset.search || '') + ' ' + option.textContent);
      option.dataset.searchHidden = query && !searchable.includes(query) ? '1' : '0';
    });

    const turmaSelect = document.querySelector(input.getAttribute('data-turma-source'));
    if (turmaSelect) applyTurmaFilter(turmaSelect);
  }

  // Conecta cada select de turma aos selects de alunos/UCs informados por data-*.
  document.querySelectorAll('[data-turma-filter]').forEach((select) => {
    select.addEventListener('change', () => applyTurmaFilter(select));
    applyTurmaFilter(select);
  });

  // Ativa o campo de busca de aluno nas telas financeiras.
  document.querySelectorAll('[data-student-search]').forEach((input) => {
    input.addEventListener('input', () => applyStudentSearch(input));
    applyStudentSearch(input);
  });

  // Busca geral da topbar: filtra linhas da tabela principal da pagina.
  document.querySelectorAll('[data-table-filter]').forEach((input) => {
    const table = document.querySelector(input.getAttribute('data-table-filter'));
    if (!table) return;

    const rows = table.querySelectorAll('tbody tr');
    const applyFilter = () => {
      const query = normalizeSearch(input.value);
      rows.forEach((row) => {
        row.style.display = normalizeSearch(row.textContent).includes(query) ? '' : 'none';
      });
    };

    input.addEventListener('input', applyFilter);
  });

  // Barras de progresso, se alguma pagina usar data-progress.
  document.querySelectorAll('[data-progress]').forEach((bar) => {
    const value = Math.max(0, Math.min(100, Number(bar.getAttribute('data-progress')) || 0));
    requestAnimationFrame(() => {
      const fill = bar.querySelector('span');
      if (fill) fill.style.width = value + '%';
    });
  });

  // Botoes com data-toast mostram mensagem rapida.
  document.querySelectorAll('[data-toast]').forEach((button) => {
    button.addEventListener('click', () => showToast(button.getAttribute('data-toast')));
  });

  // Botoes com data-print chamam a impressao do navegador.
  document.querySelectorAll('[data-print]').forEach((button) => {
    button.addEventListener('click', () => window.print());
  });
});
