namespace FlowAcademyF
{
    partial class FrmDisciplina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDisciplina));
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            btnCancelar = new Button();
            btnExcluir = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            dgvAluno = new DataGridView();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAluno).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(99, 50);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 34;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(658, 50);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 33;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 128);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(578, 226);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(99, 67);
            btnCancelar.TabIndex = 32;
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
            btnExcluir.Location = new Point(435, 226);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(99, 67);
            btnExcluir.TabIndex = 31;
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
            btnEdit.Location = new Point(292, 226);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(99, 67);
            btnEdit.TabIndex = 30;
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
            btnAdd.Location = new Point(149, 226);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(99, 67);
            btnAdd.TabIndex = 29;
            btnAdd.Text = "&Adiocionar";
            btnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // dgvAluno
            // 
            dgvAluno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAluno.Location = new Point(71, 323);
            dgvAluno.Name = "dgvAluno";
            dgvAluno.Size = new Size(668, 243);
            dgvAluno.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(658, 32);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 22;
            label3.Text = "Carga Horária";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(266, 50);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(306, 23);
            textBox1.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(99, 32);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 24;
            label4.Text = "Curso";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(266, 32);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 25;
            label1.Text = "Nome";
            // 
            // FrmDisciplina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 597);
            Controls.Add(comboBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(btnCancelar);
            Controls.Add(btnExcluir);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvAluno);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label1);
            Name = "FrmDisciplina";
            Text = "FrmDisciplina";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAluno).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private Button btnCancelar;
        private Button btnExcluir;
        private Button btnEdit;
        private Button btnAdd;
        private DataGridView dgvAluno;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private Label label1;
    }
}