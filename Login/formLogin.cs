using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using M77;

namespace ControlDeReparacion
{
    public partial class formLogin : Form
    {
        public string clave = "";

        public formLogin()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            clave = Utilidades.Escape(txt.Text.Trim());
            if (clave == "")
            {
                MessageBox.Show("No ingreso la clave.");
            }
            else
            {             
                this.Close();
            }
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F1))
            {
                formConfig cf = new formConfig();
                cf.ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btn_Click(sender, e);
            }
        }
    }
}
