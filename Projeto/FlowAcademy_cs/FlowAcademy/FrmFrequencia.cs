using System;
using System.Windows.Forms;
using FlowAcademyClasses;

namespace FlowAcademyF
{
    public partial class FrmFrequencia : Form
    {
        private int idSelecionado = 0;

        public FrmFrequencia()
        {
            InitializeComponent();
        }

        // ==========================
        // LOAD
        // ==========================
        private void FrmFrequencia_Load(object sender, EventArgs e)
        {
            CarregarCombos();
            CarregarGrid();
            LimparFormulario();

            txtPercentual.ReadOnly = true;
        }

        // ==========================
        // GRID
        // ==========================
        private void CarregarGrid()
        {
            dgvFrequencia.DataSource = Frequencia.ObterLista(txtPesquisa.Text.Trim());
            dgvFrequencia.ClearSelection();
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

            txtTotalAulas.Clear();
            txtPresencas.Clear();
            txtPercentual.Clear();
            txtPesquisa.Clear();

            dgvFrequencia.ClearSelection();

            idSelecionado = 0;
        }

        // ==========================
        // VALIDAÇÃO
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

            int total, presencas;

            if (!int.TryParse(txtTotalAulas.Text, out total) || total <= 0)
            {
                MessageBox.Show("Total de aulas inválido.");
                return false;
            }

            if (!int.TryParse(txtPresencas.Text, out presencas) || presencas < 0)
            {
                MessageBox.Show("Presenças inválidas.");
                return false;
            }

            if (presencas > total)
            {
                MessageBox.Show("Presenças não podem ser maiores que o total.");
                return false;
            }

            return true;
        }

        // ==========================
        // CALCULAR
        // ==========================
        private void CalcularPercentualTela()
        {
            int total, presencas;

            int.TryParse(txtTotalAulas.Text, out total);
            int.TryParse(txtPresencas.Text, out presencas);

            decimal percentual = 0;

            if (total > 0)
                percentual = (presencas * 100m) / total;

            txtPercentual.Text = percentual.ToString("0.00");
        }

        // ==========================
        // PREENCHER FORM
        // ==========================
        private void PreencherFormulario(Frequencia f)
        {
            if (f == null) return;

            idSelecionado = f.IdFrequencia;

            cmbMatricula.SelectedValue = f.IdMatricula;
            cmbDisciplina.SelectedValue = f.IdDisciplina;

            txtTotalAulas.Text = f.TotalAulas.ToString();
            txtPresencas.Text = f.Presencas.ToString();
            txtPercentual.Text = f.Percentual.ToString("0.00");
        }

        // ==========================
        // EDITAR
        // ==========================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvFrequencia.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro.");
                return;
            }

            int id = Convert.ToInt32(dgvFrequencia.CurrentRow.Cells[0].Value);
            var f = Frequencia.ObterPorId(id);

            PreencherFormulario(f);
        }

        // ==========================
        // EXCLUIR
        // ==========================
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idSelecionado == 0 && dgvFrequencia.CurrentRow != null)
            {
                idSelecionado = Convert.ToInt32(dgvFrequencia.CurrentRow.Cells[0].Value);
            }

            if (dgvFrequencia.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro.");
                return;
            }

            if (MessageBox.Show("Deseja excluir?",
                "Confirmação",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            Frequencia f = new Frequencia();
            f.IdFrequencia = idSelecionado;

            if (f.Excluir())
            {
                MessageBox.Show("Excluído com sucesso!");
                CarregarGrid();
                LimparFormulario();
            }
            else
                MessageBox.Show("Erro ao excluir.");
        }

        // ==========================
        // SALVAR
        // ==========================
        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            if (idSelecionado > 0)
            {
                AtualizarRegistro();
                return;
            }

            if (!ValidarCampos()) return;

            Frequencia f = new Frequencia();

            f.IdMatricula = Convert.ToInt32(cmbMatricula.SelectedValue);
            f.IdDisciplina = Convert.ToInt32(cmbDisciplina.SelectedValue);

            int valor;

            if (int.TryParse(txtTotalAulas.Text, out valor))
                f.TotalAulas = valor;

            if (int.TryParse(txtPresencas.Text, out valor))
                f.Presencas = valor;

            if (f.Inserir())
            {
                MessageBox.Show("Cadastrado com sucesso!");
                CarregarGrid();
                LimparFormulario();
            }
            else
                MessageBox.Show("Erro ao cadastrar.");
        }

        // ==========================
        // ATUALIZAR
        // ==========================
        private void AtualizarRegistro()
        {
            if (idSelecionado <= 0) return;

            if (!ValidarCampos()) return;

            Frequencia f = new Frequencia();

            f.IdFrequencia = idSelecionado;
            f.IdMatricula = Convert.ToInt32(cmbMatricula.SelectedValue);
            f.IdDisciplina = Convert.ToInt32(cmbDisciplina.SelectedValue);

            int valor;

            if (int.TryParse(txtTotalAulas.Text, out valor))
                f.TotalAulas = valor;

            if (int.TryParse(txtPresencas.Text, out valor))
                f.Presencas = valor;

            if (f.Atualizar())
            {
                MessageBox.Show("Atualizado com sucesso!");
                CarregarGrid();
                LimparFormulario();
            }
            else
                MessageBox.Show("Erro ao atualizar.");
        }

        // ==========================
        // EVENTOS
        // ==========================
        private void txtTotalAulas_TextChanged_1(object sender, EventArgs e)
        {
            CalcularPercentualTela();
        }

        private void txtPresencas_TextChanged(object sender, EventArgs e)
        {
            CalcularPercentualTela();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            CalcularPercentualTela();
        }

        private void dgvFrequencia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFrequencia.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvFrequencia.CurrentRow.Cells[0].Value);
            var f = Frequencia.ObterPorId(id);

            PreencherFormulario(f);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }
    }
}
