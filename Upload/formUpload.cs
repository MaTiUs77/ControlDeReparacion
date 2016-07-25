using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using M77;

namespace ControlDeReparacion.Upload
{
    public partial class formUpload : Form
    {

        public string direccion = "http://10.30.10.22/reparacion/upload.php";
        public string archivo = "";

        public string server_archivo = "";
        public string vars = "";
        public string codigo = "";

        Uri server;
        ProgressBar barra;
        BackgroundWorker bw = new BackgroundWorker();

        public formUpload()
        {
            InitializeComponent();
        }

        private void formUpload_Load(object sender, EventArgs e)
        {
            server = new Uri(direccion+vars);

            if (archivo == "")
            {
                this.Close();
            }
            else 
            {
                barra = progreso;

                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                //            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                //            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                bw.RunWorkerAsync();
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Start();
        }

        private void Start()
        {
            if (archivo != "")
            {
                try
                {
                    System.Net.WebClient Client = new System.Net.WebClient();
                    //                Client.Headers.Add("Content-Type", "binary/octet-stream");
                    Client.UploadFileCompleted += new UploadFileCompletedEventHandler(UploadFileCompleted);
                    Client.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressChanged);
                    
                    Client.UploadFileAsync(server, "POST", archivo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERRROR: " + ex.Message);
                }
            }
        }

        private void UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            server_archivo = System.Text.Encoding.UTF8.GetString(e.Result, 0, e.Result.Length);

            if (InvokeRequired)
            {
                Invoke(new delegar_Terminar(Terminar));
            }
        }

        private delegate void delegar_setProgreso(int total,int current);
        private void setProgreso(int total, int current)
        {
            barra.Maximum = total;
            barra.Value = current;
        }

        private delegate void delegar_Terminar();
        private void Terminar()
        {
            if (archivo != "")
            {
                Foto_add();
            }
            this.Close();
        }

        private void Foto_add() {
            if (server_archivo != "Error")
            {
                Mysql sql = new Mysql();
                bool rs = sql.Ejecutar(@"INSERT INTO `fotos` 
            (`codigo`, `id_operador`, `id_sector`, `fecha`, `archivo`) VALUES 
            ('" + codigo + "', '" + Operador.id + "', '" + Operador.sector_id + "', NOW(), '" + server_archivo + "');");
            }
        }

        private void UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            int total =  (int)e.TotalBytesToSend;
            int current = (int)e.BytesSent;

            if (InvokeRequired)
            {
                Invoke(new delegar_setProgreso(setProgreso), total,current);
            }
        }

        
    }
}
