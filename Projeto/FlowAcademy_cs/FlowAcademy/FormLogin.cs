using System;
using System.Windows.Forms;
using FlowAcademyClasses;

namespace FlowAcademy
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        // ==========================
        // LOAD
        // ==========================
        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
            txtSenha.PasswordChar = '*';

            // Define botão padrão (Enter)
            this.AcceptButton = btnEntrar;
        }

        // ==========================
        // VALIDAÇÃO DE CAMPOS
        // ==========================
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Informe o e-mail.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Informe a senha.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return false;
            }

            return true;
        }

        // ==========================
        // LOGIN
        // ==========================
        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();

            try
            {
                // AUTENTICAÇÃO
                Usuario usuario = Usuario.EfetuarLogin(email, senha);

                if (usuario != null && usuario.IdUsuario > 0)
                {
                    // SESSÃO
                    Sessao.IdUsuario = usuario.IdUsuario;
                    Sessao.Nome = usuario.Nome;
                    Sessao.NivelAcesso = usuario.NivelAcesso;

                    MessageBox.Show($"Bem-vindo, {usuario.Nome}!",
                        "Login realizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // ABRIR SISTEMA
                    FrmPrincipal frm = new FrmPrincipal();
                    frm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("E-mail ou senha inválidos.",
                        "Erro de login",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    txtSenha.Clear();
                    txtSenha.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar login: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================
        // EVENTOS (opcional)
        // ==========================
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
