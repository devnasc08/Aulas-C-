namespace Servicehub
{
    partial class FrmServicos
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
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            textBox3 = new TextBox();
            dataGridView1 = new DataGridView();
            cln1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(30, 57);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(358, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 34);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(421, 34);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // button1
            // 
            button1.Location = new Point(30, 86);
            button1.Name = "button1";
            button1.Size = new Size(720, 26);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 124);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 1;
            label3.Text = "label1";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(74, 121);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(676, 23);
            textBox3.TabIndex = 0;
            textBox3.TextChanged += textBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { cln1, Column2 });
            dataGridView1.Location = new Point(30, 162);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(720, 280);
            dataGridView1.TabIndex = 4;
            // 
            // cln1
            // 
            cln1.Frozen = true;
            cln1.HeaderText = "Column1";
            cln1.Name = "cln1";
            cln1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.Frozen = true;
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(392, 57);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(358, 23);
            textBox2.TabIndex = 0;
            textBox2.TextChanged += textBox1_TextChanged;
            // 
            // FrmServicos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "FrmServicos";
            Text = "FrmServicos";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private TextBox textBox3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn cln1;
        private DataGridViewTextBoxColumn Column2;
        private TextBox textBox2;
    }
}