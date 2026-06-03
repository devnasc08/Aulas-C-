namespace Servicehub
{
    partial class FrmCategorias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCategorias));
            btnCancelar = new Button();
            btnExcluir = new Button();
            btnPesquisar = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtSigla = new TextBox();
            lblSigla = new Label();
            lblNome = new Label();
            lblId = new Label();
            txtNome = new TextBox();
            txtId = new TextBox();
            textBuscar = new TextBox();
            dgvCategorias = new DataGridView();
            clnId = new DataGridViewTextBoxColumn();
            clnNome = new DataGridViewTextBoxColumn();
            clnSigla = new DataGridViewTextBoxColumn();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 128);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Image = Properties.Resources.Delete;
            btnCancelar.Location = new Point(508, 208);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(93, 67);
            btnCancelar.TabIndex = 22;
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
            btnExcluir.Image = Properties.Resources.Delete;
            btnExcluir.Location = new Point(388, 208);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(93, 67);
            btnExcluir.TabIndex = 21;
            btnExcluir.Text = "E&xcluir";
            btnExcluir.TextImageRelation = TextImageRelation.ImageAboveText;
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnPesquisar
            // 
            btnPesquisar.FlatAppearance.BorderSize = 0;
            btnPesquisar.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnPesquisar.FlatAppearance.MouseOverBackColor = Color.DodgerBlue;
            btnPesquisar.FlatStyle = FlatStyle.Flat;
            btnPesquisar.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnPesquisar.ForeColor = Color.Black;
            btnPesquisar.Image = Properties.Resources.Search1;
            btnPesquisar.Location = new Point(148, 208);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(93, 67);
            btnPesquisar.TabIndex = 20;
            btnPesquisar.Text = "&Pesquisar";
            btnPesquisar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPesquisar.UseVisualStyleBackColor = true;
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
            btnEdit.Location = new Point(268, 208);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(93, 67);
            btnEdit.TabIndex = 19;
            btnEdit.Text = "&Editar";
            btnEdit.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatAppearance.MouseDownBackColor = Color.Lime;
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.Black;
            btnAdd.Image = Properties.Resources.Add;
            btnAdd.Location = new Point(28, 208);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(93, 67);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "&Adiocionar";
            btnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtSigla
            // 
            txtSigla.Location = new Point(530, 71);
            txtSigla.Name = "txtSigla";
            txtSigla.Size = new Size(73, 23);
            txtSigla.TabIndex = 15;
            // 
            // lblSigla
            // 
            lblSigla.AutoSize = true;
            lblSigla.Location = new Point(530, 56);
            lblSigla.Name = "lblSigla";
            lblSigla.Size = new Size(32, 15);
            lblSigla.TabIndex = 25;
            lblSigla.Text = "Sigla";
            lblSigla.Click += lblSigla_Click;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(99, 56);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(40, 15);
            lblNome.TabIndex = 24;
            lblNome.Text = "Nome";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(28, 53);
            lblId.Name = "lblId";
            lblId.Size = new Size(18, 15);
            lblId.TabIndex = 23;
            lblId.Text = "ID";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(99, 71);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(425, 23);
            txtNome.TabIndex = 14;
            // 
            // txtId
            // 
            txtId.Location = new Point(30, 71);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(63, 23);
            txtId.TabIndex = 27;
            // 
            // textBuscar
            // 
            textBuscar.Location = new Point(28, 301);
            textBuscar.Name = "textBuscar";
            textBuscar.PlaceholderText = "Buscar Categoria";
            textBuscar.Size = new Size(573, 23);
            textBuscar.TabIndex = 28;
            textBuscar.TextChanged += textBuscar_TextChanged;
            // 
            // dgvCategorias
            // 
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToDeleteRows = false;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Columns.AddRange(new DataGridViewColumn[] { clnId, clnNome, clnSigla });
            dgvCategorias.Location = new Point(28, 330);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.ReadOnly = true;
            dgvCategorias.RowHeadersVisible = false;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(573, 205);
            dgvCategorias.TabIndex = 29;
            dgvCategorias.CellClick += dgvCategorias_CellContentClick;
            dgvCategorias.CellContentClick += dgvCategorias_CellContentClick;
            dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;
            // 
            // clnId
            // 
            clnId.Frozen = true;
            clnId.HeaderText = "Id";
            clnId.Name = "clnId";
            clnId.ReadOnly = true;
            clnId.Width = 70;
            // 
            // clnNome
            // 
            clnNome.Frozen = true;
            clnNome.HeaderText = "Nome";
            clnNome.Name = "clnNome";
            clnNome.ReadOnly = true;
            clnNome.Width = 400;
            // 
            // clnSigla
            // 
            clnSigla.Frozen = true;
            clnSigla.HeaderText = "Sigla";
            clnSigla.Name = "clnSigla";
            clnSigla.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(255, 24);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 30;
            label1.Text = "Cadastro de Categorias";
            // 
            // FrmCategorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 547);
            Controls.Add(label1);
            Controls.Add(dgvCategorias);
            Controls.Add(textBuscar);
            Controls.Add(btnCancelar);
            Controls.Add(btnExcluir);
            Controls.Add(btnPesquisar);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtSigla);
            Controls.Add(lblSigla);
            Controls.Add(lblNome);
            Controls.Add(lblId);
            Controls.Add(txtNome);
            Controls.Add(txtId);
            Name = "FrmCategorias";
            Text = "FrmCategorias";
            Load += FrmCategorias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnExcluir;
        private Button btnPesquisar;
        private Button btnEdit;
        private Button btnAdd;
        private TextBox txtSigla;
        private Label lblSigla;
        private Label lblNome;
        private Label lblId;
        private TextBox txtNome;
        private TextBox txtId;
        private TextBox textBuscar;
        private DataGridView dgvCategorias;
        private Label label1;
        private DataGridViewTextBoxColumn clnId;
        private DataGridViewTextBoxColumn clnNome;
        private DataGridViewTextBoxColumn clnSigla;
    }
}