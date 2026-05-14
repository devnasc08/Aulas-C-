using Servicehub;

namespace servicehub
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Criar uma instância do formulário Listar Clientes 
            FrmListaClientes listaClientes = new();

            // Associando o form listar clientes como filho principal
            listaClientes.MdiParent = this;

            // Chamar o form de cliente 
            listaClientes.Show();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Criando instância do form novoCliente
            FrmNovoCliente novoCliente = new();
            novoCliente.MdiParent = this;
            novoCliente.Show();
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmServicos listarServicos = new();
            listarServicos.MdiParent = this;
            listarServicos.Show();
        }
    }
}
