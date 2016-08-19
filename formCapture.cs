using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using ControlDeReparacion.Upload;

namespace ControlDeReparacion
{
    internal partial class formCapture : Form
    {
        //        private System.ComponentModel.Container components = null;
        private Capture cam;
        IntPtr m_ip = IntPtr.Zero;
        private Image Adjuntar_Foto;

        public string codigo = "";

        public formCapture()
        {
            InitializeComponent();
        }

        private void Captura_Load(object sender, EventArgs e)
        {
            iniCapture();
        }

        private void iniCapture() {
            int VIDEODEVICE = 0; // zero based index of video capture device to use
            int VIDEOWIDTH = 640; // Depends on video device caps
            int VIDEOHEIGHT = 480; // Depends on video device caps
            short VIDEOBITSPERPIXEL = 24; // BitsPerPixel values determined by device

            cam = new Capture(VIDEODEVICE, VIDEOWIDTH, VIDEOHEIGHT, VIDEOBITSPERPIXEL, pictureBox);
            if (!cam.camaras)
            {
                MessageBox.Show("No hay camaras disponibles.");
            }
        }


        private void CapturarFoto()
        {
            Cursor.Current = Cursors.WaitCursor;

            // Release any previous buffer
            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }

            // capture image
            m_ip = cam.Click();
            Bitmap b = new Bitmap(cam.Width, cam.Height, cam.Stride, PixelFormat.Format24bppRgb, m_ip);

            // If the image is upsidedown
            b.RotateFlip(RotateFlipType.RotateNoneFlipY);

            string root_upload = Config.reparacion_folder + "UploadCamera.jpg";
            b.Save(root_upload, ImageFormat.Jpeg);

            CerrarCaptura();
            pictureBox.Image = b;

            Adjuntar_Foto = b;
            Adjuntar_Foto.Tag = root_upload;

            Cursor.Current = Cursors.Default;

            AdjuntarImagen();
        }

        private void AdjuntarImagen()
        {
            if (Adjuntar_Foto != null)
            {
                formUpload up = new formUpload();
                up.codigo = codigo;
                up.archivo = Adjuntar_Foto.Tag.ToString();
                up.vars = "?codigo=" + codigo;

                up.ShowDialog();

                if (up.server_archivo != "Error" && up.archivo != "")
                {
                    MessageBox.Show("Imagen cargada con exito!.");
                    iniCapture();
                }
            }
        }

        private void CerrarCaptura()
        {
            cam.Dispose();

            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }
        }

        private void Captura_FormClosed(object sender, FormClosedEventArgs e)
        {
           CerrarCaptura();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CapturarFoto();
        }
    }
}
