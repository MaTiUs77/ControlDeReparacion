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
    public partial class formAcerca : Form
    {
        public formAcerca()
        {
            InitializeComponent();
        }

        private void formAcerca_Load(object sender, EventArgs e)
        {
            label3.Text = "Version: "+ Utilidades.Version();
        }
    }
}
