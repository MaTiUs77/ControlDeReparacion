namespace ControlDeReparacion
{
    partial class formMenuImagen
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
            this.btPc = new System.Windows.Forms.Button();
            this.btCamara = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btPc
            // 
            this.btPc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPc.Location = new System.Drawing.Point(27, 118);
            this.btPc.Name = "btPc";
            this.btPc.Size = new System.Drawing.Size(235, 66);
            this.btPc.TabIndex = 1;
            this.btPc.Text = "Buscar en la PC";
            this.btPc.UseVisualStyleBackColor = true;
            this.btPc.Click += new System.EventHandler(this.btPc_Click);
            // 
            // btCamara
            // 
            this.btCamara.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCamara.Location = new System.Drawing.Point(27, 29);
            this.btCamara.Name = "btCamara";
            this.btCamara.Size = new System.Drawing.Size(235, 66);
            this.btCamara.TabIndex = 0;
            this.btCamara.Text = "Capturar desde camara";
            this.btCamara.UseVisualStyleBackColor = true;
            this.btCamara.Click += new System.EventHandler(this.btCamara_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btPc);
            this.groupBox1.Controls.Add(this.btCamara);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 202);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione una opcion";
            // 
            // formMenuImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 222);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formMenuImagen";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjuntar imagen";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btPc;
        private System.Windows.Forms.Button btCamara;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}