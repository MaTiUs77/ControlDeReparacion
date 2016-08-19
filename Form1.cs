using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Deployment.Application;
using System.IO;
using ControlDeReparacion.Upload;
using M77;
using System.Xml.Linq;

namespace ControlDeReparacion
{
    public partial class Form1 : Form
    {
        private bool mostrarAlInicio = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Si esta disponible una nueva version, actualizo la aplicacion.
            if (Utilidades.Actualizar_version())
            {          
                try  {  
                    status_vr.Text = Utilidades.Version(); 
                }  catch (Exception ex) 
                {  
                    // No se encuentra instaldo el archivo ClickOnce, no es posible cargar version en debugmode
                }

                // Cargo archivo de configuracion
                Config.start();

                // Cargo configuracion SQL del sistema
                Sistema.load();
                // Si estoy en mantenimiento, cierro aplicacion.
                if (Sistema.mantenimiento())
                {
                    Application.Exit();
                }
                else
                {
                    // Muestro Login
                    ServiceCore.url = Util.AppConfigValue("IASERVER", "service");
                   
                    showLogin();
                }               
            }
        }

        // Ventana de logueo
        private void showLogin() {

            this.Enabled = false;
            formLogin login = new formLogin();
            login.ShowDialog();

            if (login.clave.Trim() == "")
            {
                Application.Exit();
            }
            else
            {
                if (Login.validar(login.clave))
                {
                    // Habilito e inicio aplicacion
                    this.Enabled = true;
                    StartApp();
                }
                else
                {
                    MessageBox.Show("Acceso incorrecto.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    showLogin();
                }
            }
        }

        private void StartApp() {
            Limpiar_Filtros();

            loadMenuFlag();
            if (Operador.invitado())
            {
                formSector fm = new formSector();
                fm.ShowDialog();
            }

            refrescarPlanilla();

            Sistema.ping();
            iniciarTimer();
            statusActual();

            if (mostrarAlInicio)
            {
//                formAcerca fa = new formAcerca();
//                fa.ShowDialog();

                mostrarAlInicio = false;
            }

        }

        private void iniciarTimer()
        {
            timer1.Interval = 900000; // 15 Minutos
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Cargo reportes y envio ping al servidor.
            //refrescarPlanilla();
            Sistema.ping();
        }

        private void loadMenuFlag() {
            menuConfiguracion.Visible = false;

            if (Operador.invitado())
            {
                menuAdministrar.Visible = false;
                reparacionMenuItem.Visible = false;
                menuSector.Visible = true;
            }
            else
            {
                menuAdministrar.Visible = true;
                reparacionMenuItem.Visible = true;

                if (Operador.admin())
                {
                    menuUsuarios.Visible = true;
                    menuOrigen.Visible = true;
                    menuDefectos.Visible = true;
                    menuCausas.Visible = true;
                    menuAccion.Visible = true;
                    menuSector.Visible = true;
                    menuConfiguracion.Visible = true;
                    menuAvanzados.Visible = true;
                }
                else
                {
                    menuUsuarios.Visible = false;
                    menuOrigen.Visible = false;
                    menuDefectos.Visible = false;
                    menuCausas.Visible = false;
                    menuAccion.Visible = false;
                    menuSector.Visible = true;
                    menuAvanzados.Visible = false;
                }
            }        
        }

        private void statusActual() { 
            status_user.Text = Operador.nombre + " "+ Operador.apellido;
            status_sector.Text = Operador.sector.ToUpper();
            status_area.Text = Operador.area.ToUpper();
        }


        // Rechazos en la barra de estado
        private void load_Rechazo_estado() {

            if (!Filtros.codigo.Equals(""))
            {
                infoRechazos.Text = "-";
                infoReparaciones.Text = "-";
                infoScrap.Text = "-";
                infoPendientes.Text = "-";
                infoBonepile.Text = "-";
                infoAnalisis.Text = "-";
            }
            else
            {
                infoRechazos.Text = "0";
                infoReparaciones.Text = "0";
                infoScrap.Text = "0";
                infoPendientes.Text = "0";
                infoBonepile.Text = "0";
                infoAnalisis.Text = "0";

                Mysql sql = new Mysql();
                DataTable dt = sql.Select(Reparacion.RechazoTotal());
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        string estado = r["estado"].ToString();
                        string total = r["total"].ToString();
                        switch (estado)
                        {
                            case "P":
                                infoRechazos.Text = total;
                                break;
                            case "R":
                                infoReparaciones.Text = total;
                                break;
                            case "S":
                                infoScrap.Text = total;
                                break;
                            case "B":
                                infoBonepile.Text = total;
                                break;
                            case "A":
                                infoAnalisis.Text = total;
                                break;
                        }
                    }
                    infoPendientes.Text = Reparacion.pendientes.ToString();
                }
            }
        }

        public void refrescarPlanilla()
        {
            load_reporte_placas();
        }

        /*
         * Ejecucion de ventana remota 
         */
        public void aplicarFiltro()
        {
            load_reporte_placas();
        }

        public void load_reporte_placas()
        {
            Cursor.Current = Cursors.WaitCursor;

            Reparacion.pendientes = 0;

            gridPlacas.Rows.Clear();

            Reparacion ls = new Reparacion();
            List<Reparacion> lista = ls.Formato();

            int i = 0;

            if (lista.Count > 0)
            {
                foreach (Reparacion rp in lista)
                {
                    if (!Reparacion.ModoHistorial && rp.log)
                    {
                        // Ver Log = falso
                        // el dato es un Log
                        // No lo muestro
                    }
                    else
                    {
                        i = gridPlacas.Rows.Add(
                            rp.id,
                            rp.imagen,
                            rp.historial,
                            rp.flag_txt,
                            rp.codigo,
                            rp.modelo,
                            rp.lote,
                            rp.panel,
                            rp.defecto,
                            rp.causa,
                            string.Join(",", rp.referencia),
                            rp.accion,
                            rp.correctiva,
                            rp.origen,
                            rp.nombre+ " " + rp.apellido,
                            rp.turno,
                            rp.area,
                            rp.fecha,
                            rp.hora);

                        #region Set color de estado
                        if (rp.flag == "P")
                        {
                            rowPendiente(gridPlacas.Rows[i]);
                        }

                        if (rp.flag == "S")
                        {
                            rowScrap(gridPlacas.Rows[i]);
                        }

                        if (rp.flag == "B")
                        {
                            rowBonepile(gridPlacas.Rows[i]);
                        }

                        if (rp.flag == "A")
                        {
                            rowAnalisis(gridPlacas.Rows[i]);
                        }

                        if (rp.log)
                        {
                            rowHistorico(gridPlacas.Rows[i]);
                        }
                        else
                        {
                            if (rp.flag == "P")
                            {
                                Reparacion.pendientes++;
                            }
                        }
                        #endregion
                    }
                }
            }
            Cursor.Current = Cursors.Default;
            load_Rechazo_estado();
        }

        #region Funciones: Color de filas
        private void rowPendiente(DataGridViewRow row)
        {
            Utilidades.rowColor(row, "#000000", "#FBFF7A");
        }

        private void rowAnalisis(DataGridViewRow row)
        {
            Utilidades.rowColor(row, "#000000", "#aad3ff");
        }

        private void rowBonepile(DataGridViewRow row)
        {
            Utilidades.rowColor(row, "#000000", "#88D12E");
        }
        private void rowScrap(DataGridViewRow row)
        {
            Utilidades.rowColor(row, "#000000", "#FF6B6B");
        }
        private void rowHistorico(DataGridViewRow row)
        {
            Utilidades.rowColor(row, "#7A7A7A", "#C2C2C2");
        }
        #endregion


        #region Llamada a formularios
        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Operador.invitado())
            {
                formCodigo fc = new formCodigo();
                fc.ShowDialog();
                if (fc.codigo != "")
                {
                    formIngresoPlaca ing = new formIngresoPlaca();
                    ing.codigo = fc.codigo;
                    ing.ShowDialog();

                    Filtros.codigo = "";
                    if (ing.actualizarPlanilla)
                    {
                        refrescarPlanilla();
                    }
                }
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAcerca fa = new formAcerca();
            fa.ShowDialog();
        }
        private void modeloEnProduccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formActual fm = new formActual();
            fm.ShowDialog();
            statusActual();
        }
        private void datosAvanzadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAdminData adm = new formAdminData();
            adm.ShowDialog();
        }
        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formConfig fc = new formConfig();
            fc.ShowDialog();
        }
        private void causasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formCausa fm = new formCausa();
            fm.ShowDialog();
        }
        private void origenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formOrigen fm = new formOrigen();
            fm.ShowDialog();
        }
        private void accionCorrectivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAccion fm = new formAccion();
            fm.ShowDialog();
        }
        private void defectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDefecto fm = new formDefecto();
            fm.ShowDialog();
        }
        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refrescarPlanilla();
        }
        private void reparadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formUsuario fm = new formUsuario();
            fm.ShowDialog();
        }
        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showLogin();
        }
        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formModelo fm = new formModelo();
            fm.ShowDialog();
        }
        private void definirModeloActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formActual fm = new formActual();
            fm.ShowDialog();
            statusActual();
        }
        private void conectarDesconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showLogin();
        }
        private void menuSector_Click(object sender, EventArgs e)
        {
            formSector fm = new formSector();
            fm.ShowDialog();
            if (fm.iniciarCambio)
            {
                StartApp();
            }
        }
        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formStat fm = new formStat();
            fm.Show();
        }
        private void hoyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFiltro fm = new formFiltro(this);
            fm.Show();
        }
        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Limpiar_Filtros();
            aplicarFiltro();
        }
        private void Limpiar_Filtros()
        {
            Filtros.limpiar();
        }
        private void usuariosOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formOnline fm = new formOnline();
            fm.Show();
        }
        private void codigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formCodigo fc = new formCodigo();
            fc.ShowDialog();
            if (fc.codigo != "")
            {
                Filtros.codigo = fc.codigo;
                formHistorico fh = new formHistorico();
                fh.ShowDialog();
            }
        }
        private void cargarImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Operador.invitado())
            {
                formCodigo fc = new formCodigo();
                fc.Text = "Agregar imagen";
                fc.ShowDialog();
                if (fc.codigo != "")
                {
                    Reparacion rp = new Reparacion();
                    rp.Nuevo(fc.codigo);
                    if (rp.existe)
                    {
                        formMenuImagen mImg = new formMenuImagen();
                        mImg.ShowDialog();

                        if (mImg.camara)
                        {
                            formCapture fcapture = new formCapture();
                            fcapture.codigo = fc.codigo;
                            fcapture.ShowDialog();
                        }
                        else
                        {
                            string archivo = Utilidades.Buscar_imagen();

                            if (!archivo.Equals(""))
                            {
                                formUpload up = new formUpload();
                                up.codigo = fc.codigo;
                                up.archivo = archivo;
                                up.vars = "?codigo=" + fc.codigo;

                                up.ShowDialog();

                                if (up.server_archivo != "Error" && up.archivo != "")
                                {
                                    MessageBox.Show("Imagen cargada con exito!.", "Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El codigo de reparacion no se encuentra registrado.");
                    }
                }
            }
        }       
        private void verImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formCodigo fc = new formCodigo();
            fc.Text = "Visualizar imagenes";
            fc.ShowDialog();
            if (fc.codigo != "")
            {
                Reparacion rp = new Reparacion();
                rp.Nuevo(fc.codigo);
                if (rp.existe)
                {
                    formGaleria fh = new formGaleria(fc.codigo);
                    if (fh.foto)
                    {
                        fh.Show();
                    }
                }
                else
                {
                    MessageBox.Show("El codigo de reparacion no se encuentra registrado.");
                }
            }            
        }
        private void gridPlacas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (row != -1)
            {
                switch (col)
                {
                    case 1: // Columna de imagen
                        string cod = gridPlacas.Rows[row].Cells["rcodigo"].Value.ToString();
                        formGaleria fh = new formGaleria(cod);

                        if (fh.foto)
                        {
                            fh.Show();
                        }
                    break;
                }
            }
        }
        #endregion

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            int col = gridPlacas.CurrentCell.ColumnIndex;
            int row = gridPlacas.CurrentCell.RowIndex;
            if (Operador.admin())
            {
                if (e.KeyCode == Keys.E)
                {
                    switch (col)
                    {
                        case 4: // Codigo
                            e.Handled = true;

                            gridEdit gText = new gridEdit();
                            gText.set(gridPlacas, col, row);
                            gText.TextArea();
                        break;
                        case 5: // Modelo
                            e.Handled = true;

                            string[] modelos = Reparacion.Modelos_sql().ToArray();

                            gridEdit gCombo = new gridEdit();
                            gCombo.set(gridPlacas, col, row);
                            gCombo.ComboBox(modelos);
                        break;
                        case 6: // Lotes
                            e.Handled = true;

                            string _modelo = gridPlacas.Rows[row].Cells[5].Value.ToString();
                            string[] lotes = Reparacion.Lotes_ing(_modelo).ToArray();

                            gridEdit gLotes = new gridEdit();
                            gLotes.set(gridPlacas, col, row);
                            gLotes.ComboBox(lotes);
                        break;
                        case 7: // Paneles
                            e.Handled = true;

                            string modelo = gridPlacas.Rows[row].Cells[5].Value.ToString();
                            string[] _panel = Reparacion.Panel_ing(modelo).ToArray();
                                
                            gridEdit gPanel = new gridEdit();
                            gPanel.set(gridPlacas, col, row);
                            gPanel.ComboBox(_panel);
                        break;
                    }
                }
            }
             */ 
        }
        private void gridPlacas_Fin_de_edicion(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gridPlacas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 4: // Columna de codigo
                    string codigo = gridPlacas.Rows[e.RowIndex].Cells["rcodigo"].Value.ToString();
                    Filtros.codigo = codigo;
                    formHistorico fh = new formHistorico();
                    fh.ShowDialog();
                    break;
            }
        }

        private void mostrarHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Reparacion.ModoHistorial)
            {
                mostrarHistorialToolStripMenuItem.Text = "Mostrar historial";
                Reparacion.ModoHistorial = false;
                aplicarFiltro();
            }
            else
            {
                mostrarHistorialToolStripMenuItem.Text = "Ocultar historial";
                Reparacion.ModoHistorial = true;
                aplicarFiltro();
            }
        }       
    }
}
