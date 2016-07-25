using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using ControlDeReparacion.Upload;
using M77;

namespace ControlDeReparacion
{
    public partial class formIngresoPlaca : Form
    {
        bool Parpadeo = false;

        public string codigo = "";
        
        public bool ingresar = false;
        public bool reparar = false;
        public bool reingresar = false;
        public bool scrap = false;
        public bool bonepile = false;
        public bool analisis = false;

//        public string historial = "";

        public bool actualizarPlanilla = false;
        public bool cargar_informacion_sql = true;

        Reparacion rp = new Reparacion();

        // CAPTURA DE CAMARA
        #region CAMARA
        private Capture cam;
        IntPtr m_ip = IntPtr.Zero;
        private Image Adjuntar_Foto;

        private void MostrarCamara()
        {
            int VIDEODEVICE = 0; // zero based index of video capture device to use
            int VIDEOWIDTH = 640; // Depends on video device caps
            int VIDEOHEIGHT = 480; // Depends on video device caps
            short VIDEOBITSPERPIXEL = 24; // BitsPerPixel values determined by device

            cam = new Capture(VIDEODEVICE, VIDEOWIDTH, VIDEOHEIGHT, VIDEOBITSPERPIXEL, pictureBox2);
            if (!cam.camaras)
            {
                btnFotoCamara.Visible = false;
            }
            else
            {
                btnCapturar.Visible = true;
                btnFotoCamara.Enabled = false;
            }
        }
        private bool CerrarCaptura()
        {
            cam.Dispose();

            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }
            return true;
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
            
            b.Save(root_upload,ImageFormat.Jpeg);

            CerrarCaptura();
            pictureBox2.Image = b;

            btnCapturar.Visible = false;
            btnFotoCamara.Enabled = true;

            Adjuntar_Foto = b;
            Adjuntar_Foto.Tag = root_upload;

