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
            btnEditar = new Button();
            btnEnviar = new Button();
            button4 = new Button();
            label1 = new Label();
            txtFeedback = new TextBox();
            cmbTipoFeedback = new ComboBox();
            label2 = new Label();
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
            btnEditar.Location = new Point(334, 374);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(97, 64);
            btnEditar.TabIndex = 29;
            btnEditar.Text = "&Apagar";
            btnEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEditar.UseVisualStyleBackColor = true;
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
            button4.Location = new Point(479, 371);
            button4.Name = "button4";
            button4.Size = new Size(93, 67);
            button4.TabIndex = 27;
            button4.Text = "&Cancelar";
            button4.TextImageRelation = TextImageRelation.ImageAboveText;
            button4.UseVisualStyleBackColor = true;
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
            Controls.Add(btnEditar);
            Controls.Add(btnEnviar);
            Controls.Add(button4);
            Name = "FrmFeedback";
            Text = "FrmFeedback";
            Load += FrmFeedback_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEditar;
        private Button btnEnviar;
        private Button button4;
        private Label label1;
        private TextBox txtFeedback;
        private ComboBox cmbTipoFeedback;
        private Label label2;
    }
}