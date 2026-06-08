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
    public partial class FrmProduto : Form
    {
        public FrmProduto()
        {
            InitializeComponent();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            //var categorias = Categoria.ObterLista();
            cmbCategoria.DataSource = Categoria.ObterLista();
            cmbCategoria.ValueMember = "Nome";
            cmbCategoria.DisplayMember = "Id";

            dgvProdutos.DataSource = Produto.ObterLista();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto produto = new(
                txtCodBarras.Text,
                txtDescricao.Text,
                (double)nudValorUnit.Value,
                nudUnidVenda.Text,
                Categoria.ObterPorId(Convert.ToInt32(cmbCategoria.SelectedValue)),
                (double)nudEstqMinimo.Value,
                (double)nudClassDesconto.Value
                );

            produto.Inserir();
            if (produto.Id > 0)
                MessageBox.Show($"Produto {produto.Descricao} gravado com sucesso!");

        }

        private void CarreagaCategoria()
        {
            cmbCategoria.DataSource = Categoria.ObterLista();
            cmbCategoria.DisplayMember = "Nome";
            cmbCategoria.ValueMember = "Id";


        }

        private void CarregaGrid(string texto = "")
        {
            dgvProdutos.Rows.Clear();

            List<Produto> produtos = Produto.ObterLista();
            foreach (var produto in produtos)
            {
                dgvProdutos.Rows.Add();

                int linha = dgvProdutos.Rows.Count - 1;
                dgvProdutos.Rows[linha].Cells[0].Value = produto.Id;
                dgvProdutos.Rows[linha].Cells[1].Value = produto.CodBarras;
                dgvProdutos.Rows[linha].Cells[2].Value = produto.Descricao;
                dgvProdutos.Rows[linha].Cells[3].Value = produto.preco;
                


            }
        }
    }
}
