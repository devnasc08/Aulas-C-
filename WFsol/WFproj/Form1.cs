namespace WFproj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você digitou o nome: " + txtNome.Text);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void calcular_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            double n1 = double.Parse(txtN1.Text);
            double n2 = double.Parse(txtN2.Text);

            txtAdicao.Text = (n1 + n2).ToString(); //Double + Double = X | E depois passa a ser String
            txtSubtracao.Text = (n1 - n2).ToString();
            txtMultiplicacao.Text = (n1 * n2).ToString();
            txtDivisao.Text = (n1 / n2).ToString();

            if (n1 >= n2)
            {
                txtMaior.Text = n1.ToString();
                txtMenor.Text = n2.ToString();
            }
            else
            {
                txtMenor.Text = n2.ToString();
                txtMaior.Text = n1.ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void n1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
