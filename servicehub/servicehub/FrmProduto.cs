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
            cbCategoria.DataSource = Categoria.ObterLista();
            cbCategoria.ValueMember = "Nome";
            cbCategoria.DisplayMember = "Id";

            dataGridView1.DataSource = Produto.ObterLista();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto produto = new(
                txtCodBarras.Text,
                txtDescricao.Text,
                (double)nudValorUnit.Value,
                nudUnidVenda.Text,
                Categoria.ObterPorId(Convert.ToInt32(cbCategoria.SelectedValue)),
                (double)nudEstqMinimo.Value,
                (double)nudClassDesconto.Value
                );

            produto.Inserir();
            if (produto.Id > 0)
                MessageBox.Show($"Produto {produto.Descricao} gravado com sucesso!");

        }
    }
}
