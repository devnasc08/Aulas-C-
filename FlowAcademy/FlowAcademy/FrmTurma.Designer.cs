namespace FlowAcademyF
{
    partial class FrmTurma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTurma));
            comboBox1 = new ComboBox();
            btnCancelar = new Button();
            btnExcluir = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            dgvAluno = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
            label2 = new Label();
            comboBox3 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label6 = new Label();
            label7 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label8 = new Label();
            comboBox4 = new ComboBox();
            label9 = new Label();
            comboBox5 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvAluno).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(69, 46);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 45;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 128);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(559, 252);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(99, 67);
            btnCancelar.TabIndex = 43;
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
            btnExcluir.Location = new Point(416, 252);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(99, 67);
            btnExcluir.TabIndex = 42;
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
            btnEdit.Location = new Point(273, 252);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(99, 67);
            btnEdit.TabIndex = 41;
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
            btnAdd.Location = new Point(130, 252);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(99, 67);
            btnAdd.TabIndex = 40;
            btnAdd.Text = "&Adiocionar";
            btnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // dgvAluno
            // 
            dgvAluno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAluno.Location = new Point(52, 349);
            dgvAluno.Name = "dgvAluno";
            dgvAluno.Size = new Size(668, 243);
            dgvAluno.TabIndex = 39;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(451, 29);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 35;
            label3.Text = "Código Turma";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 28);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 36;
            label4.Text = "Curso";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(246, 29);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 36;
            label1.Text = "Professor";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(246, 46);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 45;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(451, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 46;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(590, 29);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 36;
            label2.Text = "Turno";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(590, 46);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 45;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(69, 112);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 47;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(68, 94);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 36;
            label5.Text = "Capacidade";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(220, 112);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 48;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(220, 94);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 36;
            label6.Text = "Data Início";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(474, 94);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 36;
            label7.Text = "Data Fim";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(474, 112);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 48;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(69, 175);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 36;
            label8.Text = "Status";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(69, 194);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(121, 23);
            comboBox4.TabIndex = 45;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(553, 175);
            label9.Name = "label9";
            label9.Size = new Size(34, 15);
            label9.TabIndex = 36;
            label9.Text = "Ativa";
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(553, 194);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(121, 23);
            comboBox5.TabIndex = 45;
            // 
            // FrmTurma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 593);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox5);
            Controls.Add(comboBox4);
            Controls.Add(comboBox1);
            Controls.Add(btnCancelar);
            Controls.Add(btnExcluir);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(label2);
            Controls.Add(label7);
            Controls.Add(dgvAluno);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label9);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "FrmTurma";
            Text = "FrmTurma";
            ((System.ComponentModel.ISupportInitialize)dgvAluno).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
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
        private Label label3;
        private Label label4;
        private Label label1;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private Label label2;
        private ComboBox comboBox3;
        private NumericUpDown numericUpDown1;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private Label label6;
        private Label label7;
        private DateTimePicker dateTimePicker2;
        private Label label8;
        private ComboBox comboBox4;
        private Label label9;
        private ComboBox comboBox5;
    }
}