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
            txtPresenca = new TextBox();
            txtTotalAulas = new TextBox();
            txtPercentual = new TextBox();
            cmbDisciplina = new ComboBox();
            cmbMatricula = new ComboBox();
            label6 = new Label();
            dgvFrequencia = new DataGridView();
            label5 = new Label();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            btnEditar = new Button();
            btnSalvar = new Button();
            btnCalcular = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFrequencia).BeginInit();
            SuspendLayout();
            // 
            // txtPresenca
            // 
            txtPresenca.Location = new Point(83, 218);
            txtPresenca.Name = "txtPresenca";
            txtPresenca.ReadOnly = true;
            txtPresenca.Size = new Size(100, 23);
            txtPresenca.TabIndex = 103;
            // 
            // txtTotalAulas
            // 
            txtTotalAulas.Location = new Point(84, 92);
            txtTotalAulas.Name = "txtTotalAulas";
            txtTotalAulas.ReadOnly = true;
            txtTotalAulas.Size = new Size(100, 23);
            txtTotalAulas.TabIndex = 102;
            // 
            // txtPercentual
            // 
            txtPercentual.Location = new Point(83, 154);
            txtPercentual.Name = "txtPercentual";
            txtPercentual.ReadOnly = true;
            txtPercentual.Size = new Size(100, 23);
            txtPercentual.TabIndex = 100;
            // 
            // cmbDisciplina
            // 
            cmbDisciplina.FormattingEnabled = true;
            cmbDisciplina.Location = new Point(346, 26);
            cmbDisciplina.Name = "cmbDisciplina";
            cmbDisciplina.Size = new Size(121, 23);
            cmbDisciplina.TabIndex = 99;
            // 
            // cmbMatricula
            // 
            cmbMatricula.FormattingEnabled = true;
            cmbMatricula.Location = new Point(83, 26);
            cmbMatricula.Name = "cmbMatricula";
            cmbMatricula.Size = new Size(121, 23);
            cmbMatricula.TabIndex = 98;
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
            // dgvFrequencia
            // 
            dgvFrequencia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFrequencia.Location = new Point(84, 368);
            dgvFrequencia.Name = "dgvFrequencia";
            dgvFrequencia.Size = new Size(668, 243);
            dgvFrequencia.TabIndex = 93;
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
            // btnEditar
            // 
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold);
            btnEditar.Image = FlowAcademy.Properties.Resources._1410220563_05_Edit_32x32;
            btnEditar.Location = new Point(534, 289);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(97, 64);
            btnEditar.TabIndex = 106;
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
            btnSalvar.Location = new Point(377, 289);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(97, 64);
            btnSalvar.TabIndex = 105;
            btnSalvar.Text = "&Salvar";
            btnSalvar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnCalcular
            // 
            btnCalcular.FlatAppearance.BorderSize = 0;
            btnCalcular.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            btnCalcular.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 128);
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnCalcular.ForeColor = Color.Black;
            btnCalcular.Image = (Image)resources.GetObject("btnCalcular.Image");
            btnCalcular.Location = new Point(224, 289);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(93, 67);
            btnCalcular.TabIndex = 104;
            btnCalcular.Text = "&Calcular";
            btnCalcular.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCalcular.UseVisualStyleBackColor = true;
            // 
            // FrmFrequencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 644);
            Controls.Add(btnEditar);
            Controls.Add(btnSalvar);
            Controls.Add(btnCalcular);
            Controls.Add(txtPresenca);
            Controls.Add(txtTotalAulas);
            Controls.Add(txtPercentual);
            Controls.Add(cmbDisciplina);
            Controls.Add(cmbMatricula);
            Controls.Add(label6);
            Controls.Add(dgvFrequencia);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label4);
            Name = "FrmFrequencia";
            Text = "FrmFrequencia";
            ((System.ComponentModel.ISupportInitialize)dgvFrequencia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPresenca;
        private TextBox txtTotalAulas;
        private TextBox txtPercentual;
        private ComboBox cmbDisciplina;
        private ComboBox cmbMatricula;
        private Label label6;
        private DataGridView dgvFrequencia;
        private Label label5;
        private Label label1;
        private Label label2;
        private Label label4;
        private Button btnEditar;
        private Button btnSalvar;
        private Button btnCalcular;
    }
}