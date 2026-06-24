using System;
using System.Linq;
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
            dgvFrequencia.DataSource = Frequencia.ObterLista();
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

            dgvFrequencia.ClearSelection();

            idSelecionado = 0;
        }

        // ==========================
        // VALIDAR (NEGÓCIO)
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

            int total = 0;
            int presencas = 0;

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
                MessageBox.Show("Presenças não podem ser maiores que o total de aulas.");
                return false;
            }

            return true;
        }

        // ==========================
        // CALCULAR PERCENTUAL (TELA)
        // ==========================
        private void CalcularPercentualTela()
        {
            int total = 0;
            int presencas = 0;

            int.TryParse(txtTotalAulas.Text, out total);
            int.TryParse(txtPresencas.Text, out presencas);

            decimal percentual = 0;

            if (total > 0)
                percentual = (presencas * 100m) / total;

            txtPercentual.Text = percentual.ToString("0.00");
        }

        // ==========================
        // EVENTOS AUTOMÁTICOS
        // ==========================
        private void txtTotalAulas_TextChanged(object sender, EventArgs e)
        {
            CalcularPercentualTela();
        }

        private void txtPresencas_TextChanged(object sender, EventArgs e)
        {
            CalcularPercentualTela();
        }

        // ==========================
        // PREENCHER FORM
        // ==========================
        private void PreencherFormulario(Frequencia frequencia)
        {
            if (frequencia == null) return;

            idSelecionado = frequencia.IdFrequencia;

            cmbMatricula.SelectedValue = frequencia.IdMatricula;
            cmbDisciplina.SelectedValue = frequencia.IdDisciplina;

            txtTotalAulas.Text = frequencia.TotalAulas.ToString();
            txtPresencas.Text = frequencia.Presencas.ToString();
            txtPercentual.Text = frequencia.Percentual.ToString("0.00");
        }

        // ==========================
        // INTEGRAÇÃO COM NOTA
        // ==========================
        private void IntegrarComNota(int idMatricula, int idDisciplina, decimal percentual)
        {
            var notas = Nota.ObterLista();

            var nota = notas.FirstOrDefault(n =>
                n.IdMatricula == idMatricula &&
                n.IdDisciplina == idDisciplina);

            if (nota == null) return;

            // REGRA ACADÊMICA REAL
            if (percentual < 75)
            {
                nota.Status = "reprovado_falta";
            }

            nota.Atualizar();
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

            Frequencia frequencia = new Frequencia();

            frequencia.IdMatricula = Convert.ToInt32(cmbMatricula.SelectedValue);
            frequencia.IdDisciplina = Convert.ToInt32(cmbDisciplina.SelectedValue);

            int valor;

            if (int.TryParse(txtTotalAulas.Text, out valor))
                frequencia.TotalAulas = valor;

            if (int.TryParse(txtPresencas.Text, out valor))
                frequencia.Presencas = valor;

            if (frequencia.Inserir())
            {
                IntegrarComNota(
                    frequencia.IdMatricula,
                    frequencia.IdDisciplina,
                    frequencia.Percentual
                );

                MessageBox.Show("Frequência cadastrada com sucesso!");
                CarregarGrid();
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar frequência.");
            }
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

            Frequencia frequencia = Frequencia.ObterPorId(id);

            PreencherFormulario(frequencia);
        }

        // ==========================
        // ATUALIZAR
        // ==========================
        private void AtualizarRegistro()
        {
            if (idSelecionado <= 0) return;

            if (!ValidarCampos()) return;

            Frequencia frequencia = new Frequencia();

            frequencia.IdFrequencia = idSelecionado;
            frequencia.IdMatricula = Convert.ToInt32(cmbMatricula.SelectedValue);
            frequencia.IdDisciplina = Convert.ToInt32(cmbDisciplina.SelectedValue);

            int valor;

            if (int.TryParse(txtTotalAulas.Text, out valor))
                frequencia.TotalAulas = valor;

            if (int.TryParse(txtPresencas.Text, out valor))
                frequencia.Presencas = valor;

            if (frequencia.Atualizar())
            {
                IntegrarComNota(
                    frequencia.IdMatricula,
                    frequencia.IdDisciplina,
                    frequencia.Percentual
                );

                MessageBox.Show("Frequência atualizada com sucesso!");
                CarregarGrid();
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Erro ao atualizar frequência.");
            }
        }

        // ==========================
        // EXCLUIR
        // ==========================
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvFrequencia.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro.");
                return;
            }

            int id = Convert.ToInt32(dgvFrequencia.CurrentRow.Cells[0].Value);

            var confirmacao = MessageBox.Show(
                "Deseja realmente excluir esta frequência?",
                "Confirmação",
                MessageBoxButtons.YesNo
            );

            if (confirmacao != DialogResult.Yes)
                return;

            Frequencia frequencia = new Frequencia();
            frequencia.IdFrequencia = id;

            if (frequencia.Excluir())
            {
                MessageBox.Show("Frequência excluída com sucesso!");
                CarregarGrid();
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Erro ao excluir frequência.");
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
        private void dgvFrequencia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar_Click(sender, e);
        }
    }
}