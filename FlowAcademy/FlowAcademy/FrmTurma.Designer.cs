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
            cmbCurso = new ComboBox();
            dgvTurma = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            cmbProfessor = new ComboBox();
            txtCodTurma = new TextBox();
            label2 = new Label();
            cmbTurno = new ComboBox();
            nudCapacidade = new NumericUpDown();
            label5 = new Label();
            label8 = new Label();
            txtStatus = new ComboBox();
            btnEditar = new Button();
            btnSalvar = new Button();
            button4 = new Button();
            button5 = new Button();
            txtPeriodoLetivo = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTurma).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacidade).BeginInit();
            SuspendLayout();
            // 
            // cmbCurso
            // 
            cmbCurso.FormattingEnabled = true;
            cmbCurso.Location = new Point(70, 46);
            cmbCurso.Name = "cmbCurso";
            cmbCurso.Size = new Size(178, 23);
            cmbCurso.TabIndex = 45;
            // 
            // dgvTurma
            // 
            dgvTurma.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurma.Location = new Point(70, 338);
            dgvTurma.Name = "dgvTurma";
            dgvTurma.Size = new Size(667, 131);
            dgvTurma.TabIndex = 39;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 124);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 35;
            label3.Text = "Código Turma";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(71, 28);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 36;
            label4.Text = "Curso";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(343, 28);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 36;
            label1.Text = "Professor";
            // 
            // cmbProfessor
            // 
            cmbProfessor.FormattingEnabled = true;
            cmbProfessor.Location = new Point(343, 46);
            cmbProfessor.Name = "cmbProfessor";
            cmbProfessor.Size = new Size(197, 23);
            cmbProfessor.TabIndex = 45;
            // 
            // txtCodTurma
            // 
            txtCodTurma.Location = new Point(71, 144);
            txtCodTurma.Name = "txtCodTurma";
            txtCodTurma.Size = new Size(100, 23);
            txtCodTurma.TabIndex = 46;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(616, 29);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 36;
            label2.Text = "Turno";
            // 
            // cmbTurno
            // 
            cmbTurno.FormattingEnabled = true;
            cmbTurno.Location = new Point(616, 46);
            cmbTurno.Name = "cmbTurno";
            cmbTurno.Size = new Size(121, 23);
            cmbTurno.TabIndex = 45;
            // 
            // nudCapacidade
            // 
            nudCapacidade.Location = new Point(614, 144);
            nudCapacidade.Name = "nudCapacidade";
            nudCapacidade.Size = new Size(100, 23);
            nudCapacidade.TabIndex = 47;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(614, 124);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 36;
            label5.Text = "Capacidade";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(252, 124);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 36;
            label8.Text = "Status";
            // 
            // txtStatus
            // 
            txtStatus.FormattingEnabled = true;
            txtStatus.Location = new Point(252, 142);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(100, 23);
            txtStatus.TabIndex = 45;
            // 
            // btnEditar
            // 
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold);
            btnEditar.Image = FlowAcademy.Properties.Resources._1410220563_05_Edit_32x32;
            btnEditar.Location = new Point(283, 266);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(97, 64);
            btnEditar.TabIndex = 52;
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
            btnSalvar.Location = new Point(138, 266);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(97, 64);
            btnSalvar.TabIndex = 51;
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
            button4.Location = new Point(428, 263);
            button4.Name = "button4";
            button4.Size = new Size(93, 67);
            button4.TabIndex = 50;
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
            button5.Location = new Point(569, 263);
            button5.Name = "button5";
            button5.Size = new Size(93, 67);
            button5.TabIndex = 49;
            button5.Text = "E&xcluir";
            button5.TextImageRelation = TextImageRelation.ImageAboveText;
            button5.UseVisualStyleBackColor = true;
            // 
            // txtPeriodoLetivo
            // 
            txtPeriodoLetivo.Location = new Point(433, 144);
            txtPeriodoLetivo.Name = "txtPeriodoLetivo";
            txtPeriodoLetivo.Size = new Size(100, 23);
            txtPeriodoLetivo.TabIndex = 53;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(433, 124);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 36;
            label6.Text = "Periodo Letivo";
            // 
            // FrmTurma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 593);
            Controls.Add(txtPeriodoLetivo);
            Controls.Add(btnEditar);
            Controls.Add(btnSalvar);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(nudCapacidade);
            Controls.Add(txtCodTurma);
            Controls.Add(cmbTurno);
            Controls.Add(cmbProfessor);
            Controls.Add(txtStatus);
            Controls.Add(cmbCurso);
            Controls.Add(label2);
            Controls.Add(dgvTurma);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "FrmTurma";
            Text = "FrmTurma";
            Load += FrmTurma_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTurma).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacidade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCurso;
        private DataGridView dgvTurma;
        private Label label3;
        private Label label4;
        private Label label1;
        private ComboBox cmbProfessor;
        private TextBox txtCodTurma;
        private Label label2;
        private ComboBox cmbTurno;
        private NumericUpDown nudCapacidade;
        private Label label5;
        private Label label8;
        private ComboBox txtStatus;
        private Button btnEditar;
        private Button btnSalvar;
        private Button button4;
        private Button button5;
        private TextBox txtPeriodoLetivo;
        private Label label6;
    }
}