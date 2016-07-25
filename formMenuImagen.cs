using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlDeReparacion
{
    public partial class formMenuImagen : Form
    {

        public bool camara = true;  

        public formMenuImagen()
        {
            InitializeComponent();
        }

        private void btCamara_Click(object sender, EventArgs e)
        {
            camara = true;
            this.Close();
        }

        private void btPc_Click(object sender, EventArgs e)
        {
            camara = false;
            this.Close();
        }
    }
}
