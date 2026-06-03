using ServiceHubClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicehub
{
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void lblSigla_Click(object sender, EventArgs e)
        {

        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {

            CarregaGrid();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Categoria categoria = new(txtNome.Text, txtSigla.Text);
            categoria.Inserir();
            if (categoria.Id > 0)
            {
                MessageBox.Show($"Categoria {categoria.Id} inserida com sucesso!");
                CarregaGrid();

            }
        }

        private void CarregaGrid(string texto = "")
        {
            dgvCategorias.Rows.Clear();

            List<Categoria> categorias = Categoria.ObterLista(texto);
            foreach (var categoria in categorias)
            {
                // Categoria é um objeto do tipo categoria, por tanto, é uma categoria
                dgvCategorias.Rows.Add();

                dgvCategorias.Rows[dgvCategorias.Rows.Count - 1].Cells[0].Value = categoria.Id;
                dgvCategorias.Rows[dgvCategorias.Rows.Count - 1].Cells[1].Value = categoria.Nome;
                dgvCategorias.Rows[dgvCategorias.Rows.Count - 1].Cells[2].Value = categoria.Sigla;

            }
        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            if (textBuscar.Text.Length > 1)
            {
                CarregaGrid(textBuscar.Text);
            }
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvCategorias.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNome.Text = dgvCategorias.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSigla.Text = dgvCategorias.Rows[e.RowIndex].Cells[2].Value.ToString();

            //MessageBox.Show(id.ToString());

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Categoria cat = new(int.Parse(txtId.Text), txtNome.Text, txtSigla.Text);
            if (cat.Atualizar())
            {
                txtId.Clear();
                txtNome.Clear();
                txtSigla.Clear();
                CarregaGrid();
                MessageBox.Show($"Categoria {cat.Id} alterada com sucesso! \n Lista Atualizada");

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty)
            { // Se for diferente de vazio:

                var resposta = MessageBox.Show(
                    $"Deseja excluir a categoria {txtId.Text}-{txtNome.Text}",
                    "Exlusão de categoria",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2
                    );
                if (resposta == DialogResult.Yes)
                {
                    Categoria cat = new(int.Parse(txtId.Text));
                    cat.Excluir();
                    CarregaGrid();
                }

            }
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                //int linha = dgvCategorias.CurrentRow.Index:
                txtId.Text = dgvCategorias.CurrentRow.Cells[0].Value?.ToString() ?? "";
                txtNome.Text = dgvCategorias.CurrentRow.Cells[1].Value?.ToString() ?? "";
                txtSigla.Text = dgvCategorias.CurrentRow.Cells[2].Value?.ToString() ?? "";

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
