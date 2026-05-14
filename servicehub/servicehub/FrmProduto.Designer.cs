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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            checkBox1 = new CheckBox();
            pictureBox1 = new PictureBox();
            domainUpDown1 = new DomainUpDown();
            domainUpDown2 = new DomainUpDown();
            domainUpDown3 = new DomainUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(94, 33);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Código de Barras";
            textBox1.Size = new Size(233, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(94, 72);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Descrição";
            textBox2.Size = new Size(401, 23);
            textBox2.TabIndex = 0;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(372, 112);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Unid. Venda";
            textBox3.Size = new Size(123, 23);
            textBox3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 36);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 1;
            label1.Text = "CodBarras";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 75);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Descrição";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 112);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 1;
            label3.Text = "Preço";
            label3.Click += label3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(397, 33);
            button1.Name = "button1";
            button1.Size = new Size(98, 26);
            button1.TabIndex = 2;
            button1.Text = "&Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(271, 115);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 1;
            label4.Text = "Unidade Venda";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(93, 150);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(402, 23);
            comboBox1.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 153);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 1;
            label5.Text = "Categoria";
            label5.Click += label3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 194);
            label6.Name = "label6";
            label6.Size = new Size(94, 15);
            label6.TabIndex = 1;
            label6.Text = "Estoque Minímo";
            label6.Click += label3_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(271, 196);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 1;
            label7.Text = "Classe Desconto";
            label7.Click += label3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(127, 333);
            button2.Name = "button2";
            button2.Size = new Size(97, 46);
            button2.TabIndex = 2;
            button2.Text = "&Salvar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(398, 333);
            button3.Name = "button3";
            button3.Size = new Size(97, 46);
            button3.TabIndex = 2;
            button3.Text = "&Editar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(641, 333);
            button4.Name = "button4";
            button4.Size = new Size(96, 46);
            button4.TabIndex = 2;
            button4.Text = "&Cancelar";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(607, 234);
            button5.Name = "button5";
            button5.Size = new Size(159, 29);
            button5.TabIndex = 2;
            button5.Text = "&Carregar Imagem";
            button5.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(389, 240);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(106, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Descontinuado";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(607, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(159, 192);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // domainUpDown1
            // 
            domainUpDown1.Location = new Point(94, 113);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new Size(120, 23);
            domainUpDown1.TabIndex = 7;
            domainUpDown1.Text = "0,00";
            // 
            // domainUpDown2
            // 
            domainUpDown2.Location = new Point(127, 192);
            domainUpDown2.Name = "domainUpDown2";
            domainUpDown2.Size = new Size(120, 23);
            domainUpDown2.TabIndex = 7;
            domainUpDown2.Text = "0,00";
            // 
            // domainUpDown3
            // 
            domainUpDown3.Location = new Point(375, 192);
            domainUpDown3.Name = "domainUpDown3";
            domainUpDown3.Size = new Size(120, 23);
            domainUpDown3.TabIndex = 7;
            domainUpDown3.Text = "0,00";
            // 
            // FrmProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 551);
            Controls.Add(domainUpDown3);
            Controls.Add(domainUpDown2);
            Controls.Add(domainUpDown1);
            Controls.Add(pictureBox1);
            Controls.Add(checkBox1);
            Controls.Add(comboBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "FrmProduto";
            Text = "FrmProduto";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Label label4;
        private ComboBox comboBox1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private CheckBox checkBox1;
        private PictureBox pictureBox1;
        private DomainUpDown domainUpDown1;
        private DomainUpDown domainUpDown2;
        private DomainUpDown domainUpDown3;
    }
}