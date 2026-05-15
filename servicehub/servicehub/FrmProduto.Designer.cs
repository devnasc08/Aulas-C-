namespace Servicehub
{
    partial class FrmProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCodBarras = new TextBox();
            txtDescricao = new TextBox();
            txtUnidVenda = new TextBox();
            lblCodBarras = new Label();
            lblDescricao = new Label();
            lblPreco = new Label();
            btnBuscar = new Button();
            lblUnidVenda = new Label();
            cbCategoria = new ComboBox();
            lblCategoria = new Label();
            lblEstqMinimo = new Label();
            lblClassDesconto = new Label();
            btnSalvar = new Button();
            btnEditar = new Button();
            btnCancelar = new Button();
            btnCarregarImg = new Button();
            checkDescontinuado = new CheckBox();
            pictureBox1 = new PictureBox();
            udPreco = new NumericUpDown();
            udClassDesconto = new NumericUpDown();
            listBox1 = new ListBox();
            udEstqMinimo = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udClassDesconto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udEstqMinimo).BeginInit();
            SuspendLayout();
            // 
            // txtCodBarras
            // 
            txtCodBarras.Location = new Point(94, 33);
            txtCodBarras.Name = "txtCodBarras";
            txtCodBarras.PlaceholderText = "Código de Barras";
            txtCodBarras.Size = new Size(233, 23);
            txtCodBarras.TabIndex = 0;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(94, 72);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.PlaceholderText = "Descrição";
            txtDescricao.Size = new Size(401, 23);
            txtDescricao.TabIndex = 0;
            // 
            // txtUnidVenda
            // 
            txtUnidVenda.Location = new Point(372, 112);
            txtUnidVenda.Name = "txtUnidVenda";
            txtUnidVenda.PlaceholderText = "Unid. Venda";
            txtUnidVenda.Size = new Size(123, 23);
            txtUnidVenda.TabIndex = 0;
            // 
            // lblCodBarras
            // 
            lblCodBarras.AutoSize = true;
            lblCodBarras.Location = new Point(27, 36);
            lblCodBarras.Name = "lblCodBarras";
            lblCodBarras.Size = new Size(61, 15);
            lblCodBarras.TabIndex = 1;
            lblCodBarras.Text = "CodBarras";
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Location = new Point(27, 75);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(58, 15);
            lblDescricao.TabIndex = 1;
            lblDescricao.Text = "Descrição";
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Location = new Point(27, 112);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(37, 15);
            lblPreco.TabIndex = 1;
            lblPreco.Text = "Preço";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(397, 33);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(98, 26);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "&Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // lblUnidVenda
            // 
            lblUnidVenda.AutoSize = true;
            lblUnidVenda.Location = new Point(271, 115);
            lblUnidVenda.Name = "lblUnidVenda";
            lblUnidVenda.Size = new Size(86, 15);
            lblUnidVenda.TabIndex = 1;
            lblUnidVenda.Text = "Unidade Venda";
            // 
            // cbCategoria
            // 
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Items.AddRange(new object[] { "Amortecedor", "Óleos e Lubrificantes", "Outros" });
            cbCategoria.Location = new Point(93, 150);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(402, 23);
            cbCategoria.TabIndex = 4;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(27, 153);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(58, 15);
            lblCategoria.TabIndex = 1;
            lblCategoria.Text = "Categoria";
            // 
            // lblEstqMinimo
            // 
            lblEstqMinimo.AutoSize = true;
            lblEstqMinimo.Location = new Point(27, 194);
            lblEstqMinimo.Name = "lblEstqMinimo";
            lblEstqMinimo.Size = new Size(94, 15);
            lblEstqMinimo.TabIndex = 1;
            lblEstqMinimo.Text = "Estoque Minímo";
            // 
            // lblClassDesconto
            // 
            lblClassDesconto.AutoSize = true;
            lblClassDesconto.Location = new Point(271, 196);
            lblClassDesconto.Name = "lblClassDesconto";
            lblClassDesconto.Size = new Size(93, 15);
            lblClassDesconto.TabIndex = 1;
            lblClassDesconto.Text = "Classe Desconto";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(121, 333);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(97, 46);
            btnSalvar.TabIndex = 2;
            btnSalvar.Text = "&Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(398, 333);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(97, 46);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "&Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(641, 333);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(96, 46);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnCarregarImg
            // 
            btnCarregarImg.Location = new Point(607, 234);
            btnCarregarImg.Name = "btnCarregarImg";
            btnCarregarImg.Size = new Size(159, 29);
            btnCarregarImg.TabIndex = 2;
            btnCarregarImg.Text = "&Carregar Imagem";
            btnCarregarImg.UseVisualStyleBackColor = true;
            // 
            // checkDescontinuado
            // 
            checkDescontinuado.AutoSize = true;
            checkDescontinuado.Location = new Point(389, 240);
            checkDescontinuado.Name = "checkDescontinuado";
            checkDescontinuado.Size = new Size(106, 19);
            checkDescontinuado.TabIndex = 5;
            checkDescontinuado.Text = "Descontinuado";
            checkDescontinuado.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(607, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(159, 192);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // udPreco
            // 
            udPreco.DecimalPlaces = 2;
            udPreco.Location = new Point(98, 111);
            udPreco.Name = "udPreco";
            udPreco.Size = new Size(120, 23);
            udPreco.TabIndex = 8;
            // 
            // udClassDesconto
            // 
            udClassDesconto.DecimalPlaces = 2;
            udClassDesconto.Location = new Point(375, 194);
            udClassDesconto.Name = "udClassDesconto";
            udClassDesconto.Size = new Size(120, 23);
            udClassDesconto.TabIndex = 8;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(824, 33);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(934, 184);
            listBox1.TabIndex = 9;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // udEstqMinimo
            // 
            udEstqMinimo.DecimalPlaces = 2;
            udEstqMinimo.Location = new Point(127, 192);
            udEstqMinimo.Name = "udEstqMinimo";
            udEstqMinimo.Size = new Size(120, 23);
            udEstqMinimo.TabIndex = 8;
            // 
            // FrmProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1787, 551);
            Controls.Add(listBox1);
            Controls.Add(udClassDesconto);
            Controls.Add(udEstqMinimo);
            Controls.Add(udPreco);
            Controls.Add(pictureBox1);
            Controls.Add(checkDescontinuado);
            Controls.Add(cbCategoria);
            Controls.Add(btnCarregarImg);
            Controls.Add(btnCancelar);
            Controls.Add(btnEditar);
            Controls.Add(btnSalvar);
            Controls.Add(btnBuscar);
            Controls.Add(lblUnidVenda);
            Controls.Add(lblCategoria);
            Controls.Add(lblClassDesconto);
            Controls.Add(lblEstqMinimo);
            Controls.Add(lblPreco);
            Controls.Add(lblDescricao);
            Controls.Add(lblCodBarras);
            Controls.Add(txtUnidVenda);
            Controls.Add(txtDescricao);
            Controls.Add(txtCodBarras);
            Name = "FrmProduto";
            Text = "Cadastro de Produtos";
            Load += FrmProduto_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)udPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)udClassDesconto).EndInit();
            ((System.ComponentModel.ISupportInitialize)udEstqMinimo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCodBarras;
        private TextBox txtDescricao;
        private TextBox txtUnidVenda;
        private Label lblCodBarras;
        private Label lblDescricao;
        private Label lblPreco;
        private Button btnBuscar;
        private Label lblUnidVenda;
        private ComboBox cbCategoria;
        private Label lblCategoria;
        private Label lblEstqMinimo;
        private Label lblClassDesconto;
        private Button btnSalvar;
        private Button btnEditar;
        private Button btnCancelar;
        private Button btnCarregarImg;
        private CheckBox checkDescontinuado;
        private PictureBox pictureBox1;
        private NumericUpDown udPreco;
        private NumericUpDown udClassDesconto;
        private ListBox listBox1;
        private NumericUpDown udEstqMinimo;
    }
}