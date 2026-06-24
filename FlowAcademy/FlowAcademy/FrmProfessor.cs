using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FlowAcademyClasses;

namespace FlowAcademyF
{
    public partial class FrmProfessor : Form
    {
        private int idSelecionado = 0;

        public FrmProfessor()
        {
            InitializeComponent();
        }

        private void FrmProfessor_Load(object sender, EventArgs e)
        {
            CarregarCombos();
            CarregarGrid();
            LimparFormulario();
        }

        // ==========================
        // CARREGAR GRID
        // ==========================
        private void CarregarGrid()
        {
            dgvProfessores.DataSource = Professor.ObterLista();
        }

        // ==========================
        // CARREGAR COMBOS
        // ==========================
        private void CarregarCombos()
        {
            cmbUsuario.DataSource = Usuario.ObterLista();
            cmbUsuario.DisplayMember = "Nome";
            cmbUsuario.ValueMember = "IdUsuario";
            cmbUsuario.SelectedIndex = -1;
        }

        // ==========================
        // LIMPAR FORMULÁRIO
        // ==========================
        private void LimparFormulario()
        {
            txtCpf.Clear();
            txtEspecialidade.Clear();
            cmbUsuario.SelectedIndex = -1;

            dgvProfessores.ClearSelection();

            idSelecionado = 0;
        }

        // ==========================
        // VALIDAR CAMPOS
        // ==========================
        private bool ValidarCampos()
        {
            if (cmbUsuario.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um usuário.");
                return false;
            }

            string cpfLimpo = SomenteNumeros(txtCpf.Text);

            if (string.IsNullOrWhiteSpace(cpfLimpo))
            {
                MessageBox.Show("Informe o CPF.");
                return false;
            }

            if (!ValidarCpf(cpfLimpo))
            {
                MessageBox.Show("CPF inválido.");
                return false;
            }

            return true;
        }


        // ==========================
        // PREENCHER FORMULÁRIO
        // ==========================
        private void PreencherFormulario(Professor prof)
        {
            if (prof == null) return;

            idSelecionado = prof.IdProfessor;

            txtCpf.Text = prof.Cpf;
            txtEspecialidade.Text = prof.Especialidade;

            cmbUsuario.SelectedValue = prof.IdUsuario;
        }

        // ==========================
        // SALVAR (INSERIR)
        // ==========================
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Professor professor = new Professor();

            professor.IdUsuario = Convert.ToInt32(cmbUsuario.SelectedValue);
            professor.Cpf = SomenteNumeros(txtCpf.Text);
            professor.Especialidade = txtEspecialidade.Text;

            if (professor.Inserir())
            {
                MessageBox.Show("Professor cadastrado com sucesso!");
                CarregarGrid();
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar professor.");
            }
        }

        // ==========================
        // EDITAR
        // ==========================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProfessores.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro.");
                return;
            }

            int id = Convert.ToInt32(dgvProfessores.CurrentRow.Cells[0].Value);

            Professor prof = Professor.ObterPorId(id);

            PreencherFormulario(prof);
        }

        // ==========================
        // ATUALIZAR
        // ==========================
        private void AtualizarRegistro()
        {
            if (idSelecionado <= 0)
                return;

            if (!ValidarCampos())
                return;

            Professor professor = new Professor();

            professor.IdProfessor = idSelecionado;
            professor.Cpf = SomenteNumeros(txtCpf.Text);
            professor.Especialidade = txtEspecialidade.Text;

            if (professor.Atualizar())
            {
                MessageBox.Show("Professor atualizado com sucesso!");
                CarregarGrid();
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Erro ao atualizar professor.");
            }
        }

        // ==========================
        // EXCLUIR
        // ==========================
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvProfessores.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro.");
                return;
            }

            int id = Convert.ToInt32(dgvProfessores.CurrentRow.Cells[0].Value);

            var confirm = MessageBox.Show(
                "Deseja realmente excluir este professor?",
                "Confirmação",
                MessageBoxButtons.YesNo
            );

            if (confirm != DialogResult.Yes)
                return;

            Professor professor = new Professor();
            professor.IdProfessor = id;

            if (professor.Excluir())
            {
                MessageBox.Show("Professor excluído com sucesso!");
                CarregarGrid();
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Erro ao excluir professor.");
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
        // DUPLO CLIQUE NO GRID (EDITAR)
        // ==========================
        private void dgvProfessores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar_Click(sender, e);
        }

        private string SomenteNumeros(string valor)
        {
            return new string(valor.Where(char.IsDigit).ToArray());
        }

        private bool ValidarCpf(string cpf)
        {
            cpf = SomenteNumeros(cpf);

            if (cpf.Length != 11)
                return false;

            // Bloqueia CPFs inválidos conhecidos
            if (cpf.All(c => c == cpf[0]))
                return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();

            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {

        }
    }
}