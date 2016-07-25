using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using M77;
using System.IO;

namespace ControlDeReparacion
{
    public partial class formStat : Form
    {

        public string db = "";
        public string titulo = "";

        public formStat()
        {
            InitializeComponent();
        }

        private void formStat_Load(object sender, EventArgs e)
        {
            Mysql sql = new Mysql();
            DataTable dt = Reparacion.Get(); 

            StringBuilder sb = new StringBuilder();
            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            //File.WriteAllText(@"C:\Users\mflores\Desktop\test.csv", sb.ToString());


            /*
            Filtros.stats_desde = (DateTime.Now.AddDays(-4)).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("es-ES"));
            Filtros.stats_hasta = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("es-ES"));

            FechaDesde.Value = Convert.ToDateTime(Filtros.stats_desde);
            FechaHasta.Value = Convert.ToDateTime(Filtros.stats_hasta);

            loadStats();

            label_sector.Text = "Sector: "+Operador.sector.ToUpper();
             */
        }

        private void loadStats() {
            Dona("", "", Filtros.stats_desde, Filtros.stats_hasta, Filtros.stats_desde + " al " + Filtros.stats_hasta + "\nRechazos en total", chart4);

            titulo = "Rechazos diarios";
            stats(Reparacion.Stat_estado(), chartAll);

            titulo = "Rechazos: Mañana";
            stats(Reparacion.Stat_turno(1), chartM);

            titulo = "Rechazos: Tarde";
            stats(Reparacion.Stat_turno(2), chartT);
        }

        private void Dona(string turno, string estado, string desde, string hasta, string _titulo,Chart gchart)
        {
            string filtro = " r.id_sector = '" + Operador.sector_id + @"' ";
            if (hasta != "")
            {
                filtro = filtro + "  and r.fecha >= '" + desde + "' and r.fecha <= '" + hasta + @"' ";
            }
            else
            {
                filtro = filtro + " and r.fecha = '" + desde + "' ";
            }      

            if (turno != "")
            {
                filtro = filtro + " and r.id_turno = '"+turno+"' ";
            }

            if (estado != "")
            {
                filtro = filtro + " and r.estado = '"+estado+"' ";
            }

            Mysql sql = new Mysql();            
            string sqlString = @"
SELECT 
COUNT(*) as rechazos,
df.defecto

FROM reparacion r

left join (
    select id,defecto from defecto
) as df
on df.id = r.id_defecto

where 

" + filtro + @"

group by 
r.id_sector,r.id_defecto

order by 
rechazos desc
";
            DataTable md = sql.Select(sqlString);
            DataView firstView = new DataView(md);
            ChartArea ch = gchart.ChartAreas[0];

            gchart.Titles.Clear();
            gchart.Titles.Add(new Title { Text = _titulo, Font = new Font("Calibri", 15, FontStyle.Bold), BackColor = System.Drawing.ColorTranslator.FromHtml("#efefef") });


            gchart.Series.Clear();
            gchart.Series.Add(new Series { ChartType = SeriesChartType.Pie });
            Series pie = gchart.Series[0];

            List<double> lRechazo = new List<double>();
            List<string> lX = new List<string>();

            double[] yRechazos = { 0 };
            string[] xValues = { "" };

            foreach (DataRow r in md.Rows)
            {
                string rch = r[0].ToString();
                if (rch == "") { rch = "0"; }

                string xv = r[1].ToString();

                double vrechazo = 0;

                if (rch != "") { vrechazo = Convert.ToDouble(rch); }

                lRechazo.Add(vrechazo);
                lX.Add(xv);
            }

            yRechazos = (double[])lRechazo.ToArray();
            xValues = (string[])lX.ToArray();

            //Array.Sort(yRechazos);
            //Array.Reverse(yRechazos);

            pie.Points.DataBindXY(xValues, yRechazos);
            pie.ChartType = SeriesChartType.Doughnut;
            pie["PieLabelStyle"] = "Outside";
            pie["DoughnutRadius"] = "30";

            pie.Label = "(#VALY) #PERCENT{P0}";
            pie.LegendText = "#VALX";

            pie["PieDrawingStyle"] = "Concave";
            pie.IsValueShownAsLabel = true;

            ch.Area3DStyle.Enable3D = true;

            ch.Area3DStyle.Rotation = 30;

            ch.Area3DStyle.Inclination = 40;

            ch.Area3DStyle.IsRightAngleAxes = true;

            if (pie.Points.Count > 0)
            {
                double valorMaximo = pie.Points.Select(p => p.YValues[0]).Max();

                foreach (DataPoint dp in pie.Points)
                {
                    double valor = dp.YValues.First();
                    if (valor >= valorMaximo)
                    {
                        dp["Exploded"] = "True";
                    }
                }
            }

            Legend lg = chart4.Legends[0];

            // Add header separator of type line
            lg.HeaderSeparator = LegendSeparatorStyle.Line;
            lg.HeaderSeparatorColor = Color.Gray;

//            lg.BorderColor = Color.Aqua;
//            lg.BorderWidth = 5;

            // Add Color column
            LegendCellColumn firstColumn = new LegendCellColumn();
            firstColumn.ColumnType = LegendCellColumnType.SeriesSymbol;
            firstColumn.HeaderText = "Color";
            firstColumn.HeaderBackColor = Color.WhiteSmoke;

           // frstColumn.

            // Add AVG cell column
            LegendCellColumn avgColumn = new LegendCellColumn();
            avgColumn.Text = "#VALY";
            avgColumn.HeaderText = "Total";
//            avgColumn.Name = "Total";
            avgColumn.HeaderBackColor = Color.WhiteSmoke;

            // Add Legend Text column
            LegendCellColumn secondColumn = new LegendCellColumn();
            secondColumn.ColumnType = LegendCellColumnType.Text;

//            secondColumn.MaximumWidth = 100;
            secondColumn.MinimumWidth = 900;

            secondColumn.Alignment = ContentAlignment.MiddleLeft;
            secondColumn.HeaderText = "Defecto";
            secondColumn.Text = "#LEGENDTEXT";
            secondColumn.HeaderBackColor = Color.WhiteSmoke;

            if (
                chart4.Legends[0].CellColumns.Count <= 0
            )
            {
                chart4.Legends[0].CellColumns.Add(firstColumn);
                chart4.Legends[0].CellColumns.Add(avgColumn);
                chart4.Legends[0].CellColumns.Add(secondColumn);
            }           
        }

