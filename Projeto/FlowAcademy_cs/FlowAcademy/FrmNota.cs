using System;
using System.Windows.Forms;
using FlowAcademyClasses;

namespace FlowAcademyF
{
    public partial class FrmNota : Form
    {
        private int idSelecionado = 0;

        public FrmNota()
        {
            InitializeComponent();
        }

        // ==========================
        // LOAD
        // ==========================
        private void FrmNota_Load(object sender, EventArgs e)
        {
            CarregarCombos();
            CarregarGrid();
            LimparFormulario();

            txtMedia.ReadOnly = true;
            txtStatus.ReadOnly = true;
        }

        // ==========================
        // GRID
        // ==========================
        private void CarregarGrid()
        {
            dgvNota.DataSource = Nota.ObterLista(txtPesquisa.Text.Trim());
        }

        // ==========================
        // COMBOS
        // ==========================
        private void CarregarCombos()
        {
            cmbMatricula.DataSource = Matricula.ObterLista();
            cmbMatricula.DisplayMember = "IdMatricula";
            cmbMatricula.ValueMember = "IdMatricula";
            cmbMatricula.SelectedIndex = -1;

            cmbDisciplina.DataSource = Disciplina.ObterLista();
            cmbDisciplina.DisplayMember = "Nome";
            cmbDisciplina.ValueMember = "IdDisciplina";
            cmbDisciplina.SelectedIndex = -1;
        }

        // ==========================
        // LIMPAR
        // ==========================
        private void LimparFormulario()
        {
            cmbMatricula.SelectedIndex = -1;
            cmbDisciplina.SelectedIndex = -1;

            txtNota1.Clear();
            txtNota2.Clear();
            txtTrabalho.Clear();
            txtComportamento.Clear();
            txtMedia.Clear();
            txtStatus.Clear();
            txtPesquisa.Clear();

            dtpData.Value = DateTime.Now;

            dgvNota.ClearSelection();

            idSelecionado = 0;
        }

        // ==========================
        // VALIDAR
        // ==========================
        private bool ValidarCampos()
        {
            if (cmbMatricula.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma matrícula.");
                return false;
            }

            if (cmbDisciplina.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma disciplina.");
                return false;
            }

            if (!NotaValida(txtNota1.Text)) return false;
            if (!NotaValida(txtNota2.Text)) return false;
            if (!NotaValida(txtTrabalho.Text)) return false;
            if (!NotaValida(txtComportamento.Text)) return false;

            return true;
        }

        private bool NotaValida(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return true;

            decimal valor;

            if (!decimal.TryParse(texto, out valor))
            {
                MessageBox.Show("Informe notas válidas.");
                return false;
            }

            if (valor < 0 || valor > 10)
            {
                MessageBox.Show("As notas devem estar entre 0 e 10.");
                return false;
            }

            return true;
        }

        // ==========================
        // CALCULAR MÉDIA (TELA)
        // ==========================
        private void CalcularMediaTela()
        {
            decimal p1 = 0, p2 = 0, t = 0, c = 0;

            decimal.TryParse(txtNota1.Text, out p1);
            decimal.TryParse(txtNota2.Text, out p2);
            decimal.TryParse(txtTrabalho.Text, out t);
            decimal.TryParse(txtComportamento.Text, out c);

            decimal media = (p1 * 0.3m) + (p2 * 0.3m) + (t * 0.3m) + (c * 0.1m);

            txtMedia.Text = media.ToString("0.00");

            if (!string.IsNullOrWhiteSpace(txtNota1.Text) &&
                !string.IsNullOrWhiteSpace(txtNota2.Text) &&
                !string.IsNullOrWhiteSpace(txtTrabalho.Text) &&
                !string.IsNullOrWhiteSpace(txtComportamento.Text))
            {
                txtStatus.Text = media >= 6 ? "aprovado" : "reprovado";
            }
            else
            {
                txtStatus.Text = "em_andamento";
            }
        }

        // ==========================
        // EVENTOS AUTOMÁTICOS
        // ==========================
        private void txtNota1_TextChanged(object sender, EventArgs e)
        {
            CalcularMediaTela();
        }

        private void txtNota2_TextChanged(object sender, EventArgs e)
        {
            CalcularMediaTela();
        }

        private void txtTrabalho_TextChanged(object sender, EventArgs e)
        {
            CalcularMediaTela();
        }

