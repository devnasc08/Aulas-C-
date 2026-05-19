namespace Servicehub
{
    partial class FrmComponente
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
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            statusStrip1 = new StatusStrip();
            listBox1 = new ListBox();
            button2 = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            textBox2 = new TextBox();
            dgvServicos = new DataGridView();
            clnId = new DataGridViewTextBoxColumn();
            clnNome = new DataGridViewTextBoxColumn();
            clnDescricao = new DataGridViewTextBoxColumn();
            clnPreco = new DataGridViewTextBoxColumn();
            clnDescontinuado = new DataGridViewTextBoxColumn();
            dgvUsers = new DataGridView();
            usersId = new DataGridViewTextBoxColumn();
            usersNome = new DataGridViewTextBoxColumn();
            usersEmail = new DataGridViewTextBoxColumn();
            dgvSolicitacoes = new DataGridView();
            slcId = new DataGridViewTextBoxColumn();
            slcDescricaoProblema = new DataGridViewTextBoxColumn();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvServicos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitacoes).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 205);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Calcular";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 114);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 1;
            label1.Text = "Digite o(s) número(s)";
            label1.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(41, 132);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(54, 23);
            textBox1.TabIndex = 2;
            textBox1.Visible = false;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 727);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1370, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(215, 52);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(261, 319);
            listBox1.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(118, 205);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 0;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Multiplicação", "Divisão", "Adição", "Subtração", "Exponenciação", "Tabuada", "Radiciação" });
            comboBox1.Location = new Point(39, 70);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 52);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 6;
            label2.Text = "Operação";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(106, 132);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(54, 23);
            textBox2.TabIndex = 7;
            textBox2.Visible = false;
            // 
            // dgvServicos
            // 
            dgvServicos.AllowUserToAddRows = false;
            dgvServicos.AllowUserToDeleteRows = false;
            dgvServicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServicos.Columns.AddRange(new DataGridViewColumn[] { clnId, clnNome, clnDescricao, clnPreco, clnDescontinuado });
            dgvServicos.Location = new Point(521, 18);
            dgvServicos.Name = "dgvServicos";
            dgvServicos.ReadOnly = true;
            dgvServicos.RowHeadersVisible = false;
            dgvServicos.Size = new Size(659, 210);
            dgvServicos.TabIndex = 8;
            // 
            // clnId
            // 
            clnId.Frozen = true;
            clnId.HeaderText = "id";
            clnId.Name = "clnId";
            clnId.ReadOnly = true;
            clnId.Width = 40;
            // 
            // clnNome
            // 
            clnNome.Frozen = true;
            clnNome.HeaderText = "Nome";
            clnNome.Name = "clnNome";
            clnNome.ReadOnly = true;
            clnNome.Width = 200;
            // 
            // clnDescricao
            // 
            clnDescricao.Frozen = true;
            clnDescricao.HeaderText = "Descricao";
            clnDescricao.Name = "clnDescricao";
            clnDescricao.ReadOnly = true;
            clnDescricao.Width = 206;
            // 
            // clnPreco
            // 
            clnPreco.Frozen = true;
            clnPreco.HeaderText = "Preco";
            clnPreco.Name = "clnPreco";
            clnPreco.ReadOnly = true;
            // 
            // clnDescontinuado
            // 
            clnDescontinuado.Frozen = true;
            clnDescontinuado.HeaderText = "Descontinuado";
            clnDescontinuado.Name = "clnDescontinuado";
            clnDescontinuado.ReadOnly = true;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { usersId, usersNome, usersEmail });
            dgvUsers.Location = new Point(521, 234);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.Size = new Size(494, 153);
            dgvUsers.TabIndex = 9;
            // 
            // usersId
            // 
            usersId.Frozen = true;
            usersId.HeaderText = "Id";
            usersId.Name = "usersId";
            usersId.ReadOnly = true;
            usersId.Width = 50;
            // 
            // usersNome
            // 
            usersNome.HeaderText = "Nome";
            usersNome.Name = "usersNome";
            usersNome.ReadOnly = true;
            usersNome.Width = 200;
            // 
            // usersEmail
            // 
            usersEmail.HeaderText = "Email";
            usersEmail.Name = "usersEmail";
            usersEmail.ReadOnly = true;
            usersEmail.Width = 200;
            // 
            // dgvSolicitacoes
            // 
            dgvSolicitacoes.AllowUserToAddRows = false;
            dgvSolicitacoes.AllowUserToDeleteRows = false;
            dgvSolicitacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSolicitacoes.Columns.AddRange(new DataGridViewColumn[] { slcId, slcDescricaoProblema });
            dgvSolicitacoes.Location = new Point(509, 431);
            dgvSolicitacoes.Name = "dgvSolicitacoes";
            dgvSolicitacoes.ReadOnly = true;
            dgvSolicitacoes.RowHeadersVisible = false;
            dgvSolicitacoes.Size = new Size(377, 173);
            dgvSolicitacoes.TabIndex = 10;
            // 
            // slcId
            // 
            slcId.Frozen = true;
            slcId.HeaderText = "Id";
            slcId.Name = "slcId";
            slcId.ReadOnly = true;
            slcId.Width = 50;
            // 
            // slcDescricaoProblema
            // 
            slcDescricaoProblema.Frozen = true;
            slcDescricaoProblema.HeaderText = "Descrição Problema";
            slcDescricaoProblema.Name = "slcDescricaoProblema";
            slcDescricaoProblema.ReadOnly = true;
            slcDescricaoProblema.Width = 200;
            // 
            // button3
            // 
            button3.Location = new Point(904, 581);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 11;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // FrmComponente
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button2;
            ClientSize = new Size(1370, 749);
            Controls.Add(button3);
            Controls.Add(dgvSolicitacoes);
            Controls.Add(dgvUsers);
            Controls.Add(dgvServicos);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(listBox1);
            Controls.Add(statusStrip1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FrmComponente";
            Text = "FrmComponente";
            Load += FrmComponente_Load;
            ((System.ComponentModel.ISupportInitialize)dgvServicos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitacoes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private StatusStrip statusStrip1;
        private ListBox listBox1;
        private Button button2;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox textBox2;
        private DataGridView dgvServicos;
        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn usersId;
        private DataGridViewTextBoxColumn usersNome;
        private DataGridViewTextBoxColumn usersEmail;
        private DataGridViewTextBoxColumn clnId;
        private DataGridViewTextBoxColumn clnNome;
        private DataGridViewTextBoxColumn clnDescricao;
        private DataGridViewTextBoxColumn clnPreco;
        private DataGridViewTextBoxColumn clnDescontinuado;
        private DataGridView dgvSolicitacoes;
        private DataGridViewTextBoxColumn slcId;
        private DataGridViewTextBoxColumn slcDescricaoProblema;
        private Button button3;
    }
}