        private void stats(string db, Chart gchart)
        {
            Mysql sql = new Mysql();
            DataTable md = sql.Select(db);
            DataView firstView = new DataView(md);

            gchart.Titles.Clear();
            gchart.Titles.Add(new Title { Text = titulo, Font = new Font("Calibri", 15, FontStyle.Bold), BackColor = System.Drawing.ColorTranslator.FromHtml("#efefef") });

            gchart.Palette = ChartColorPalette.None;
            gchart.PaletteCustomColors = new Color[] { 
                System.Drawing.ColorTranslator.FromHtml("#E31923"), 
                System.Drawing.ColorTranslator.FromHtml("#F5F549"), 
                System.Drawing.ColorTranslator.FromHtml("#33DE52") 
            };
                        
            gchart.ChartAreas.Clear();
            gchart.ChartAreas.Add(new ChartArea());

            ChartArea ch = gchart.ChartAreas[0];

            ch.BackColor = System.Drawing.ColorTranslator.FromHtml("#FAFAFA");
            
            ch.AxisX.MajorGrid.Enabled = false;
            ch.AxisX.MinorGrid.Enabled = false;
            ch.AxisX.IsMarginVisible = true;
            ch.AxisX.LabelStyle.Font = new Font("Calibri", 10);

            ch.AxisY.MajorGrid.LineColor = Color.Silver;
            ch.AxisY.MinorGrid.Enabled = false;
            ch.AxisY.IsMarginVisible = true;
            ch.AxisY.MajorTickMark.Enabled = false;
            ch.AxisY.LabelStyle.Enabled = false;
            ch.Area3DStyle.Enable3D = false;
            
            gchart.Series.Clear();

            gchart.Legends[0].Docking = Docking.Top;
            gchart.Legends[0].Alignment = StringAlignment.Center;
            gchart.Legends[0].BorderColor = Color.Black;
            gchart.Legends[0].BorderWidth = 1;
            gchart.Legends[0].BorderDashStyle = ChartDashStyle.Dot;

            gchart.Series.Add(new Series { Name = "Scrap", ChartType = SeriesChartType.Column });
            gchart.Series.Add(new Series { Name = "Pendiente", ChartType = SeriesChartType.Column });
            gchart.Series.Add(new Series { Name = "Reparado", ChartType = SeriesChartType.Column });

            Series scrap = gchart.Series[0];
            Series pendientes = gchart.Series[1];
            Series reparaciones = gchart.Series[2];

            List<double> lReparado = new List<double>();
            List<double> lPendiente = new List<double>();
            List<double> lScarp = new List<double>();

            List<string> lX = new List<string>();

            double[]    yReparado = { 0 };
            double[]    yPendiente = { 0 };
            double[]    yScrap = { 0 };

            string[]    xValues = {""};

            foreach(DataRow r in md.Rows) {
                string rch = r[4].ToString();
                if (rch == "") { rch = "0"; }

                string xv = r[0].ToString() +"\nRechazos: " + rch;

                string rep = r[3].ToString();
                string pen = r[2].ToString();
                string scr = r[1].ToString();

                double vrep = 0;
                double vpen = 0;
                double vscr = 0;

                if (rep != "") { vrep = Convert.ToDouble(rep);  }
                if (pen != "") { vpen = Convert.ToDouble(pen); }
                if (scr != "") { vscr = Convert.ToDouble(scr); }

                int rp = reparaciones.Points.AddXY(xv, rep);
                int pp = pendientes.Points.AddXY(xv, pen);
                int sp = scrap.Points.AddXY(xv, scr);

                reparaciones.Points[rp].LegendText = r[0].ToString();
                pendientes.Points[pp].LegendText = r[0].ToString();
                scrap.Points[sp].LegendText = r[0].ToString();
                //                reparaciones.Points[rp].AxisLabel = r[0].ToString();

  /*              lReparado.Add(vrep);
                lPendiente.Add(vpen);
                lScarp.Add(vscr);
                lX.Add(xv);
   */         }
            /*
            yReparado = (double[])lReparado.ToArray();
            yPendiente = (double[])lPendiente.ToArray();
            yScrap = (double[])lScarp.ToArray();
            xValues = (string[])lX.ToArray();
            */

//            reparaciones.Points.DataBindXY(xValues,yReparado);
 //           pendientes.Points.DataBindXY(xValues, yPendiente);
  //          scrap.Points.DataBindXY(xValues, yScrap);
            
            reparaciones.IsValueShownAsLabel = true;
            pendientes.IsValueShownAsLabel = true;
            scrap.IsValueShownAsLabel = true;

            ch.AxisX.ScaleView.Zoom(1, 5);

//            ch.CursorX.IsUserEnabled = true;
//            ch.CursorX.IsUserSelectionEnabled = true;
//            ch.AxisX.ScaleView.Zoomable = true;
            ch.AxisX.ScrollBar.IsPositionedInside = false;
//            ch.AxisX.IsMarginVisible = false;
        }

