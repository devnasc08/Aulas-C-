using ServiceHubClass;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Servicehub
{
    public partial class FrmUsuarios : Form
    {
        private int usuarioSelecionadoId = 0;

        public FrmUsuarios()
        {
            InitializeComponent();

            // Liga os botoes e campos aos metodos desta tela.
            //btnAdd.Click += btnAdd_Click;
            //btnEdit.Click += btnEdit_Click;
            //btnExcluir.Click += btnExcluir_Click;
            //btnCancelar.Click += btnCancelar_Click;
            //btnPesquisar.Click += btnPesquisar_Click;
            //txtBuscar.TextChanged += txtBuscar_TextChanged;
            //dgvNiveis.SelectionChanged += dgvNiveis_SelectionChanged;

            CarregaGrid();

        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CarregaNiveis();
            CarregaGrid();
        }

        private void CarregaNiveis()
        {
            // O combo guarda o Id do nivel, mas mostra o nome para o usuario.
            cmbNiveis.DataSource = Nivel.ObterLista();
            cmbNiveis.DisplayMember = "Nome";
            cmbNiveis.ValueMember = "Id";
        }

        private void CarregaGrid(string texto = "")
        {
            dgvNiveis.Rows.Clear();

            // A busca vem da classe Usuario e o formulario apenas exibe o resultado.
            List<Usuario> usuarios = Usuario.ObterLista(texto);
            foreach (var usuario in usuarios)
            {
                dgvNiveis.Rows.Add();

                int linha = dgvNiveis.Rows.Count - 1;
                dgvNiveis.Rows[linha].Cells[0].Value = usuario.Id;
                dgvNiveis.Rows[linha].Cells[1].Value = usuario.Nome;
                dgvNiveis.Rows[linha].Cells[2].Value = usuario.Email;
            }
        }

        private Nivel? NivelSelecionado()
        {
            // Converte o item escolhido no combo para um objeto Nivel.
            if (cmbNiveis.SelectedItem is Nivel nivel)
                return nivel;

            if (cmbNiveis.SelectedValue is int id)
                return Nivel.ObterPorId(id);

            return null;
        }

        private Usuario DadosDoFormulario()
        {
            // Monta o objeto Usuario a partir dos campos visuais.
            return new Usuario(
                usuarioSelecionadoId,
                txtNome.Text.Trim(),
                txtEmail.Text.Trim(),
                NivelSelecionado(),
                txtSenha.Text,
                checkAtivo.Checked
            );
        }

        private bool FormularioValido()
        {
            // Evita gravar registros incompletos no banco.
            if (txtNome.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Informe o nome do usuario.");
                txtNome.Focus();
                return false;
            }

            if (txtEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Informe o email do usuario.");
                txtEmail.Focus();
                return false;
            }

            if (txtSenha.Text == string.Empty)
            {
                MessageBox.Show("Informe a senha do usuario.");
                txtSenha.Focus();
                return false;
            }

            if (NivelSelecionado() == null)
            {
                MessageBox.Show("Selecione um nivel para o usuario.");
                cmbNiveis.Focus();
                return false;
            }

            return true;
        }

        private void LimparFormulario()
        {
            // Volta a tela para o estado de novo cadastro.
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            checkAtivo.Checked = true;

            if (cmbNiveis.Items.Count > 0)
                cmbNiveis.SelectedIndex = 0;
        }



        private void txtBuscar_TextChanged(object? sender, EventArgs e)
        {
            CarregaGrid(txtBuscar.Text.Trim());
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (usuarioSelecionadoId < 1)
            {
                MessageBox.Show("Selecione um usuario para editar.");
                return;
            }

            if (!FormularioValido()) return;

            Usuario usuario = DadosDoFormulario();
            if (usuario.Atualizar())
            {
                MessageBox.Show($"Usuario {usuario.Id} alterado com sucesso!");
                LimparFormulario();
                CarregaGrid();
            }
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 1)
            {
                CarregaGrid(txtBuscar.Text);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (!FormularioValido()) return;

            Usuario usuario = DadosDoFormulario();
            usuario.Inserir();

            if (usuario.Id > 0)
            {
                MessageBox.Show($"Usuario {usuario.Id} inserido com sucesso!");
                LimparFormulario();
                CarregaGrid();
            }
        }


        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            if (usuarioSelecionadoId < 1)
            {
                MessageBox.Show("Selecione um usuário para excluir");
                return;
            }

            var resposta = MessageBox.Show(
                $"Deseja excluir o usuario {usuarioSelecionadoId}-{txtNome.Text}?",
                "Exclusão de usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (resposta == DialogResult.Yes)
            {
                Usuario usuario = new(usuarioSelecionadoId);
                usuario.Excluir();
                LimparFormulario();
                CarregaGrid();
            }


        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            LimparFormulario();
        }
        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {

            CarregaGrid(txtBuscar.Text.Trim());
        }
    }
}
