using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;


namespace ControlDeReparacion
{
    internal partial class formCapture : Form
    {
        //        private System.ComponentModel.Container components = null;
        private Capture cam;
        IntPtr m_ip = IntPtr.Zero;

        public formCapture()
        {
            InitializeComponent();
        }

        private void iniCapture() {
            int VIDEODEVICE = 0; // zero based index of video capture device to use
            int VIDEOWIDTH = 640; // Depends on video device caps
            int VIDEOHEIGHT = 480; // Depends on video device caps
            short VIDEOBITSPERPIXEL = 24; // BitsPerPixel values determined by device

            cam = new Capture(VIDEODEVICE, VIDEOWIDTH, VIDEOHEIGHT, VIDEOBITSPERPIXEL, pictureBox2);
            if (!cam.camaras)
            {
                MessageBox.Show("No hay camaras disponibles.");
            }
        }

        private void Captura_Load(object sender, EventArgs e)
        {
            iniCapture();
        }

        private void IniciarCaptura()
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
            b.Save(@"C:\Users\usuario\Desktop\800x600___zzXXX.jpg");
            MessageBox.Show("Imagen guardara");
            //            pictureBox1.Image = b;

            Cursor.Current = Cursors.Default;
            this.Close();
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
            IniciarCaptura();
        }
    }
}