        private void barra_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Chart chart = sender as Chart;
            HitTestResult result = chart.HitTest(e.X, e.Y);

            string estado_flag = "";

            switch (result.ChartElementType)
            {
                case ChartElementType.DataPoint:
                case ChartElementType.DataPointLabel:
              
                switch(result.Series.Name) {
                    case "Scrap": estado_flag = "S"; break;
                    case "Pendiente": estado_flag = "P"; break;
                    case "Reparado": estado_flag = "R"; break;
                }

                string fecha = chart.Series[result.Series.Name].Points[result.PointIndex].LegendText.ToString();
                var dateValue = DateTime.Parse(fecha, new CultureInfo("es-ES", false));

                string fecha_desde = dateValue.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("es-ES"));
                string fecha_hasta = dateValue.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("es-ES"));

                switch (chart.Name.ToString())
                {                   
                    case "chartM":
                        Dona("1", estado_flag, fecha_desde, fecha_hasta, fecha + "\nRechazos turno mañana: " + result.Series.Name, chart4);
                        break;
                    case "chartT":
                        Dona("2", estado_flag, fecha_desde, fecha_hasta, fecha + "\nRechazos turno tarde: " + result.Series.Name, chart4);
                    break;
                    case "chartAll":
                    Dona("", estado_flag, fecha_desde, fecha_hasta, fecha + "\nRechazos: " + result.Series.Name, chart4);
                    break;
                }
                break;

