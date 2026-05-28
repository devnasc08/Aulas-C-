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
    }
}
