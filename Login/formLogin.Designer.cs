namespace ControlDeReparacion
{
    partial class formLogin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.formLoginTitulo = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.formLoginTitulo);
            this.groupBox1.Controls.Add(this.btn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(256, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // formLoginTitulo
            // 
            this.formLoginTitulo.AutoSize = true;
            this.formLoginTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formLoginTitulo.ForeColor = System.Drawing.Color.Black;
            this.formLoginTitulo.Location = new System.Drawing.Point(31, 18);
            this.formLoginTitulo.Name = "formLoginTitulo";
            this.formLoginTitulo.Size = new System.Drawing.Size(199, 24);
            this.formLoginTitulo.TabIndex = 3;
            this.formLoginTitulo.Text = "Control de Reparacion";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(53, 96);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(150, 23);
            this.btn.TabIndex = 2;
            this.btn.Text = "Acceder";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingresar clave de acceso";
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(53, 72);
            this.txt.Name = "txt";
            this.txt.PasswordChar = '*';
            this.txt.Size = new System.Drawing.Size(150, 20);
            this.txt.TabIndex = 0;
            this.txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 145);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "formLogin";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autentificacion";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.formLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label formLoginTitulo;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt;
    }
}