                case ChartElementType.Title:
                    switch (chart.Name.ToString())
                    {
                        case "chartM":
                            Dona("1", "", Filtros.stats_desde, Filtros.stats_hasta, Filtros.stats_desde + " al " +Filtros.stats_hasta + "\nRechazos turno mañana", chart4);
                            break;
                        case "chartT":
                            Dona("2", "", Filtros.stats_desde, Filtros.stats_hasta, Filtros.stats_desde + " al " +Filtros.stats_hasta + "\nRechazos turno tarde", chart4);
                            break;
                        case "chartAll":
                            Dona("", "", Filtros.stats_desde, Filtros.stats_hasta, Filtros.stats_desde + " al " +Filtros.stats_hasta + "\nRechazos en total" , chart4);
                         break;
                    }
                break;

                case ChartElementType.LegendItem:

                switch(result.Series.Name) {
                    case "Scrap": estado_flag = "S"; break;
                    case "Pendiente": estado_flag = "P"; break;
                    case "Reparado": estado_flag = "R"; break;
                }

                switch (chart.Name.ToString())
                {
                    case "chartM":
                        Dona("1", estado_flag, Filtros.stats_desde, Filtros.stats_hasta, Filtros.stats_desde + " al " + Filtros.stats_hasta + "\nRechazos turno mañana: " + result.Series.Name, chart4);
                        break;
                    case "chartT":
                        Dona("2", estado_flag, Filtros.stats_desde, Filtros.stats_hasta, Filtros.stats_desde + " al " + Filtros.stats_hasta + "\nRechazos turno tarde: " + result.Series.Name, chart4);
                        break;
                    case "chartAll":
                        Dona("", estado_flag, Filtros.stats_desde, Filtros.stats_hasta, Filtros.stats_desde + " al " + Filtros.stats_hasta + "\nRechazos en total: " + result.Series.Name, chart4);
                    break;
                }
                break;
            }
        }

        private void chart_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Chart chart = sender as Chart;
            HitTestResult result = chartAll.HitTest(e.X, e.Y);
            if
            (
                result.ChartElementType == ChartElementType.DataPoint
                || result.ChartElementType == ChartElementType.DataPointLabel
                || result.ChartElementType == ChartElementType.LegendItem 
                || result.ChartElementType == ChartElementType.Title
            )
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void chart4_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Chart chart = sender as Chart;
            HitTestResult result = chart.HitTest(e.X, e.Y);
            if
            (
                result.ChartElementType == ChartElementType.DataPoint ||
                result.ChartElementType == ChartElementType.LegendItem 
            )
            {
                this.Cursor = Cursors.Hand;

                chart4.Series[result.Series.Name].ToolTip = "#LEGENDTEXT\nRechazos: #LABEL";
                chart4.Series[result.Series.Name].LegendToolTip = "Rechazos: #LABEL ";
                chart4.Series[result.Series.Name].LabelToolTip = "#LEGENDTEXT\nRechazos: #LABEL";
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void chart4_MouseDown(object sender, MouseEventArgs e)
        {
            /*
            Chart chart = sender as Chart;
            HitTestResult result = chart.HitTest(e.X, e.Y);
            DataPoint point = chart.Series[result.Series.Name].Points[result.PointIndex];

            chart4.Series[result.Series.Name].ToolTip = "#LEGENDTEXT\nRechazos: #LABEL";
            chart4.Series[result.Series.Name].LegendToolTip = "Rechazos: #LABEL ";
            chart4.Series[result.Series.Name].LabelToolTip = "#LEGENDTEXT\nRechazos: #LABEL";
//            chart4.Series[result.Series.Name].Points[1].ToolTip = "Unknown";
             */
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Filtros.stats_desde = FechaDesde.Value.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("es-ES"));
            Filtros.stats_hasta = FechaHasta.Value.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("es-ES"));

            loadStats();
        }

      
