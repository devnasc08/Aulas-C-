using System;
using System.Windows.Forms;

namespace FlowAcademyF
{
    public partial class FrmFeedback : Form
    {
        public FrmFeedback()
        {
            InitializeComponent();
        }

        private void FrmFeedback_Load(object sender, EventArgs e)
        {
            cmbTipoFeedback.Items.Clear();

            cmbTipoFeedback.Items.Add("Sugestão");
            cmbTipoFeedback.Items.Add("Erro");
            cmbTipoFeedback.Items.Add("Elogio");

            cmbTipoFeedback.SelectedIndex = 0;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFeedback.Text))
            {
                MessageBox.Show("Digite um feedback.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensagem = txtFeedback.Text;
            string tipo = cmbTipoFeedback.SelectedItem.ToString();

            MessageBox.Show(
                $"Feedback enviado com sucesso!\n\nTipo: {tipo}\nMensagem: {mensagem}",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            LimparCampos();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimparCampos()
        {
            txtFeedback.Clear();
            cmbTipoFeedback.SelectedIndex = 0;
        }
    }
}