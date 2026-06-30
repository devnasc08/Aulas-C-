namespace FlowAcademyF
{
    partial class FrmFeedback
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFeedback));
            btnLimpar = new Button();
            btnEnviar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            txtFeedback = new TextBox();
            cmbTipoFeedback = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnLimpar
            // 
            btnLimpar.FlatAppearance.BorderSize = 0;
            btnLimpar.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnLimpar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold);
            btnLimpar.Image = FlowAcademy.Properties.Resources._1410220563_05_Edit_32x32;
            btnLimpar.Location = new Point(334, 374);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(97, 64);
            btnLimpar.TabIndex = 29;
            btnLimpar.Text = "&Limpar";
            btnLimpar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnEnviar
            // 
            btnEnviar.FlatAppearance.BorderSize = 0;
            btnEnviar.FlatAppearance.MouseDownBackColor = Color.Lime;
            btnEnviar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
            btnEnviar.FlatStyle = FlatStyle.Flat;
            btnEnviar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold);
            btnEnviar.Image = (Image)resources.GetObject("btnEnviar.Image");
            btnEnviar.Location = new Point(189, 374);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(97, 64);
            btnEnviar.TabIndex = 28;
            btnEnviar.Text = "&Enviar";
            btnEnviar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
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
            btnCancelar.Location = new Point(479, 371);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(93, 67);
            btnCancelar.TabIndex = 27;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 42);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 30;
            label1.Text = "Digite o seu feedback: ";
            // 
            // txtFeedback
            // 
            txtFeedback.Location = new Point(23, 65);
            txtFeedback.Multiline = true;
            txtFeedback.Name = "txtFeedback";
            txtFeedback.Size = new Size(490, 200);
            txtFeedback.TabIndex = 31;
            // 
            // cmbTipoFeedback
            // 
            cmbTipoFeedback.FormattingEnabled = true;
            cmbTipoFeedback.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoFeedback.Location = new Point(24, 303);
            cmbTipoFeedback.Name = "cmbTipoFeedback";
            cmbTipoFeedback.Size = new Size(175, 23);
            cmbTipoFeedback.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 285);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 30;
            label2.Text = "Tipo de feedback:";
            // 
            // FrmFeedback
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbTipoFeedback);
            Controls.Add(txtFeedback);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLimpar);
            Controls.Add(btnEnviar);
            Controls.Add(btnCancelar);
            Name = "FrmFeedback";
            Text = "FrmFeedback";
            Load += FrmFeedback_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLimpar;
        private Button btnEnviar;
        private Button btnCancelar;
        private Label label1;
        private TextBox txtFeedback;
        private ComboBox cmbTipoFeedback;
        private Label label2;
    }
}
