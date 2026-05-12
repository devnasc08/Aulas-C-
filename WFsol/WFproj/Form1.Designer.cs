namespace WFproj
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblnome = new Label();
            txtNome = new TextBox();
            button1 = new Button();
            txtN1 = new TextBox();
            txtN2 = new TextBox();
            lblN1 = new Label();
            lblN2 = new Label();
            txtAdicao = new TextBox();
            txtResultad = new Label();
            txtCalcular = new Label();
            buttonCalcular = new Button();
            txtSubtracao = new TextBox();
            txtMultiplicacao = new TextBox();
            txtDivisao = new TextBox();
            lblAdicao = new Label();
            lblSubtracao = new Label();
            lblMultiplicacao = new Label();
            lblDivisao = new Label();
            txtMaior = new TextBox();
            lblMaior = new Label();
            txtMenor = new TextBox();
            lblMenor = new Label();
            SuspendLayout();
            // 
            // lblnome
            // 
            lblnome.AutoSize = true;
            lblnome.Location = new Point(35, 43);
            lblnome.Name = "lblnome";
            lblnome.Size = new Size(40, 15);
            lblnome.TabIndex = 0;
            lblnome.Text = "Nome";
            lblnome.Click += label1_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(35, 61);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Digite seu nome";
            txtNome.Size = new Size(176, 23);
            txtNome.TabIndex = 1;
            txtNome.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(305, 61);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "&Enviar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtN1
            // 
            txtN1.Location = new Point(35, 143);
            txtN1.Name = "txtN1";
            txtN1.Size = new Size(100, 23);
            txtN1.TabIndex = 3;
            txtN1.TextChanged += n1_TextChanged;
            // 
            // txtN2
            // 
            txtN2.Location = new Point(141, 143);
            txtN2.Name = "txtN2";
            txtN2.Size = new Size(100, 23);
            txtN2.TabIndex = 4;
            txtN2.TextChanged += textBox2_TextChanged;
            // 
            // lblN1
            // 
            lblN1.AutoSize = true;
            lblN1.Location = new Point(37, 125);
            lblN1.Name = "lblN1";
            lblN1.Size = new Size(40, 15);
            lblN1.TabIndex = 5;
            lblN1.Text = "Num1";
            // 
            // lblN2
            // 
            lblN2.AutoSize = true;
            lblN2.Location = new Point(141, 125);
            lblN2.Name = "lblN2";
            lblN2.Size = new Size(40, 15);
            lblN2.TabIndex = 6;
            lblN2.Text = "Num2";
            lblN2.Click += label2_Click;
            // 
            // txtAdicao
            // 
            txtAdicao.Location = new Point(144, 263);
            txtAdicao.Name = "txtAdicao";
            txtAdicao.Size = new Size(100, 23);
            txtAdicao.TabIndex = 8;
            txtAdicao.TextChanged += textBox3_TextChanged;
            // 
            // txtResultad
            // 
            txtResultad.AutoSize = true;
            txtResultad.Location = new Point(53, 271);
            txtResultad.Name = "txtResultad";
            txtResultad.Size = new Size(59, 15);
            txtResultad.TabIndex = 9;
            txtResultad.Text = "Resultado";
            txtResultad.Click += label1_Click_1;
            // 
            // txtCalcular
            // 
            txtCalcular.AutoSize = true;
            txtCalcular.Location = new Point(264, 125);
            txtCalcular.Name = "txtCalcular";
            txtCalcular.Size = new Size(50, 15);
            txtCalcular.TabIndex = 10;
            txtCalcular.Text = "Calcular";
            txtCalcular.Click += label1_Click_2;
            // 
            // buttonCalcular
            // 
            buttonCalcular.Location = new Point(264, 143);
            buttonCalcular.Name = "buttonCalcular";
            buttonCalcular.Size = new Size(75, 23);
            buttonCalcular.TabIndex = 11;
            buttonCalcular.Text = "Calcular";
            buttonCalcular.UseVisualStyleBackColor = true;
            buttonCalcular.Click += buttonCalcular_Click;
            // 
            // txtSubtracao
            // 
            txtSubtracao.Location = new Point(264, 263);
            txtSubtracao.Name = "txtSubtracao";
            txtSubtracao.Size = new Size(100, 23);
            txtSubtracao.TabIndex = 8;
            txtSubtracao.TextChanged += textBox3_TextChanged;
            // 
            // txtMultiplicacao
            // 
            txtMultiplicacao.Location = new Point(389, 263);
            txtMultiplicacao.Name = "txtMultiplicacao";
            txtMultiplicacao.Size = new Size(100, 23);
            txtMultiplicacao.TabIndex = 8;
            txtMultiplicacao.TextChanged += textBox3_TextChanged;
            // 
            // txtDivisao
            // 
            txtDivisao.Location = new Point(518, 263);
            txtDivisao.Name = "txtDivisao";
            txtDivisao.Size = new Size(100, 23);
            txtDivisao.TabIndex = 8;
            txtDivisao.TextChanged += textBox3_TextChanged;
            // 
            // lblAdicao
            // 
            lblAdicao.AutoSize = true;
            lblAdicao.Location = new Point(144, 245);
            lblAdicao.Name = "lblAdicao";
            lblAdicao.Size = new Size(44, 15);
            lblAdicao.TabIndex = 9;
            lblAdicao.Text = "Adição";
            lblAdicao.Click += label1_Click_1;
            // 
            // lblSubtracao
            // 
            lblSubtracao.AutoSize = true;
            lblSubtracao.Location = new Point(264, 245);
            lblSubtracao.Name = "lblSubtracao";
            lblSubtracao.Size = new Size(60, 15);
            lblSubtracao.TabIndex = 9;
            lblSubtracao.Text = "Subtração";
            lblSubtracao.Click += label1_Click_1;
            // 
            // lblMultiplicacao
            // 
            lblMultiplicacao.AutoSize = true;
            lblMultiplicacao.Location = new Point(389, 245);
            lblMultiplicacao.Name = "lblMultiplicacao";
            lblMultiplicacao.Size = new Size(79, 15);
            lblMultiplicacao.TabIndex = 9;
            lblMultiplicacao.Text = "Multiplicação";
            lblMultiplicacao.Click += label1_Click_1;
            // 
            // lblDivisao
            // 
            lblDivisao.AutoSize = true;
            lblDivisao.Location = new Point(518, 245);
            lblDivisao.Name = "lblDivisao";
            lblDivisao.Size = new Size(45, 15);
            lblDivisao.TabIndex = 9;
            lblDivisao.Text = "Divisão";
            lblDivisao.Click += label1_Click_1;
            // 
            // txtMaior
            // 
            txtMaior.Location = new Point(674, 263);
            txtMaior.Name = "txtMaior";
            txtMaior.Size = new Size(100, 23);
            txtMaior.TabIndex = 8;
            txtMaior.TextChanged += textBox3_TextChanged;
            // 
            // lblMaior
            // 
            lblMaior.AutoSize = true;
            lblMaior.Location = new Point(674, 245);
            lblMaior.Name = "lblMaior";
            lblMaior.Size = new Size(38, 15);
            lblMaior.TabIndex = 9;
            lblMaior.Text = "Maior";
            lblMaior.Click += label1_Click_1;
            // 
            // txtMenor
            // 
            txtMenor.Location = new Point(796, 263);
            txtMenor.Name = "txtMenor";
            txtMenor.Size = new Size(100, 23);
            txtMenor.TabIndex = 8;
            txtMenor.TextChanged += textBox3_TextChanged;
            // 
            // lblMenor
            // 
            lblMenor.AutoSize = true;
            lblMenor.Location = new Point(796, 245);
            lblMenor.Name = "lblMenor";
            lblMenor.Size = new Size(42, 15);
            lblMenor.TabIndex = 9;
            lblMenor.Text = "Menor";
            lblMenor.Click += label1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1220, 661);
            Controls.Add(buttonCalcular);
            Controls.Add(txtCalcular);
            Controls.Add(lblMenor);
            Controls.Add(lblMaior);
            Controls.Add(lblDivisao);
            Controls.Add(lblMultiplicacao);
            Controls.Add(lblSubtracao);
            Controls.Add(lblAdicao);
            Controls.Add(txtResultad);
            Controls.Add(txtMenor);
            Controls.Add(txtMaior);
            Controls.Add(txtDivisao);
            Controls.Add(txtMultiplicacao);
            Controls.Add(txtSubtracao);
            Controls.Add(txtAdicao);
            Controls.Add(lblN2);
            Controls.Add(lblN1);
            Controls.Add(txtN2);
            Controls.Add(txtN1);
            Controls.Add(button1);
            Controls.Add(txtNome);
            Controls.Add(lblnome);
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblnome;
        private TextBox txtNome;
        private Button button1;
        private TextBox txtN1;
        private TextBox txtN2;
        private Label lblN1;
        private Label lblN2;
        private TextBox txtAdicao;
        private Label txtResultad;
        private Label txtCalcular;
        private Button buttonCalcular;
        private TextBox txtSubtracao;
        private TextBox txtMultiplicacao;
        private TextBox txtDivisao;
        private Label lblAdicao;
        private Label lblSubtracao;
        private Label lblMultiplicacao;
        private Label lblDivisao;
        private TextBox txtMaior;
        private Label lblMaior;
        private TextBox txtMenor;
        private Label lblMenor;
    }
}
