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
    public partial class formConfig : Form
    {
        public formConfig()
        {
            InitializeComponent();
        }

        private void formConfig_Load(object sender, EventArgs e)
        {
            Config.start();
            cargar_config();
        }

        private void cargarConfiguracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargar_config();
        }

        private void cargar_config() {
            inServidor.Text = Mysql.server;
            inDb.Text = Mysql.database;
            inUser.Text = Mysql.user;
            inPass.Text = Mysql.password;

            inApache.Text = Config.apache;
            inIngenieria.Text = Ingenieria.CARPETA;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config.apache = inApache.Text;
            Config.save(inServidor.Text, inDb.Text, inUser.Text, inPass.Text, inIngenieria.Text);
            Utilidades.Restart();
        }
    }
}
