using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Servicehub
{
    public partial class FrmComponente : Form
    {
        public FrmComponente()
        {
            InitializeComponent();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            // Entrada
            if (textBox1.Text != string.Empty)
            {
                //int numero = int.Parse(textBox1.Text);
                //listBox1.Items.Clear();
                //for (int i = 0; i < 0; i++)
                //{
                //    listBox1.Items.Add($"{numero} x {i + 1} = {numero * (i + 1)}");
                //}
                //textBox1.Clear();
                //textBox1.Focus();

                // Entrada
                double numero1 = 0;
                numero1 = double.Parse(textBox1.Text);
                double numero2 = 0;
                numero2 = double.Parse(textBox2.Text);

                numero2 = comboBox1.SelectedIndex < 5 ? double.Parse(textBox2.Text) : 0;

                switch (comboBox1.SelectedIndex)
                {
                    case 0:  // Multiplicação
                        listBox1.Items.Add("---------- Multiplicação ----------");
                        listBox1.Items.Add($"{numero1} x {numero2} = {numero1 * numero2}");
                        break;

                    case 1:  // Divisão
                        listBox1.Items.Add("---------- Divisão ----------");
                        listBox1.Items.Add($"{numero1} / {numero2} = {numero1 / numero2:F3}");
                        break;

                    case 2:  // Adição
                        listBox1.Items.Add("---------- Adição ----------");
                        listBox1.Items.Add($"{numero1} + {numero2} = {numero1 + numero2}");
                        break;

                    case 3: //Subtração
                        listBox1.Items.Add("---------- Subtração ----------");
                        listBox1.Items.Add($"{numero1} - {numero2} = {numero1 - numero2}");
                        break;

                    case 4:  // Exponenciação
                        listBox1.Items.Add("---------- Exponenciação ----------");
                        // Pow espera base e a potência
                        listBox1.Items.Add(Math.Pow(numero1, numero2));
                        break;

                    case 5:  // Tabuada
                        listBox1.Items.Add("---------- Tabuada ----------");
                        for (int i = 1; i < 11; i++)
                        {
                            listBox1.Items.Add($"  {numero1}x {i} = {numero1 * i}");
                        }
                        break;

                    case 6:  // Radiciação
                        listBox1.Items.Add("---------- Radiciação ----------");
                        //Retorna a raiz quadrada de um núm especifico
                        listBox1.Items.Add(Math.Sqrt(numero1));
                        break;

                    default:
                        Console.WriteLine("Opção Inválida");
                        break;


                }

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            // Quando o Indice selecionado mudar

            //        Comentário  Cabeçalho                Botões Sim/Não          Icone    
            MessageBox.Show("Olá","mensagem", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            // Char = '3'

            // Associa o tipo de acordo com a resposta
            var resposta = MessageBox.Show("oi", "Título", MessageBoxButtons.YesNoCancel,MessageBoxIcon.None,MessageBoxDefaultButton.Button3);
            if (resposta == DialogResult.Yes)
            {
                MessageBox.Show("Muito bem, você escolheu ok!");
            }*/


            // MessageBox.Show(comboBox1.SelectedIndex.ToString());

            if (comboBox1.SelectedIndex < 5)
            {
                label1.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox1.Focus();
            }
            else
            {
                label1.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = false;
                textBox1.Focus();
            }
        }

        private void FrmComponente_Load(object sender, EventArgs e)
        {
            var cmd = Banco.Abrir();
            cmd.CommandText = "select * from servicos";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dgvServicos.Rows.Add();
                int linha = dgvServicos.RowCount - 1;
                //MessageBox.Show(dgvServicos.RowCount.ToString());
                dgvServicos.Rows[linha].Cells[0].Value = dr.GetInt32(0);
                dgvServicos.Rows[linha].Cells[1].Value = dr.GetString(1);
                dgvServicos.Rows[linha].Cells[2].Value = dr.GetString(2);
                dgvServicos.Rows[linha].Cells[3].Value = dr.GetDouble(3);
                dgvServicos.Rows[linha].Cells[4].Value = dr.GetBoolean(4);

                //MessageBox.Show(dgvServicos.RowCount.ToString());
                //listBox1.Items.Add(dr.GetString(1));

            }
            //dr.Close();
            cmd = Banco.Abrir();
            cmd.CommandText = "select id, nome, email from usuarios where ativo=1";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dgvUsers.Rows.Add();
                int line = dgvUsers.RowCount - 1;
                dgvUsers.Rows[line].Cells[0].Value = dr.GetInt32(0);
                dgvUsers.Rows[line].Cells[1].Value = dr.GetString(1);
                dgvUsers.Rows[line].Cells[2].Value = dr.GetString(2);
            }
            //dr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgvSolicitacoes.Rows.Clear();
            var cmd = Banco.Abrir();
            cmd.CommandText = "select id, descricao_problema from solicitacoes";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dgvSolicitacoes.Rows.Clear();

                dgvSolicitacoes.Rows.Add();
                int lines2 = dgvSolicitacoes.RowCount - 1; 
                dgvSolicitacoes.Rows[lines2].Cells[0].Value = dr.GetInt32(0);
                dgvSolicitacoes.Rows[lines2].Cells[1].Value = dr.GetString(1);
                // Nenhum teste realizado! 
            }
        }

    }
}
