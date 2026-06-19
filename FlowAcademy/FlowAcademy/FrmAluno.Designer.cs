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
            cmbUser = new ComboBox();
            btnEditar = new Button();
            btnSalvar = new Button();
            button4 = new Button();
            button5 = new Button();
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
            // cmbUser
            // 
            cmbUser.FormattingEnabled = true;
            cmbUser.Location = new Point(43, 42);
            cmbUser.Name = "cmbUser";
            cmbUser.Size = new Size(121, 23);
            cmbUser.TabIndex = 14;
            // 
            // btnEditar
            // 
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold);
            btnEditar.Image = Properties.Resources._1410220563_05_Edit_32x32;
            btnEditar.Location = new Point(339, 287);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(97, 64);
            btnEditar.TabIndex = 20;
            btnEditar.Text = "&Editar";
            btnEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.FlatAppearance.MouseDownBackColor = Color.Lime;
            btnSalvar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold);
            btnSalvar.Image = (Image)resources.GetObject("btnSalvar.Image");
            btnSalvar.Location = new Point(194, 287);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(97, 64);
            btnSalvar.TabIndex = 19;
            btnSalvar.Text = "&Salvar";
            btnSalvar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalvar.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 128);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            button4.ForeColor = Color.Black;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(484, 284);
            button4.Name = "button4";
            button4.Size = new Size(93, 67);
            button4.TabIndex = 18;
            button4.Text = "&Cancelar";
            button4.TextImageRelation = TextImageRelation.ImageAboveText;
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = Color.Red;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            button5.ForeColor = Color.Black;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.Location = new Point(625, 284);
            button5.Name = "button5";
            button5.Size = new Size(93, 67);
            button5.TabIndex = 17;
            button5.Text = "E&xcluir";
            button5.TextImageRelation = TextImageRelation.ImageAboveText;
            button5.UseVisualStyleBackColor = true;
            // 
            // FrmAluno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 635);
            Controls.Add(btnEditar);
            Controls.Add(btnSalvar);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(cmbUser);
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
        private ComboBox cmbUser;
        private Button btnEditar;
        private Button btnSalvar;
        private Button button4;
        private Button button5;
    }
}