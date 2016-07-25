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
    public partial class formCodigo : Form
    {
        public string codigo = "";

        public formCodigo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            codigo = inCodigo.Text.Trim().ToUpper();
            codigo = Utilidades.Escape(codigo);
            this.Close();           
        }

        private void inCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1_Click(sender, e);
            }
        }
    }
}
