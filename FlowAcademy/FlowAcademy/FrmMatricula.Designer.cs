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
            dtpMatricula = new DateTimePicker();
            cmbTurma = new ComboBox();
            cmbAtiva = new ComboBox();
            txtStatus = new ComboBox();
            cmbAluno = new ComboBox();
            dgvMatricula = new DataGridView();
            label6 = new Label();
            label9 = new Label();
            label1 = new Label();
            label8 = new Label();
            label4 = new Label();
            btnEditar = new Button();
            btnSalvar = new Button();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMatricula).BeginInit();
            SuspendLayout();
            // 
            // dtpMatricula
            // 
            dtpMatricula.Location = new Point(445, 26);
            dtpMatricula.Name = "dtpMatricula";
            dtpMatricula.Size = new Size(200, 23);
            dtpMatricula.TabIndex = 70;
            // 
            // cmbTurma
            // 
            cmbTurma.FormattingEnabled = true;
            cmbTurma.Location = new Point(260, 26);
            cmbTurma.Name = "cmbTurma";
            cmbTurma.Size = new Size(121, 23);
            cmbTurma.TabIndex = 66;
            // 
            // cmbAtiva
            // 
            cmbAtiva.FormattingEnabled = true;
            cmbAtiva.Location = new Point(524, 111);
            cmbAtiva.Name = "cmbAtiva";
            cmbAtiva.Size = new Size(121, 23);
            cmbAtiva.TabIndex = 65;
            // 
            // txtStatus
            // 
            txtStatus.FormattingEnabled = true;
            txtStatus.Location = new Point(83, 111);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(121, 23);
            txtStatus.TabIndex = 64;
            // 
            // cmbAluno
            // 
            cmbAluno.FormattingEnabled = true;
            cmbAluno.Location = new Point(83, 26);
            cmbAluno.Name = "cmbAluno";
            cmbAluno.Size = new Size(121, 23);
            cmbAluno.TabIndex = 63;
            // 
            // dgvMatricula
            // 
            dgvMatricula.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatricula.Location = new Point(66, 329);
            dgvMatricula.Name = "dgvMatricula";
            dgvMatricula.Size = new Size(668, 243);
            dgvMatricula.TabIndex = 58;
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
            // btnEditar
            // 
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold);
            btnEditar.Image = FlowAcademy.Properties.Resources._1410220563_05_Edit_32x32;
            btnEditar.Location = new Point(291, 245);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(97, 64);
            btnEditar.TabIndex = 74;
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
            btnSalvar.Location = new Point(146, 245);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(97, 64);
            btnSalvar.TabIndex = 73;
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
            button4.Location = new Point(436, 242);
            button4.Name = "button4";
            button4.Size = new Size(93, 67);
            button4.TabIndex = 72;
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
            button5.Location = new Point(577, 242);
            button5.Name = "button5";
            button5.Size = new Size(93, 67);
            button5.TabIndex = 71;
            button5.Text = "E&xcluir";
            button5.TextImageRelation = TextImageRelation.ImageAboveText;
            button5.UseVisualStyleBackColor = true;
            // 
            // FrmMatricula
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 581);
            Controls.Add(btnEditar);
            Controls.Add(btnSalvar);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(dtpMatricula);
            Controls.Add(cmbTurma);
            Controls.Add(cmbAtiva);
            Controls.Add(txtStatus);
            Controls.Add(cmbAluno);
            Controls.Add(dgvMatricula);
            Controls.Add(label6);
            Controls.Add(label9);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(label4);
            Name = "FrmMatricula";
            Text = "FrmMatricula";
            ((System.ComponentModel.ISupportInitialize)dgvMatricula).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpMatricula;
        private ComboBox cmbTurma;
        private ComboBox cmbAtiva;
        private ComboBox txtStatus;
        private ComboBox cmbAluno;
        private DataGridView dgvMatricula;
        private Label label6;
        private Label label9;
        private Label label1;
        private Label label8;
        private Label label4;
        private Button btnEditar;
        private Button btnSalvar;
        private Button button4;
        private Button button5;
    }
}