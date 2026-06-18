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
            comboBox1 = new ComboBox();
            btnCancelar = new Button();
            btnExcluir = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            dgvAluno = new DataGridView();
            txtTelefone = new TextBox();
            label7 = new Label();
            txtCpf = new TextBox();
            label5 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAluno).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(31, 46);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 31;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 128);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(594, 280);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(99, 67);
            btnCancelar.TabIndex = 30;
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
            btnExcluir.Location = new Point(451, 280);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(99, 67);
            btnExcluir.TabIndex = 29;
            btnExcluir.Text = "E&xcluir";
            btnExcluir.TextImageRelation = TextImageRelation.ImageAboveText;
            btnExcluir.UseVisualStyleBackColor = true;
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
            btnEdit.Location = new Point(308, 280);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(99, 67);
            btnEdit.TabIndex = 27;
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
            btnAdd.Location = new Point(165, 280);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(99, 67);
            btnAdd.TabIndex = 26;
            btnAdd.Text = "&Adiocionar";
            btnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // dgvAluno
            // 
            dgvAluno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAluno.Location = new Point(101, 363);
            dgvAluno.Name = "dgvAluno";
            dgvAluno.Size = new Size(668, 243);
            dgvAluno.TabIndex = 25;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(31, 142);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(130, 23);
            txtTelefone.TabIndex = 22;
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
            // FrmProfessor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 618);
            Controls.Add(comboBox1);
            Controls.Add(btnCancelar);
            Controls.Add(btnExcluir);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvAluno);
            Controls.Add(txtTelefone);
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

        private ComboBox comboBox1;
        private Button btnCancelar;
        private Button btnExcluir;
        private Button btnEdit;
        private Button btnAdd;
        private DataGridView dgvAluno;
        private TextBox txtTelefone;
        private Label label7;
        private TextBox txtCpf;
        private Label label5;
        private Label label2;
    }
}