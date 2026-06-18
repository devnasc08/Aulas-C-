namespace FlowAcademyF
{
    partial class FrmMatricula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMatricula));
            dateTimePicker1 = new DateTimePicker();
            comboBox2 = new ComboBox();
            comboBox5 = new ComboBox();
            comboBox4 = new ComboBox();
            comboBox1 = new ComboBox();
            btnCancelar = new Button();
            btnExcluir = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            dgvAluno = new DataGridView();
            label6 = new Label();
            label9 = new Label();
            label1 = new Label();
            label8 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAluno).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(445, 26);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 70;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(260, 26);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 66;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(524, 111);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(121, 23);
            comboBox5.TabIndex = 65;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(83, 111);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(121, 23);
            comboBox4.TabIndex = 64;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(83, 26);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 63;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 128);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(573, 232);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(99, 67);
            btnCancelar.TabIndex = 62;
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
            btnExcluir.Location = new Point(430, 232);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(99, 67);
            btnExcluir.TabIndex = 61;
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
            btnEdit.Location = new Point(287, 232);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(99, 67);
            btnEdit.TabIndex = 60;
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
            btnAdd.Location = new Point(144, 232);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(99, 67);
            btnAdd.TabIndex = 59;
            btnAdd.Text = "&Adiocionar";
            btnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // dgvAluno
            // 
            dgvAluno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAluno.Location = new Point(66, 329);
            dgvAluno.Name = "dgvAluno";
            dgvAluno.Size = new Size(668, 243);
            dgvAluno.TabIndex = 58;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(445, 8);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 55;
            label6.Text = "Data Matrícula";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(524, 92);
            label9.Name = "label9";
            label9.Size = new Size(34, 15);
            label9.TabIndex = 53;
            label9.Text = "Ativa";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(260, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 52;
            label1.Text = "Turma";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(83, 92);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 51;
            label8.Text = "Status";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(84, 8);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 50;
            label4.Text = "Aluno";
            // 
            // FrmMatricula
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 581);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox5);
            Controls.Add(comboBox4);
            Controls.Add(comboBox1);
            Controls.Add(btnCancelar);
            Controls.Add(btnExcluir);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvAluno);
            Controls.Add(label6);
            Controls.Add(label9);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(label4);
            Name = "FrmMatricula";
            Text = "FrmMatricula";
            ((System.ComponentModel.ISupportInitialize)dgvAluno).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox2;
        private ComboBox comboBox5;
        private ComboBox comboBox4;
        private ComboBox comboBox1;
        private Button btnCancelar;
        private Button btnExcluir;
        private Button btnEdit;
        private Button btnAdd;
        private DataGridView dgvAluno;
        private Label label6;
        private Label label9;
        private Label label1;
        private Label label8;
        private Label label4;
    }
}