            Cursor.Current = Cursors.Default;
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
                }
            }
        }
        #endregion
        //---

        public formIngresoPlaca()
        {
            InitializeComponent();
        }

        private void formIngresoPlaca_FormClosed(object sender, FormClosedEventArgs e)
        {
             CerrarCaptura();
        }

        private void formIngresoPlaca_Load(object sender, EventArgs e)
        {
            loadFormulario();
        }

        private void loadFormulario() {

            inCodigo.Text = codigo;

            load_combo_modelo();
            load_combo_causa();
            load_combo_defecto();
            load_combo_origen();
            load_combo_accion();

            string modelo = Config.current_modelo; // Config.ini.Read("local", "modelo");
            string lote = Config.current_lote; // Config.ini.Read("local", "lote");
            string panel = Config.current_panel; // Config.ini.Read("local", "panel");

            comboModelo.SelectedIndex = comboModelo.FindStringExact(modelo);
            comboLote.SelectedIndex = comboLote.FindStringExact(lote);
            comboPanel.SelectedIndex = comboPanel.FindStringExact(panel);

            // Informacion de codigo.
            rp.Nuevo(codigo);

            set_modo();

            MostrarCamara();

            timer1.Enabled = true;
        }

        private void set_modo()
        {
            switch (rp.flag)
            {
                case "":
                    modo_ingreso();
                break;
                case "P":
                if (Operador.inspector())
                {
                    MessageBox.Show("ATENCION: Este panel no se encuentra reparado!.\nContacte a un reparador!.", "Reparacion incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarDialogo();
                }
                else
                {
                    modo_reparado();
                }
                break;
                case "R":
                    modo_re_ingreso();
                break;
                case "B":
                if (Operador.inspector())
                {
                    MessageBox.Show("ATENCION: Este panel se encuentra declarado como BonePile!.\nContacte a un reparador!.", "BonePile detectado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarDialogo();
                }
                else
                {
                    MessageBox.Show("Este panel fue detectado como BonePile.", "BonePile detectado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    modo_reparado();
                }
                break;
                case "A":
                if (Operador.inspector())
                {
                    MessageBox.Show("ATENCION: Este panel se encuentra declarado como Analisis!.\nContacte a un reparador!.", "Analisis detectado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarDialogo();
                }
                else
                {
                    MessageBox.Show("Este panel fue detectado como Analisis.", "Analisis detectado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    modo_reparado();
                }
                break;

                case "S":
                if (Operador.inspector())
                {
                    MessageBox.Show("ATENCION: Este panel se encuentra SCRAP!.\nContacte a un reparador!.", "Scrap detectado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarDialogo();
                }
                else
                {
                    MessageBox.Show("Este panel fue detectado como scrap.\n Recuerde que solo dispone de 2 reparaciones por panel.", "Scrap detectado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    modo_reparado();
                }
                break;
            }

            if (rp.reparaciones >= Config.reparacion_limite)
            {
                MessageBox.Show("Este panel fue detectado con varias reparaciones.\n Deberia declarar este panel como SCRAP.", "Multiples reparaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (rp.flag != "R")
                {
                    modo_reparado();
                }
            }
        }

        private void Parpadear() {
            if (Parpadeo)
            {
                if (ingresar || reingresar)
                {
                    titulo.BackColor = Color.LightGoldenrodYellow;
                    titulo.ForeColor = Color.Black;
                }

                if (reparar)
                {
                    titulo.BackColor = Color.LightGreen;
                    titulo.ForeColor = Color.Black;
                }

                Parpadeo = false;
            }
            else
            {
                titulo.BackColor = Color.Red;
                titulo.ForeColor = Color.White;

                Parpadeo = true;
            }
        }

        private void modo_ingreso()
        {
            ingresar = true;

            boxDeclaracion.Visible = false;

            btnReportar.Text = "Ingresar a reparacion";
            titulo.Text = "INGRESAR A REPARACION";

            titulo.BackColor = Color.LightGoldenrodYellow;

            comboCausa.Enabled = true;

            comboOrigen.Enabled = false;
            comboAccion.Enabled = false;

            inAccion.Enabled = true;
        }

        private void modo_reparado()
        {
            reparar = true;
            btnReportar.Text = "Reparacion completa";
            titulo.Text = "DECLARAR REPARACION";

            titulo.BackColor = Color.LightGreen;

            comboModelo.Enabled = false;
            comboPanel.Enabled = false;
            comboLote.Enabled = false;

            load_Reparacion();
        }

        private void modo_re_ingreso()
        {
            reingresar = true;

            btnReportar.Text = "Re-ingresar a reparacion";
            titulo.Text = "RE-INGRESAR A REPARACION";

            titulo.BackColor = Color.LightGoldenrodYellow;

            comboModelo.Enabled = false;
            comboPanel.Enabled = false;
            comboLote.Enabled = false;

            comboCausa.Enabled = true;

            comboAccion.Enabled = false;
            comboOrigen.Enabled = false;

            inAccion.Enabled = true;

            load_Reparacion();
        }

        private void load_Reparacion()
        {
            if (cargar_informacion_sql)
            {
//                Mysql sql = new Mysql();
               /*
                * string str = @"
select 
r.id,
r.codigo,
operador.nombre,
operador.apellido,
r.modelo,
r.lote,
r.panel,
causa.causa,
defecto.defecto,
r.defecto as referencia,
accion.accion,
origen.origen,
r.correctiva,
r.estado,
turno.turno,
DATE_FORMAT(r.fecha, '%d/%m/%Y') as fecha,
DATE_FORMAT(r.hora, '%H:%i') as hora ,
sector.sector

,(
    select COUNT(*) from reparacion rc
    where 
        rc.estado = 'R'
    and rc.codigo = r.codigo
    group by rc.codigo
) AS reparaciones

from 
area area
,operador operador
,turno turno
,accion accion
,sector sector
,origen origen
,defecto defecto
,causa causa
,reparacion r

where   
    r.id_area = area.id
and r.id_operador = operador.id
and r.id_turno = turno.id
and r.id_accion = accion.id
and r.id_sector = sector.id
and r.id_origen = origen.id
and r.id_defecto = defecto.id
and r.id_causa = causa.id

and r.id_sector = '" + Operador.sector_id + @"' 
and r.codigo = '" + codigo + @"'
and r.id = '" + rp.id + @"'
 
group by r.codigo order by r.id desc 
limit 1
";

                DataTable dt = sql.Select(str);
                */

                Filtros.codigo = codigo;
                DataTable dt = Reparacion.Get();

                if (dt.Rows.Count>0)
                {
                    DataRow r = dt.Rows[0];
                    inCodigo.Text = r["codigo"].ToString();
                    comboModelo.SelectedIndex = comboModelo.FindStringExact(r["modelo"].ToString());
                    comboLote.SelectedIndex = comboLote.FindStringExact(r["lote"].ToString());
                    comboPanel.SelectedIndex = comboPanel.FindStringExact(r["panel"].ToString());

                    inAccion.Text = r["correctiva"].ToString();

                    if (!reingresar)
                    {
                        string[] referencias = r["referencia"].ToString().Split(',');
                        foreach (string Ref in referencias)
                        {
                            string add = Ref.Trim();
                            if (add != "")
                            {
                                if (ReferenciaExistente(add))
                                {
                                    dataReferencias.Rows.Add("", add.ToUpper());
                                }
                                else
                                {
                                    MessageBox.Show("Referencia no localizada en ingenieria: " + add);
                                }
                            }
                        }

                        comboDefecto.SelectedIndex = comboDefecto.FindStringExact(r["defecto"].ToString());
                        comboCausa.SelectedIndex = comboCausa.FindStringExact(r["causa"].ToString());
                        comboAccion.SelectedIndex = comboAccion.FindStringExact(r["accion"].ToString());
                        comboOrigen.SelectedIndex = comboOrigen.FindStringExact(r["origen"].ToString());
                    }
                    else
                    {
                        inAccion.Text = "";
                    }

                    string historial = r["reparaciones"].ToString();
                    int his = 0;
                    if (historial != "")
                    {
                        his = int.Parse(historial);
                    }
                    rp.reparaciones = his;
                }

                // Ejecuto la carga solo una vez.
                cargar_informacion_sql = false;
            }
        }

        private void comboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_lote();
        }
        private void comboModelo_SelectedValueChanged(object sender, EventArgs e)
        {
            combo_lote();
        }
        private void comboLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_panel();
        }
        private void comboPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Al elegir panel, cargar referencias.
            cargar_referencias();
        }

        private void combo_lote()
        {
            if (comboModelo.SelectedIndex >= 0)
            {
                comboLote.Items.Clear();
                Ingenieria.combo_Lotes(Combo.valor(comboModelo), comboLote);
            }
        }
        private void combo_panel()
        {
            if (comboLote.SelectedIndex >= 0)
            {
                load_combo_panel();
            }
        }

        private void load_combo_panel()
        {
            comboPanel.Items.Clear();
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
select 
m.modelo,
p.panel
from panel p

left join (
select id,modelo,id_sector from modelo
) as m
on m.id = p.id_modelo

where m.id_sector = '" + Operador.sector_id + "' and m.modelo = '" + Combo.nombre(comboModelo) + "' order by p.panel");

            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboPanel.Items.Add(r["panel"].ToString());
                }
            }
        }
        private void load_combo_modelo()
        {
            comboModelo.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,modelo from modelo where id_sector = '"+Operador.sector_id+"' order by modelo");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboModelo.Items.Add(new Combo(r["modelo"].ToString(), Ingenieria.CARPETA + r["modelo"].ToString()));
                }
            }
        }
        private void load_combo_defecto()
        {
            comboDefecto.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,defecto from defecto  where id_sector = '" + Operador.sector_id + "' order by defecto");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboDefecto.Items.Add(new Combo(r["defecto"].ToString(), r["id"].ToString()));
                }
            }
        }
        private void load_combo_origen()
        {
            comboOrigen.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,origen from origen where id_sector = '" + Operador.sector_id + "'  order by origen");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboOrigen.Items.Add(new Combo(r["origen"].ToString(), r["id"].ToString()));
                }
            }
        }
        private void load_combo_accion()
        {
            comboAccion.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,accion from accion where id_sector = '" + Operador.sector_id + "'  order by accion");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboAccion.Items.Add(new Combo(r["accion"].ToString(), r["id"].ToString()));
                }
            }
        }
        private void load_combo_causa()
        {
            comboCausa.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,causa from causa where id_sector = '" + Operador.sector_id + "'  order by causa");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboCausa.Items.Add(new Combo(r["causa"].ToString(), r["id"].ToString()));
                }
            }
        }

        private void btnReportar_Click(object sender, EventArgs e)
        {
            if (ingresar)
            {
                ingresarDB();
            }

            if(reparar) {
                repararDB();
            }

            if (reingresar)
            {
                reingresarDB();
            }
        }

        private void reingresarDB()
        {
            if (camposIncompletos())
            {
                MessageBox.Show("Por favor complete los campos.");
            }
            else
            {
                string modelo = Combo.nombre(comboModelo);
                string lote = Combo.nombre(comboLote);
                string panel = comboPanel.Items[comboPanel.SelectedIndex].ToString();

                string id_defecto = Combo.valor(comboDefecto);

                comboOrigen.SelectedIndex = comboOrigen.FindStringExact("A determinar");
                comboAccion.SelectedIndex = comboAccion.FindStringExact("A determinar");

                string id_causa = Combo.valor(comboCausa);
                string id_origen = Combo.valor(comboOrigen);
                string id_accion = Combo.valor(comboAccion);

                string defecto = guardarReferencias();

                string correctiva = inAccion.Text.ToString();

                string estado = "P";
                if (scrap)
                {
                    estado = "S";
                }

                if (bonepile)
                {
                    estado = "B";
                }

                if (analisis)
                {
                    estado = "A";
                }

                if (rp.existe)
                {
                    rp.Set(modelo,lote,panel,id_causa,id_defecto,defecto,id_accion,correctiva,id_origen,estado);
                    if (rp.Ingresar())
                    {
                        AdjuntarImagen();
                        cerrarDialogo();
                    }
                    else
                    {
                        MessageBox.Show("ERROR: No se pudo actualizar la informacion.");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: El codigo " + codigo + " no se encuentra ingresado en reparacion.");
                }
            }
        }

        private void repararDB()
        {
            if (camposIncompletos())
            {
                MessageBox.Show("Por favor complete los campos.");
            }
            else
            {
                string modelo = Combo.nombre(comboModelo);
                string lote = Combo.nombre(comboLote);
                string panel = comboPanel.Items[comboPanel.SelectedIndex].ToString();

                string id_defecto = Combo.valor(comboDefecto);
                string id_causa = Combo.valor(comboCausa);

                string id_origen = Combo.valor(comboOrigen);

                string id_accion;

                if (comboAccion.SelectedIndex < 0)
                {
                    id_accion = "0";
                }
                else
                {
                    id_accion = Combo.valor(comboAccion);
                }

                string defecto = guardarReferencias();

                string correctiva = inAccion.Text.ToString();

                string estado = "R";
                if (scrap)
                {
                    estado = "S";
                }
                if (bonepile)
                {
                    estado = "B";
                } 
                if (analisis)
                {
                    estado = "A";
                }

                rp.Nuevo(codigo);
                if (rp.existe)
                {
                    rp.Set(modelo, lote, panel, id_causa, id_defecto, defecto, id_accion, correctiva, id_origen, estado);
                    if (rp.Reparar())
                    {
                        AdjuntarImagen();
                        cerrarDialogo();
                    }
                    else
                    {
                        MessageBox.Show("ERROR: No se pudo actualizar la informacion.");
                    }
                }
                else
                {
                MessageBox.Show("ERROR: El codigo " + codigo + " no se encuentra ingresado en reparacion.");
                }
            }
        }

        private bool camposIncompletos() 
        {
            if (
                    comboModelo.SelectedIndex < 0 ||
                    comboLote.SelectedIndex < 0 ||
                    comboPanel.SelectedIndex < 0 ||
                    comboDefecto.SelectedIndex < 0 ||
                    comboCausa.SelectedIndex < 0 ||
                    // comboOrigen.SelectedIndex < 0 ||
                    inAccion.Text.ToString().Equals(string.Empty)
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void ingresarDB()
        {
            if (camposIncompletos())
            {
                MessageBox.Show("Por favor complete los campos.");
            }
            else
            {

                comboOrigen.SelectedIndex = comboOrigen.FindStringExact("A determinar");
                comboAccion.SelectedIndex = comboAccion.FindStringExact("A determinar");

                string modelo = Combo.nombre(comboModelo);
                string lote = Combo.nombre(comboLote);
                string panel = comboPanel.Items[comboPanel.SelectedIndex].ToString();
                string id_defecto = Combo.valor(comboDefecto);
                string id_causa = Combo.valor(comboCausa);

                string id_origen = Combo.valor(comboOrigen);
                string id_accion = Combo.valor(comboAccion);
                string defecto = guardarReferencias();
                string correctiva = inAccion.Text.ToString();
                string estado = "P";


                if (scrap)
                {
                    estado = "S";
                }

                if (bonepile)
                {
                    estado = "B";
                }

                if (analisis)
                {
                    estado = "A";
                }

                if (!rp.existe)
                {
                    rp.Set(modelo, lote, panel, id_causa, id_defecto, defecto, id_accion, correctiva, id_origen, estado);
                    if (rp.Ingresar())
                    {
                        AdjuntarImagen();
                        cerrarDialogo();
                    }
                    else
                    {
                        MessageBox.Show("ERROR. No se pudo ingresar la informacion al sistema.");
                    }
                }
                /*
                if (!Reparacion.Existe(codigo))
                {
                    bool rs = Reparacion.Ingresar(codigo, modelo, lote, panel, id_causa, id_defecto, defecto, id_accion, correctiva, id_origen, estado);
                    if (rs)
                    {
                        AdjuntarImagen();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR. No se pudo ingresar la informacion al sistema.");
                    }
                }
                else
                {
                    MessageBox.Show("ATENCION: Se detecto que el codigo '" + codigo + "' ya fue ingresado al sistema.");
                }*/
            }
        }


        private void btnScrap_Click(object sender, EventArgs e)
        {
            scrap = true;
            btnReportar_Click(sender, e);
        }

        private void btnBonePile_Click(object sender, EventArgs e)
        {
            bonepile = true;
            btnReportar_Click(sender, e);
        }

        private void btnAnalisis_Click(object sender, EventArgs e)
        {
            analisis = true;
            btnReportar_Click(sender, e);
        }

        private void btnFotoPc_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = new Bitmap(10, 10);
            btnCapturar.Visible = false;
            string archivo = buscarArchivo();

            if (!archivo.Equals(""))
            {
                Bitmap myBitmap = new Bitmap(archivo);
                Adjuntar_Foto = myBitmap;
                Adjuntar_Foto.Tag = archivo;
                pictureBox2.Image = myBitmap;
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private string buscarArchivo()
        {
            OpenFileDialog fdlg = new OpenFileDialog();

            if (cam.camaras)
            {
                bool rs = CerrarCaptura();
            }

            btnFotoCamara.Enabled = true;

            fdlg.Title = "Buscar imagen";
            fdlg.InitialDirectory = Environment.SpecialFolder.DesktopDirectory.ToString();
            fdlg.Filter = "Imagenes (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF,*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF,*.JPEG";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;

            fdlg.ShowDialog();

            return fdlg.FileName;
        }

        private void btnFotoCamara_Click(object sender, EventArgs e)
        {
            MostrarCamara();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CapturarFoto();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Parpadear();
        }


        private string guardarReferencias()
        {
            List<string> referencias = new List<string>();
            foreach (DataGridViewRow r in dataReferencias.Rows)
            {
                string lista = r.Cells["aref"].Value.ToString().ToUpper();
                referencias.Add(lista);
            }
            return string.Join(",", referencias);
        }

        private void cargar_referencias() {
            comboReferencias.AutoCompleteCustomSource = null;
            comboReferencias.Items.Clear();
            comboReferencias.Text = "";
            dataReferencias.Rows.Clear();

            string modelo = Combo.nombre(comboModelo);
            string lote = Combo.nombre(comboLote);
            string panel = comboPanel.SelectedItem.ToString();

            DataTable dt = Ingenieria.info(modelo, lote);

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();

            bool panelVirtual = true;

            foreach (DataRow r in dt.Rows)
            {
                string panel_ing = r[4].ToString();
                string referencia_ing = r[5].ToString();

                if (!panelVirtual)
                {
                    // Agrego solo referencias del panel tal cual lista de ingenieria.
                    if (panel == panel_ing)
                    {
                        data.Add(referencia_ing);
                        comboReferencias.Items.Add(referencia_ing);
                    }
                }
                else
                {
                    // El panel no existe en la lista de ingenieria... Agreo todas las referencias de la lista.
                    data.Add(referencia_ing);
                    comboReferencias.Items.Add(referencia_ing);
                }
            }
            comboReferencias.AutoCompleteCustomSource = data;
        }

        private bool ReferenciaExistente(string referencia) {
            bool rs = false;
            foreach(string ch in comboReferencias.Items) {
                if (ch.ToLower() == referencia.ToLower())
                {
                    rs = true;
                    break;
                }
            }
            return rs;
        }

        private bool ReferenciaAgregada(string referencia)
        {
            bool rs = false;
            foreach (DataGridViewRow r in dataReferencias.Rows)
            {
                string lista = r.Cells["aref"].Value.ToString().ToLower();
                if (lista == referencia.ToLower())
                {
                    rs = true;
                    break;
                }
            }
            return rs;
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string addRef = comboReferencias.Text;
                if (ReferenciaExistente(addRef))
                {
                    if (!ReferenciaAgregada(addRef))
                    {
                        dataReferencias.Rows.Add("", addRef);
                        comboReferencias.Text = "";
                    }
                    comboReferencias.Text = "";
                }                
            }
        }

        private void dataReferencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;

            if (col == 0)
            {
                dataReferencias.Rows.RemoveAt(row);
            }
        }


        private void cerrarDialogo() {
            actualizarPlanilla = true;
            this.Close();
        }
    }
}