        private void txtComportamento_TextChanged(object sender, EventArgs e)
        {
            CalcularMediaTela();
        }

        // ==========================
        // PREENCHER FORM
        // ==========================
        private void PreencherFormulario(Nota nota)
        {
            if (nota == null) return;

            idSelecionado = nota.IdNota;

            cmbMatricula.SelectedValue = nota.IdMatricula;
            cmbDisciplina.SelectedValue = nota.IdDisciplina;

            txtNota1.Text = nota.Prova1?.ToString();
            txtNota2.Text = nota.Prova2?.ToString();
            txtTrabalho.Text = nota.Trabalho?.ToString();
            txtComportamento.Text = nota.Comportamental?.ToString();
            txtMedia.Text = nota.MediaUc?.ToString();
            txtStatus.Text = nota.Status;

            dtpData.Value = nota.DataLancamento;
        }

        // ==========================
        // SALVAR
        // ==========================
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (idSelecionado > 0)
            {
                AtualizarRegistro();
                return;
            }

            if (!ValidarCampos()) return;

            Nota nota = new Nota();

            nota.IdMatricula = Convert.ToInt32(cmbMatricula.SelectedValue);
            nota.IdDisciplina = Convert.ToInt32(cmbDisciplina.SelectedValue);

            decimal valor;

            if (decimal.TryParse(txtNota1.Text, out valor))
                nota.Prova1 = valor;

            if (decimal.TryParse(txtNota2.Text, out valor))
                nota.Prova2 = valor;

            if (decimal.TryParse(txtTrabalho.Text, out valor))
                nota.Trabalho = valor;

            if (decimal.TryParse(txtComportamento.Text, out valor))
                nota.Comportamental = valor;

            nota.DataLancamento = dtpData.Value;

            if (nota.Inserir())
            {
                MessageBox.Show("Nota cadastrada com sucesso!");
                CarregarGrid();
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar nota.");
            }
        }

        // ==========================
        // EDITAR
        // ==========================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvNota.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro.");
                return;
            }

            int id = Convert.ToInt32(dgvNota.CurrentRow.Cells[0].Value);

            Nota nota = Nota.ObterPorId(id);

            PreencherFormulario(nota);
        }

        // ==========================
        // ATUALIZAR
        // ==========================
        private void AtualizarRegistro()
        {
            if (idSelecionado <= 0) return;

            if (!ValidarCampos()) return;

            Nota nota = new Nota();

            nota.IdNota = idSelecionado;
            nota.IdMatricula = Convert.ToInt32(cmbMatricula.SelectedValue);
            nota.IdDisciplina = Convert.ToInt32(cmbDisciplina.SelectedValue);

            decimal valor;

            if (decimal.TryParse(txtNota1.Text, out valor))
                nota.Prova1 = valor;

            if (decimal.TryParse(txtNota2.Text, out valor))
                nota.Prova2 = valor;

            if (decimal.TryParse(txtTrabalho.Text, out valor))
                nota.Trabalho = valor;

            if (decimal.TryParse(txtComportamento.Text, out valor))
                nota.Comportamental = valor;

            nota.DataLancamento = dtpData.Value;

            if (nota.Atualizar())
            {
                MessageBox.Show("Nota atualizada com sucesso!");
                CarregarGrid();
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Erro ao atualizar nota.");
            }
        }

        // ==========================
        // EXCLUIR
        // ==========================
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idSelecionado == 0 && dgvNota.CurrentRow != null)
            {
                idSelecionado = Convert.ToInt32(dgvNota.CurrentRow.Cells[0].Value);
            }

            if (dgvNota.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro.");
                return;
            }

            var confirmacao = MessageBox.Show(
                "Deseja realmente excluir esta nota?",
                "Confirmação",
                MessageBoxButtons.YesNo
            );

            if (confirmacao != DialogResult.Yes)
                return;

            Nota nota = new Nota();
            nota.IdNota = idSelecionado;

            if (nota.Excluir())
            {
                MessageBox.Show("Nota excluída com sucesso!");
                CarregarGrid();
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Erro ao excluir nota.");
            }
        }

        // ==========================
        // CANCELAR
        // ==========================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        // ==========================
        // DUPLO CLIQUE
        // ==========================
        private void dgvNota_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar_Click(sender, e);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            CalcularMediaTela();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }
    }
}
