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
    public partial class FrmNiveis : Form
    {
        public FrmNiveis()
        {
            InitializeComponent();
        }

        private void FrmNiveis_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void CarregaGrid(string texto = "")
        {
            dgvNiveis.Rows.Clear();

            List<Nivel> niveis = Nivel.ObterLista(texto);
            foreach (var nivel in niveis)
            {
                dgvNiveis.Rows.Add();

                dgvNiveis.Rows[dgvNiveis.Rows.Count - 1].Cells[0].Value = nivel.Id;
                dgvNiveis.Rows[dgvNiveis.Rows.Count - 1].Cells[1].Value = nivel.Nome;
                dgvNiveis.Rows[dgvNiveis.Rows.Count - 1].Cells[2].Value = nivel.Sigla;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Nivel nivel = new(txtNome.Text, txtSigla.Text);
            nivel.Inserir();
            if (nivel.Id > 0)
            {
                MessageBox.Show($"Nivel {nivel.Id} inserida com sucesso!");
                CarregaGrid();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
                CarregaGrid(txtBuscar.Text);
        }

        private void dgvNiveis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvNiveis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvNiveis.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNome.Text = dgvNiveis.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSigla.Text = dgvNiveis.Rows[e.RowIndex].Cells[2].Value.ToString();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvNiveis.Rows.Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Nivel niv = new(int.Parse(txtId.Text), txtNome.Text, txtSigla.Text);
            if (niv.Update())
            {
                txtId.Clear();
                txtNome.Clear();
                txtSigla.Clear();
                CarregaGrid();
                MessageBox.Show($"Nivel {niv.Id} alterado com sucesso");
            }
                
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty)
            {
                var resposta = MessageBox.Show(
                    $"Deseja excluir o nível {txtId.Text}-{txtNome.Text}",
                    "Exclusão de Nível",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2
                    );
                if (resposta == DialogResult.Yes)
                {
                    Nivel niv = new(int.Parse(txtId.Text));
                    niv.Excluir();
                    CarregaGrid();
                }
            }
        }

        private void dgvNiveis_SelectionChanged(object sender, EventArgs e)
        {
            txtId.Text = dgvNiveis.CurrentRow.Cells[0].Value?.ToString() ?? "";
            txtNome.Text = dgvNiveis.CurrentRow.Cells[1].Value?.ToString() ?? "";
            txtSigla.Text = dgvNiveis.CurrentRow.Cells[2].Value?.ToString() ?? "";

        }
    }
}
