namespace FlowAcademy
{
    partial class FrmAluno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAluno));
            label1 = new Label();
            label2 = new Label();
            dgvAluno = new DataGridView();
            label5 = new Label();
            txtCpf = new TextBox();
            label6 = new Label();
            txtMatricula = new TextBox();
            label7 = new Label();
            txtTelefone = new TextBox();
            label8 = new Label();
            txtEndereco = new TextBox();
            btnCancelar = new Button();
            btnExcluir = new Button();
            btnPesquisar = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvAluno).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(333, 9);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Cadastro de Alunos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 22);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 1;
            label2.Text = "Usuário";
            // 
            // dgvAluno
            // 
            dgvAluno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAluno.Location = new Point(113, 359);
            dgvAluno.Name = "dgvAluno";
            dgvAluno.Size = new Size(668, 243);
            dgvAluno.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 70);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 1;
            label5.Text = "CPF";
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(43, 90);
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(130, 23);
            txtCpf.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 166);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 1;
            label6.Text = "Matricula";
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(43, 186);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(130, 23);
            txtMatricula.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(43, 118);
            label7.Name = "label7";
            label7.Size = new Size(52, 15);
            label7.TabIndex = 1;
            label7.Text = "Telefone";
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(43, 138);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(130, 23);
            txtTelefone.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(43, 214);
            label8.Name = "label8";
            label8.Size = new Size(56, 15);
            label8.TabIndex = 1;
            label8.Text = "Endereco";
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(43, 234);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(130, 23);
            txtEndereco.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 128);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(608, 276);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(99, 67);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.FlatAppearance.BorderSize = 0;
            btnExcluir.FlatAppearance.MouseDownBackColor = Color.Red;
            btnExcluir.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnExcluir.ForeColor = Color.Black;
            btnExcluir.Location = new Point(489, 276);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(99, 67);
            btnExcluir.TabIndex = 12;
            btnExcluir.Text = "E&xcluir";
            btnExcluir.TextImageRelation = TextImageRelation.ImageAboveText;
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnPesquisar
            // 
            btnPesquisar.FlatAppearance.BorderSize = 0;
            btnPesquisar.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnPesquisar.FlatAppearance.MouseOverBackColor = Color.DodgerBlue;
            btnPesquisar.FlatStyle = FlatStyle.Flat;
            btnPesquisar.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnPesquisar.ForeColor = Color.Black;
            btnPesquisar.Location = new Point(385, 276);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(99, 67);
            btnPesquisar.TabIndex = 11;
            btnPesquisar.Text = "&Pesquisar";
            btnPesquisar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnEdit.ForeColor = Color.Black;
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.Location = new Point(281, 276);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(99, 67);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "&Editar";
            btnEdit.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatAppearance.MouseDownBackColor = Color.Lime;
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.Black;
            btnAdd.Location = new Point(177, 276);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(99, 67);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "&Adiocionar";
            btnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(43, 42);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 14;
            // 
            // FrmAluno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 635);
            Controls.Add(comboBox1);
            Controls.Add(btnCancelar);
            Controls.Add(btnExcluir);
            Controls.Add(btnPesquisar);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvAluno);
            Controls.Add(txtEndereco);
            Controls.Add(label8);
            Controls.Add(txtTelefone);
            Controls.Add(label7);
            Controls.Add(txtMatricula);
            Controls.Add(label6);
            Controls.Add(txtCpf);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmAluno";
            Text = "FrmAluno";
            Load += FrmAluno_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAluno).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView dgvAluno;
        private Label label5;
        private TextBox txtCpf;
        private Label label6;
        private TextBox txtMatricula;
        private Label label7;
        private TextBox txtTelefone;
        private Label label8;
        private TextBox txtEndereco;
        private Button btnCancelar;
        private Button btnExcluir;
        private Button btnPesquisar;
        private Button btnEdit;
        private Button btnAdd;
        private ComboBox comboBox1;
    }
}