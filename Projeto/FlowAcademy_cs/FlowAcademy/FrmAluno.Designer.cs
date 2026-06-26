namespace FlowAcademy
{
    partial class FrmAluno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAluno));
            label1 = new Label();
            label2 = new Label();
            dgvAluno = new DataGridView();
            label5 = new Label();
            label6 = new Label();
            txtMatricula = new TextBox();
            label7 = new Label();
            label8 = new Label();
            txtEndereco = new TextBox();
            cmbUsuario = new ComboBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            btnExluir = new Button();
            mtbCpf = new MaskedTextBox();
            mtbTelefone = new MaskedTextBox();
            btnEditar = new Button();
            label3 = new Label();
            txtPesquisa = new TextBox();
            btnPesquisar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAluno).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(386, 22);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Cadastro de Alunos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 22);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 1;
            label2.Text = "Usuário";
            // 
            // dgvAluno
            // 
            dgvAluno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAluno.Location = new Point(113, 393);
            dgvAluno.Name = "dgvAluno";
            dgvAluno.Size = new Size(668, 243);
            dgvAluno.TabIndex = 4;
            dgvAluno.CellDoubleClick += dgvAluno_CellDoubleClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 70);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 1;
            label5.Text = "CPF";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 166);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 1;
            label6.Text = "Matricula";
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(43, 186);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(130, 23);
            txtMatricula.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(43, 118);
            label7.Name = "label7";
            label7.Size = new Size(52, 15);
            label7.TabIndex = 1;
            label7.Text = "Telefone";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(43, 214);
            label8.Name = "label8";
            label8.Size = new Size(56, 15);
            label8.TabIndex = 1;
            label8.Text = "Endereco";
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(43, 234);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(130, 23);
            txtEndereco.TabIndex = 2;
            // 
            // cmbUsuario
            // 
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(43, 42);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(121, 23);
            cmbUsuario.TabIndex = 14;
            // 
            // btnSalvar
            // 
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.FlatAppearance.MouseDownBackColor = Color.Lime;
            btnSalvar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold);
            btnSalvar.Image = (Image)resources.GetObject("btnSalvar.Image");
            btnSalvar.Location = new Point(194, 287);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(97, 64);
            btnSalvar.TabIndex = 19;
            btnSalvar.Text = "&Salvar";
            btnSalvar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 128);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.Location = new Point(484, 284);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(93, 67);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnExluir
            // 
            btnExluir.FlatAppearance.BorderSize = 0;
            btnExluir.FlatAppearance.MouseDownBackColor = Color.Red;
            btnExluir.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            btnExluir.FlatStyle = FlatStyle.Flat;
            btnExluir.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnExluir.ForeColor = Color.Black;
            btnExluir.Image = (Image)resources.GetObject("btnExluir.Image");
            btnExluir.Location = new Point(625, 284);
            btnExluir.Name = "btnExluir";
            btnExluir.Size = new Size(93, 67);
            btnExluir.TabIndex = 17;
            btnExluir.Text = "E&xcluir";
            btnExluir.TextImageRelation = TextImageRelation.ImageAboveText;
            btnExluir.UseVisualStyleBackColor = true;
            btnExluir.Click += btnExluir_Click;
            // 
            // mtbCpf
            // 
            mtbCpf.Location = new Point(43, 88);
            mtbCpf.Mask = "000.000.000-00";
            mtbCpf.Name = "mtbCpf";
            mtbCpf.Size = new Size(121, 23);
            mtbCpf.TabIndex = 21;
            // 
            // mtbTelefone
            // 
            mtbTelefone.Location = new Point(43, 140);
            mtbTelefone.Mask = "(99) 99999-9999";
            mtbTelefone.Name = "mtbTelefone";
            mtbTelefone.Size = new Size(121, 23);
            mtbTelefone.TabIndex = 21;
            // 
            // btnEditar
            // 
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold);
            btnEditar.Image = FlowAcademy.Properties.Resources._1410220563_05_Edit_32x32;
            btnEditar.Location = new Point(337, 287);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(97, 64);
            btnEditar.TabIndex = 22;
            btnEditar.Text = "&Editar";
            btnEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(113, 369);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 23;
            label3.Text = "Pesquisar";
            // 
            // txtPesquisa
            // 
            txtPesquisa.Location = new Point(176, 365);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.Size = new Size(441, 23);
            txtPesquisa.TabIndex = 24;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(637, 364);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(144, 25);
            btnPesquisar.TabIndex = 25;
            btnPesquisar.Text = "&Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // FrmAluno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 635);
            Controls.Add(btnPesquisar);
            Controls.Add(txtPesquisa);
            Controls.Add(label3);
            Controls.Add(btnEditar);
            Controls.Add(mtbTelefone);
            Controls.Add(mtbCpf);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(btnExluir);
            Controls.Add(cmbUsuario);
            Controls.Add(dgvAluno);
            Controls.Add(txtEndereco);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtMatricula);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmAluno";
            Text = "FrmAluno";
            Load += FrmAluno_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAluno).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView dgvAluno;
        private Label label5;
        private Label label6;
        private TextBox txtMatricula;
        private Label label7;
        private Label label8;
        private TextBox txtEndereco;
        private ComboBox cmbUsuario;
        private Button btnSalvar;
        private Button btnCancelar;
        private Button btnExluir;
        private MaskedTextBox mtbCpf;
        private MaskedTextBox mtbTelefone;
        private Button btnEditar;
        private Label label3;
        private TextBox txtPesquisa;
        private Button btnPesquisar;
    }
}
