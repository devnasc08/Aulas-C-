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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtCodBarras.Text != string.Empty || txtDescricao.Text != string.Empty)
            {
                // Dados
                string codBarras = txtCodBarras.Text;
                string descricao = txtDescricao.Text;
                decimal preco = udPreco.Value;
                string unidade = txtUnidVenda.Text;
                string categoria = cbCategoria.SelectedItem?.ToString() ?? "Sem Categoria";
                decimal estoqueMin = udEstqMinimo.Value;
                bool descontinuado = checkDescontinuado.Checked;


                string status = descontinuado ? "Descontinuado" : "Ativo";
                string linhaProduto = $"{codBarras} \n| {descricao.ToUpper()} \n| Preco: {preco:C2} \n| Est. Min: {estoqueMin} \n| {status}";

                listBox1.Items.Add(linhaProduto);

            }
        }
    }
}