//            chart1.Series["Scrap"].Enabled = false;
//            reparaciones.Enabled = false;

//            CustomLabel element = ch.AxisX.CustomLabels.Add(0.5, 1.5, "Jan");
 //           ch.AxisX.CustomLabels.Add(element);//.GridTicks = GridTickTypes.All;.




    //        scrap.LegendText = "Scrap(" + scrap.Points.Count;

            /*
            for (int i = 0; i < salidas.Points.Count; i++)
            {
                salidas.Points[i].AxisLabel = salidas.Points[i].AxisLabel + "\n" + salidas.Points[i].YValues.First().ToString();
            }*/
            //            salidas.Points.ToList().ForEach(x => x.AxisLabel = string.Format("{0}\r\n{1:#,#}", x.AxisLabel, exceso.Points[4].YValues.First()));

            //            salidas.LabelBackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
 //           reparaciones.LabelBackColor = System.Drawing.ColorTranslator.FromHtml("#efefef");
//            reparaciones.LabelForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
            //            exceso.LabelBackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
        




        /*
     
        private void pies() {

            DataView firstView = new DataView(GTR2());

            Series ser = chart1.Series[0];

            ser["PixelPointWidth"] = "20";
            ser.IsValueShownAsLabel = true;

            ser.Points.DataBindXY(firstView, "Names", firstView, "Value");

 //           ser.Points[2].Color = System.Drawing.ColorTranslator.FromHtml("#FF0000");
//            ser.Points[0].Color = System.Drawing.ColorTranslator.FromHtml("#00FF00");
            ser.Points[0].AxisLabel = ser.Points[0].AxisLabel + "\n" + "100%";

            Series series2 = chart1.Series.Add("Lote: 1800");
            series2.ChartType = SeriesChartType.Spline;
            series2.BorderWidth = 2;

            int j = 0;
            Random rnd = new Random();
            int MaxPoints = 4;
            for (int i = 0; i < MaxPoints; i++)
            {
                    series2.Points.Add(1800);
            }
            series2.Color = System.Drawing.ColorTranslator.FromHtml("#FF0000");

            ChartArea area = chart1.ChartAreas["Default"];
            area.AxisY.Title = "PANELES SALIENTES";
            area.AxisY.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
            area.AxisX.IsMarginVisible = false;
            area.AxisY.IsMarginVisible = false;


            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
        }


        private void iniChart()
        {
            Random random = new Random();
            for (int pointIndex = 0; pointIndex < 5; pointIndex++)
            {
                chart1.Series["Series1"].Points.AddXY(pointIndex + 1, random.Next(10, 90));
            }

            Axis axisX = chart1.ChartAreas["Default"].AxisX;
            Axis axisY = chart1.ChartAreas["Default"].AxisY;

            // Set Y axis custom labels
            axisY.CustomLabels.Add(0, 30, "Low");
            axisY.CustomLabels.Add(30, 70, "Medium");
            axisY.CustomLabels.Add(70, 100, "High");

            // Set X axis custom labels
            CustomLabel customLabel;
            customLabel = axisX.CustomLabels.Add(0.5, 1.5, "Jan");
            customLabel.GridTicks = GridTickTypes.All;

            customLabel = axisX.CustomLabels.Add(1.5, 2.5, "Feb");
            customLabel.GridTicks = GridTickTypes.TickMark;

            customLabel = axisX.CustomLabels.Add(2.5, 3.5, "Mar");
            customLabel.GridTicks = GridTickTypes.All;

            customLabel = axisX.CustomLabels.Add(3.5, 4.5, "Apr");
            customLabel.GridTicks = GridTickTypes.TickMark;

            customLabel = axisX.CustomLabels.Add(4.5, 5.5, "May");
            customLabel.GridTicks = GridTickTypes.All;

            // set second row of labels
            axisX.CustomLabels.Add(1.0, 4.0, "Q1", 1, LabelMarkStyle.LineSideMark);
            axisX.CustomLabels.Add(4.0, 5.0, "Q2", 1, LabelMarkStyle.LineSideMark);

            // One more row of labels
            axisX.CustomLabels.Add(1.0, 5.0, "Year 2006", 2, LabelMarkStyle.LineSideMark);
        }
         */

    }
}
