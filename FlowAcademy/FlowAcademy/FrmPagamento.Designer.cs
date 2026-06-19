namespace FlowAcademyF
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
            btnEditar = new Button();
            btnSalvar = new Button();
            btnCalcular = new Button();
            SuspendLayout();
            // 
            // btnEditar
            // 
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold);
            btnEditar.Image = FlowAcademy.Properties.Resources._1410220563_05_Edit_32x32;
            btnEditar.Location = new Point(468, 228);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(129, 81);
            btnEditar.TabIndex = 93;
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
            btnSalvar.Location = new Point(313, 228);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(129, 81);
            btnSalvar.TabIndex = 92;
            btnSalvar.Text = "&Registrar Pagamento";
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
            btnCalcular.Location = new Point(158, 228);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(129, 81);
            btnCalcular.TabIndex = 91;
            btnCalcular.Text = "&Calcular";
            btnCalcular.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCalcular.UseVisualStyleBackColor = true;
            // 
            // FrmPagamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEditar);
            Controls.Add(btnSalvar);
            Controls.Add(btnCalcular);
            Name = "FrmPagamento";
            Text = "FrmPagamento";
            ResumeLayout(false);
        }

        #endregion

        private Button btnEditar;
        private Button btnSalvar;
        private Button btnCalcular;
    }
}