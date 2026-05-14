using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace servicehub
{
    public partial class FrmListaClientes : Form
    {
        public FrmListaClientes()
        {
            InitializeComponent();
        }

        private void FrmListaClientes_Load(object sender, EventArgs e)
        {
            // Enquanto está carregando
            dgvClientes.Rows.Add();
            //         Linha     Coluna
            dgvClientes.Rows[0].Cells[0].Value = 1;
            dgvClientes.Rows[0].Cells[1].Value = 10114578;
            dgvClientes.Rows[0].Cells[2].Value = "Maria da Silva";
            dgvClientes.Rows[0].Cells[3].Value = "12345678966";
            dgvClientes.Rows[0].Cells[4].Value = "maria@couves.com";
            dgvClientes.Rows[0].Cells[5].Value = "1121859200";
            dgvClientes.Rows[0].Cells[6].Value = true;


            dgvClientes.Rows.Add();
            dgvClientes.Rows[1].Cells[0].Value = 1;
            dgvClientes.Rows[1].Cells[1].Value = 10114579;
            dgvClientes.Rows[1].Cells[2].Value = "José da Silva";
            dgvClientes.Rows[1].Cells[3].Value = "12345678519";
            dgvClientes.Rows[1].Cells[4].Value = "José@couves.com";
            dgvClientes.Rows[1].Cells[5].Value = "11854152581";
            dgvClientes.Rows[1].Cells[6].Value = true;
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Captura o valor da célula da coluna 1 da linha selecionada no DataGridView
            // e converte o valor para string, armazenando na variável "id" 
            string id = dgvClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            // Mostra a mensagem
            MessageBox.Show(id);
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Você clicou no conteúdo da célula");
        }
    }
}
