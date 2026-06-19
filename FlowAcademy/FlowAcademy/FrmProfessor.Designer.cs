namespace FlowAcademyF
{
    partial class FrmProfessor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProfessor));
            cmbUser = new ComboBox();
            dgvAluno = new DataGridView();
            txtEspecialidade = new TextBox();
            label7 = new Label();
            txtCpf = new TextBox();
            label5 = new Label();
            label2 = new Label();
            btnEditar = new Button();
            btnSalvar = new Button();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAluno).BeginInit();
            SuspendLayout();
            // 
            // cmbUser
            // 
            cmbUser.FormattingEnabled = true;
            cmbUser.Location = new Point(31, 46);
            cmbUser.Name = "cmbUser";
            cmbUser.Size = new Size(121, 23);
            cmbUser.TabIndex = 31;
            // 
            // dgvAluno
            // 
            dgvAluno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAluno.Location = new Point(101, 363);
            dgvAluno.Name = "dgvAluno";
            dgvAluno.Size = new Size(668, 243);
            dgvAluno.TabIndex = 25;
            // 
            // txtEspecialidade
            // 
            txtEspecialidade.Location = new Point(31, 142);
            txtEspecialidade.Name = "txtEspecialidade";
            txtEspecialidade.Size = new Size(130, 23);
            txtEspecialidade.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(31, 122);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 18;
            label7.Text = "Especialidade";
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(31, 94);
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(130, 23);
            txtCpf.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 74);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 16;
            label5.Text = "CPF";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 26);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 19;
            label2.Text = "Usuário";
            // 
            // btnEditar
            // 
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold);
            btnEditar.Image = FlowAcademy.Properties.Resources._1410220563_05_Edit_32x32;
            btnEditar.Location = new Point(283, 279);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(97, 64);
            btnEditar.TabIndex = 35;
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
            btnSalvar.Location = new Point(138, 279);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(97, 64);
            btnSalvar.TabIndex = 34;
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
            button4.Location = new Point(428, 276);
            button4.Name = "button4";
            button4.Size = new Size(93, 67);
            button4.TabIndex = 33;
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
            button5.Location = new Point(569, 276);
            button5.Name = "button5";
            button5.Size = new Size(93, 67);
            button5.TabIndex = 32;
            button5.Text = "E&xcluir";
            button5.TextImageRelation = TextImageRelation.ImageAboveText;
            button5.UseVisualStyleBackColor = true;
            // 
            // FrmProfessor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 618);
            Controls.Add(btnEditar);
            Controls.Add(btnSalvar);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(cmbUser);
            Controls.Add(dgvAluno);
            Controls.Add(txtEspecialidade);
            Controls.Add(label7);
            Controls.Add(txtCpf);
            Controls.Add(label5);
            Controls.Add(label2);
            Name = "FrmProfessor";
            Text = "FrmProfessor";
            ((System.ComponentModel.ISupportInitialize)dgvAluno).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbUser;
        private DataGridView dgvAluno;
        private TextBox txtEspecialidade;
        private Label label7;
        private TextBox txtCpf;
        private Label label5;
        private Label label2;
        private Button btnEditar;
        private Button btnSalvar;
        private Button button4;
        private Button button5;
    }
}