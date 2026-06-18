namespace FlowAcademyF
{
    partial class FrmFrequencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFrequencia));
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            btnCancelar = new Button();
            btnExcluir = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            label6 = new Label();
            dgvAluno = new DataGridView();
            label5 = new Label();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAluno).BeginInit();
            SuspendLayout();
            // 
            // textBox4
            // 
            textBox4.Location = new Point(83, 218);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 103;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(84, 92);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 102;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(83, 154);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 100;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(346, 26);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 99;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(83, 26);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 98;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 128);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(591, 271);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(99, 67);
            btnCancelar.TabIndex = 97;
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
            btnExcluir.Location = new Point(448, 271);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(99, 67);
            btnExcluir.TabIndex = 96;
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
            btnEdit.Location = new Point(305, 271);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(99, 67);
            btnEdit.TabIndex = 95;
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
            btnAdd.Location = new Point(162, 271);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(99, 67);
            btnAdd.TabIndex = 94;
            btnAdd.Text = "&Adiocionar";
            btnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(83, 200);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 90;
            label6.Text = "Presenças";
            // 
            // dgvAluno
            // 
            dgvAluno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAluno.Location = new Point(84, 368);
            dgvAluno.Name = "dgvAluno";
            dgvAluno.Size = new Size(668, 243);
            dgvAluno.TabIndex = 93;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(84, 74);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 89;
            label5.Text = "Total de Aulas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(346, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 92;
            label1.Text = "Disciplina";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 136);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 91;
            label2.Text = "Percentual";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(84, 8);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 87;
            label4.Text = "Matrícula";
            // 
            // FrmFrequencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 644);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(btnCancelar);
            Controls.Add(btnExcluir);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(label6);
            Controls.Add(dgvAluno);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label4);
            Name = "FrmFrequencia";
            Text = "FrmFrequencia";
            ((System.ComponentModel.ISupportInitialize)dgvAluno).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button btnCancelar;
        private Button btnExcluir;
        private Button btnEdit;
        private Button btnAdd;
        private Label label6;
        private DataGridView dgvAluno;
        private Label label5;
        private Label label1;
        private Label label2;
        private Label label4;
    }
}