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
    public partial class FrmServicos : Form
    {
        public FrmServicos()
        {
            InitializeComponent();
        }

        private void FrmServicos_Load(object sender, EventArgs e)
        {
            txtNome.Focus();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string descricao = txtDescricao.Text;
            double preco = (double)nudPreco.Value; //Cast (Conversão forçada)

            var cmd = Banco.Abrir();
            cmd.CommandText = $"insert servicos (nome, descricao, preco)" +
                $"values ('{nome}', '{descricao}', {preco})";

            if (cmd.ExecuteNonQuery() > 0)
            {
                //Retornando o ultimo Id inserido - Mysql trabalhando com C#
                cmd.CommandText = "select last_insert_id()";
                txtId.Text = cmd.ExecuteScalar().ToString(); // Retorna a primeira linha da primeira coluna
                btnAdd.Enabled = false;

            }


        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (btnPesquisar.Text == "&Pesquisar")
            {

                txtId.ReadOnly = false;
                txtNome.ReadOnly = true;
                txtDescricao.ReadOnly = true;
                nudPreco.ReadOnly = true;
                cbDescontinuado.Enabled = false;
                txtId.Focus();
                btnPesquisar.Text = "Buscar...";
            }
            else if (btnPesquisar.Text == "Buscar...")
            {
                // Busca no Banco
                var cmd = Banco.Abrir();
                cmd.CommandText = $"select * from servicos where id = {txtId.Text}";
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtNome.Text = dr.GetString(1);
                    txtDescricao.Text = dr.GetString(2);
                    nudPreco.Value = dr.GetDecimal(3);
                    cbDescontinuado.Checked = dr.GetBoolean(4);
                }
                btnPesquisar.Text = "&Pesquisar";
                txtId.ReadOnly = true;

            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "&Editar")
            {
                txtDescricao.ReadOnly = false;
                txtNome.ReadOnly = false;
                nudPreco.ReadOnly=false;
                cbDescontinuado.Enabled = true;
                btnEdit.Text = "Salvar";
            }
            else 
            {
                string id = txtId.Text;
                string nome = txtNome.Text;
                string descricao = txtDescricao.Text;
                double preco = (double)nudPreco.Value;
                string descont = cbDescontinuado.Checked ? "1" : "0";
                decimal pre = nudPreco.Value;
                

                var cmd = Banco.Abrir();
                cmd.CommandText = $"update servicos set nome = '{nome}', descricao = '{txtDescricao.Text}'," +
                    $"preco = '{pre}', descontinuado = '{descont}' where id = '{txtId.Text}'";
                if (cmd.ExecuteNonQuery() > 0)
                {
                    btnEdit.Text = "&Editar";
                }
                
            }
        }
    }
}
