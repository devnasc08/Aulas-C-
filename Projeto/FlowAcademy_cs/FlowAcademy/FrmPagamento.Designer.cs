namespace FlowAcademy
{
    partial class FrmPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPagamento));
            dgvPagamento = new DataGridView();
            label1 = new Label();
            txtAluno = new TextBox();
            cmbStatus = new ComboBox();
            nudValor = new NumericUpDown();
            dtpVencimento = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtIdPagamento = new TextBox();
            btnEditar = new Button();
            btnSalvar = new Button();
            btnCancelar = new Button();
            btnExcluir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPagamento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudValor).BeginInit();
            SuspendLayout();
            // 
            // dgvPagamento
            // 
            dgvPagamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagamento.Location = new Point(381, 31);
            dgvPagamento.Name = "dgvPagamento";
            dgvPagamento.Size = new Size(444, 407);
            dgvPagamento.TabIndex = 0;
            dgvPagamento.CellDoubleClick += dgvPagamento_CellDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 88);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Aluno:";
            // 
            // txtAluno
            // 
            txtAluno.Location = new Point(92, 86);
            txtAluno.Name = "txtAluno";
            txtAluno.Size = new Size(264, 23);
            txtAluno.TabIndex = 2;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(92, 245);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(158, 23);
            cmbStatus.TabIndex = 3;
            // 
            // nudValor
            // 
            nudValor.DecimalPlaces = 2;
            nudValor.Location = new Point(92, 192);
            nudValor.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudValor.Name = "nudValor";
            nudValor.Size = new Size(158, 23);
            nudValor.TabIndex = 4;
            // 
            // dtpVencimento
            // 
            dtpVencimento.Location = new Point(92, 139);
            dtpVencimento.Name = "dtpVencimento";
            dtpVencimento.Size = new Size(263, 23);
            dtpVencimento.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 244);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 1;
            label2.Text = "Status:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 192);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 1;
            label3.Text = "Valor (R$):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 140);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 1;
            label4.Text = "Vencimento:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(2, 36);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 1;
            label5.Text = "Id Pagamento:";
            // 
            // txtIdPagamento
            // 
            txtIdPagamento.Location = new Point(92, 33);
            txtIdPagamento.Name = "txtIdPagamento";
            txtIdPagamento.ReadOnly = true;
            txtIdPagamento.Size = new Size(264, 23);
            txtIdPagamento.TabIndex = 2;
            // 
            // btnEditar
            // 
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold);
            btnEditar.Image = Properties.Resources._1410220563_05_Edit_32x32;
            btnEditar.Location = new Point(193, 306);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(97, 64);
            btnEditar.TabIndex = 56;
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
            btnSalvar.Location = new Point(48, 306);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(97, 64);
            btnSalvar.TabIndex = 55;
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
            btnCancelar.Location = new Point(52, 407);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(93, 67);
            btnCancelar.TabIndex = 54;
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
            btnExcluir.Location = new Point(193, 407);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(93, 67);
            btnExcluir.TabIndex = 53;
            btnExcluir.Text = "E&xcluir";
            btnExcluir.TextImageRelation = TextImageRelation.ImageAboveText;
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // FrmPagamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 562);
            Controls.Add(btnEditar);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(btnExcluir);
            Controls.Add(dtpVencimento);
            Controls.Add(nudValor);
            Controls.Add(cmbStatus);
            Controls.Add(txtIdPagamento);
            Controls.Add(txtAluno);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvPagamento);
            Name = "FrmPagamento";
            Text = "FrmPagamento";
            Load += FrmPagamento_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPagamento).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudValor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPagamento;
        private Label label1;
        private TextBox txtAluno;
        private ComboBox cmbStatus;
        private NumericUpDown nudValor;
        private DateTimePicker dtpVencimento;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtIdPagamento;
        private Button btnEditar;
        private Button btnSalvar;
        private Button btnCancelar;
        private Button btnExcluir;
    }
}
