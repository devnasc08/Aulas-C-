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
        }

        // ==========================
        // VALIDAR CAMPOS
        // ==========================
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Informe o email.");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Informe a senha.");
                txtSenha.Focus();
                return false;
            }

            return true;
        }

        // ==========================
        // LOGIN
        // ==========================
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            this.AcceptButton = btnEntrar;

            if (!ValidarCampos()) return;

            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            // ==========================
            // AUTENTICAÇÃO
            // ==========================
            Usuario usuario = Usuario.EfetuarLogin(email, senha);

            if (usuario != null && usuario.IdUsuario > 0)
            {
                // ==========================
                // SESSÃO
                // ==========================
                Sessao.IdUsuario = usuario.IdUsuario;
                Sessao.Nome = usuario.Nome;
                Sessao.NivelAcesso = usuario.NivelAcesso;

                MessageBox.Show("Bem-vindo, " + usuario.Nome + "!");

                // ==========================
                // ABRIR SISTEMA
                // ==========================
                FrmPrincipal frm = new FrmPrincipal();
                frm.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Email ou senha inválidos.");

                txtSenha.Clear();
                txtSenha.Focus();
            }
        }
    }
}