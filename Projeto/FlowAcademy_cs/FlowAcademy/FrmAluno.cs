using System;
using System.Windows.Forms;
using FlowAcademyClasses;

namespace FlowAcademy
{
    public partial class FrmAluno : Form
    {
        int idSelecionado = 0;

        public FrmAluno()
        {
            InitializeComponent();
        }

        // ==========================
        // LOAD
        // ==========================
        private void FrmAluno_Load(object sender, EventArgs e)
        {
            CarregarCombos();
            CarregarGrid();
            LimparFormulario();
        }

        // ==========================
        // GRID
        // ==========================
        private void CarregarGrid()
        {
            dgvAluno.DataSource = null;
            dgvAluno.DataSource = Aluno.ObterLista(txtPesquisa.Text.Trim());
        }

        // ==========================
        // COMBOS
        // ==========================
        private void CarregarCombos()
        {
            cmbUsuario.DataSource = Usuario.ObterLista();
            cmbUsuario.DisplayMember = "Nome";
            cmbUsuario.ValueMember = "IdUsuario";
        }

        // ==========================
        // LIMPAR
        // ==========================
        private void LimparFormulario()
        {
            txtMatricula.Clear();
            mtbCpf.Clear();
            mtbTelefone.Clear();
            txtEndereco.Clear();
            txtPesquisa.Clear();

            if (cmbUsuario.Items.Count > 0)
                cmbUsuario.SelectedIndex = -1;

            dgvAluno.ClearSelection();

            idSelecionado = 0;
        }

        // ==========================
        // VALIDAR
        // ==========================
        private bool ValidarCampos()
        {
            if (cmbUsuario.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um usuário.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatricula.Text))
            {
                MessageBox.Show("Informe a matrícula.");
                return false;
            }

            if (!mtbCpf.MaskCompleted)
            {
                MessageBox.Show("Informe um CPF válido.");
                return false;
            }

            // Telefone opcional, mas se preenchido deve ser válido
            if (!string.IsNullOrWhiteSpace(mtbTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim())
                && !mtbTelefone.MaskCompleted)
            {
                MessageBox.Show("Informe um telefone válido.");
                return false;
            }

            return true;
        }

        // ==========================
        // PREENCHER
        // ==========================
        private void PreencherFormulario(Aluno aluno)
        {
            if (aluno == null) return;

            cmbUsuario.SelectedValue = aluno.IdUsuario;
            txtMatricula.Text = aluno.Matricula;
            mtbCpf.Text = aluno.Cpf;
            mtbTelefone.Text = aluno.Telefone;
            txtEndereco.Text = aluno.Endereco;
        }

        // ==========================
        // EDITAR
        // ==========================
        private void dgvAluno_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvAluno.Rows[e.RowIndex].Cells[0].Value);

            Aluno aluno = Aluno.ObterPorId(id);

            if (aluno != null && aluno.IdAluno > 0)
            {
                idSelecionado = aluno.IdAluno;
                PreencherFormulario(aluno);
            }
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Aluno aluno = new Aluno();

            aluno.IdUsuario = Convert.ToInt32(cmbUsuario.SelectedValue);
            aluno.Matricula = txtMatricula.Text;
            aluno.Cpf = mtbCpf.Text;
            aluno.Telefone = mtbTelefone.Text;
            aluno.Endereco = txtEndereco.Text;
            aluno.StatusAcademico = "regular";

            // INSERIR
            if (idSelecionado == 0)
            {
                if (aluno.Inserir())
                {
                    MessageBox.Show("Aluno cadastrado com sucesso!");
                    CarregarGrid();
                    LimparFormulario();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar aluno.");
                }
            }
            else
            {
                // ATUALIZAR
                aluno.IdAluno = idSelecionado;

                if (aluno.Atualizar())
                {
                    MessageBox.Show("Aluno atualizado com sucesso!");
                    CarregarGrid();
                    LimparFormulario();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar aluno.");
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAluno.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro para editar.");
                return;
            }

            int id = Convert.ToInt32(dgvAluno.CurrentRow.Cells[0].Value);
            Aluno aluno = Aluno.ObterPorId(id);

            if (aluno.IdAluno > 0)
            {
                idSelecionado = aluno.IdAluno;
                PreencherFormulario(aluno);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void btnExluir_Click(object sender, EventArgs e)
        {
            if (idSelecionado == 0 && dgvAluno.CurrentRow != null)
            {
                idSelecionado = Convert.ToInt32(dgvAluno.CurrentRow.Cells[0].Value);
            }

            if (idSelecionado <= 0)
            {
                MessageBox.Show("Selecione um registro para excluir.");
                return;
            }

            var confirm = MessageBox.Show(
                "Deseja realmente excluir este aluno?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Aluno aluno = new Aluno();
                aluno.IdAluno = idSelecionado;

                if (aluno.Excluir())
                {
                    MessageBox.Show("Aluno excluído com sucesso!");
                    CarregarGrid();
                    LimparFormulario();
                }
                else
                {
                    MessageBox.Show("Erro ao excluir aluno.");
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }
    }
}
