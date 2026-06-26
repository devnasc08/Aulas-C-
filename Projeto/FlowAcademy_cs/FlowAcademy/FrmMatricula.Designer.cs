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
            dtpDataMatricula = new DateTimePicker();
            cmbTurma = new ComboBox();
            cmbStatus = new ComboBox();
            cmbAluno = new ComboBox();
            dgvMatricula = new DataGridView();
            label6 = new Label();
            label1 = new Label();
            label8 = new Label();
            label4 = new Label();
            btnEditar = new Button();
            btnSalvar = new Button();
            btnCancelar = new Button();
            btnExcluir = new Button();
            label2 = new Label();
            txtPesquisa = new TextBox();
            btnPesquisar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMatricula).BeginInit();
            SuspendLayout();
            // 
            // dtpDataMatricula
            // 
            dtpDataMatricula.Location = new Point(445, 26);
            dtpDataMatricula.Name = "dtpDataMatricula";
            dtpDataMatricula.Size = new Size(200, 23);
            dtpDataMatricula.TabIndex = 70;
            // 
            // cmbTurma
            // 
            cmbTurma.FormattingEnabled = true;
            cmbTurma.Location = new Point(260, 26);
            cmbTurma.Name = "cmbTurma";
            cmbTurma.Size = new Size(121, 23);
            cmbTurma.TabIndex = 66;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(83, 111);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(121, 23);
            cmbStatus.TabIndex = 64;
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
            dgvMatricula.Location = new Point(66, 364);
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
            btnEditar.Click += btnEditar_Click;
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
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 128);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Image = (Image)resources.GetObject("button4.Image");
            btnCancelar.Location = new Point(436, 242);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(93, 67);
            btnCancelar.TabIndex = 72;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.FlatAppearance.BorderSize = 0;
            btnExcluir.FlatAppearance.MouseDownBackColor = Color.Red;
            btnExcluir.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnExcluir.ForeColor = Color.Black;
            btnExcluir.Image = (Image)resources.GetObject("button5.Image");
            btnExcluir.Location = new Point(577, 242);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(93, 67);
            btnExcluir.TabIndex = 71;
            btnExcluir.Text = "E&xcluir";
            btnExcluir.TextImageRelation = TextImageRelation.ImageAboveText;
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 333);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 75;
            label2.Text = "Pesquisar";
            // 
            // txtPesquisa
            // 
            txtPesquisa.Location = new Point(129, 329);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.Size = new Size(461, 23);
            txtPesquisa.TabIndex = 76;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(610, 328);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(124, 25);
            btnPesquisar.TabIndex = 77;
            btnPesquisar.Text = "&Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // FrmMatricula
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 622);
            Controls.Add(btnPesquisar);
            Controls.Add(txtPesquisa);
            Controls.Add(label2);
            Controls.Add(btnEditar);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(btnExcluir);
            Controls.Add(dtpDataMatricula);
            Controls.Add(cmbTurma);
            Controls.Add(cmbStatus);
            Controls.Add(cmbAluno);
            Controls.Add(dgvMatricula);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(label4);
            Name = "FrmMatricula";
            Text = "FrmMatricula";
            Load += FrmMatricula_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMatricula).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpDataMatricula;
        private ComboBox cmbTurma;
        private ComboBox cmbStatus;
        private ComboBox cmbAluno;
        private DataGridView dgvMatricula;
        private Label label6;
        private Label label1;
        private Label label8;
        private Label label4;
        private Button btnEditar;
        private Button btnSalvar;
        private Button btnCancelar;
        private Button btnExcluir;
        private Label label2;
        private TextBox txtPesquisa;
        private Button btnPesquisar;
    }
}
