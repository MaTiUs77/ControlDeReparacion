namespace ControlDeReparacion
{
    partial class formStat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartAll = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graficos_barra = new System.Windows.Forms.TableLayoutPanel();
            this.chartM = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_estadisticas = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label_sector = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartAll)).BeginInit();
            this.graficos_barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel_estadisticas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartAll
            // 
            chartArea1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea1.Name = "Default";
            this.chartAll.ChartAreas.Add(chartArea1);
            this.chartAll.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartAll.Legends.Add(legend1);
            this.chartAll.Location = new System.Drawing.Point(3, 3);
            this.chartAll.Name = "chartAll";
            series1.BackSecondaryColor = System.Drawing.Color.Transparent;
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.CustomProperties = "LabelStyle=Top";
            series1.IsValueShownAsLabel = true;
            series1.IsVisibleInLegend = false;
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.LabelBorderColor = System.Drawing.Color.LightGray;
            series1.Legend = "Legend1";
            series1.MarkerStep = 2;
            series1.Name = "Series1";
            this.chartAll.Series.Add(series1);
            this.chartAll.Size = new System.Drawing.Size(377, 167);
            this.chartAll.TabIndex = 1;
            this.chartAll.Text = "chart1";
            this.chartAll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barra_MouseDown);
            this.chartAll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            // 
            // graficos_barra
            // 
            this.graficos_barra.ColumnCount = 1;
            this.graficos_barra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.graficos_barra.Controls.Add(this.chartAll, 0, 0);
            this.graficos_barra.Controls.Add(this.chartM, 0, 1);
            this.graficos_barra.Controls.Add(this.chartT, 0, 2);
            this.graficos_barra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graficos_barra.Location = new System.Drawing.Point(0, 0);
            this.graficos_barra.Name = "graficos_barra";
            this.graficos_barra.RowCount = 3;
            this.graficos_barra.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.graficos_barra.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.graficos_barra.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.graficos_barra.Size = new System.Drawing.Size(383, 519);
            this.graficos_barra.TabIndex = 3;
            // 
            // chartM
            // 
            chartArea2.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea2.Name = "Default";
            this.chartM.ChartAreas.Add(chartArea2);
            this.chartM.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartM.Legends.Add(legend2);
            this.chartM.Location = new System.Drawing.Point(3, 176);
            this.chartM.Name = "chartM";
            series2.BackSecondaryColor = System.Drawing.Color.Transparent;
            series2.ChartArea = "Default";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series2.CustomProperties = "LabelStyle=Top";
            series2.IsValueShownAsLabel = true;
            series2.IsVisibleInLegend = false;
            series2.LabelBackColor = System.Drawing.Color.White;
            series2.LabelBorderColor = System.Drawing.Color.LightGray;
            series2.Legend = "Legend1";
            series2.MarkerStep = 2;
            series2.Name = "Series1";
            this.chartM.Series.Add(series2);
            this.chartM.Size = new System.Drawing.Size(377, 167);
            this.chartM.TabIndex = 1;
            this.chartM.Text = "chart1";
            this.chartM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barra_MouseDown);
            this.chartM.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            // 
            // chartT
            // 
            chartArea3.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea3.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea3.Name = "Default";
            this.chartT.ChartAreas.Add(chartArea3);
            this.chartT.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartT.Legends.Add(legend3);
            this.chartT.Location = new System.Drawing.Point(3, 349);
            this.chartT.Name = "chartT";
            series3.BackSecondaryColor = System.Drawing.Color.Transparent;
            series3.ChartArea = "Default";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.CustomProperties = "LabelStyle=Top";
            series3.IsValueShownAsLabel = true;
            series3.IsVisibleInLegend = false;
            series3.LabelBackColor = System.Drawing.Color.White;
            series3.LabelBorderColor = System.Drawing.Color.LightGray;
            series3.Legend = "Legend1";
            series3.MarkerStep = 2;
            series3.Name = "Series1";
            this.chartT.Series.Add(series3);
            this.chartT.Size = new System.Drawing.Size(377, 167);
            this.chartT.TabIndex = 1;
            this.chartT.Text = "chart1";
            this.chartT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barra_MouseDown);
            this.chartT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            // 
            // chart4
            // 
            chartArea4.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea4.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea4.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea4.Name = "Default";
            this.chart4.ChartAreas.Add(chartArea4);
            this.chart4.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.IsDockedInsideChartArea = false;
            legend4.Name = "Legend1";
            this.chart4.Legends.Add(legend4);
            this.chart4.Location = new System.Drawing.Point(0, 0);
            this.chart4.Name = "chart4";
            series4.BackSecondaryColor = System.Drawing.Color.Transparent;
            series4.ChartArea = "Default";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series4.CustomProperties = "PieDrawingStyle=Concave, PieLabelStyle=Outside, LabelStyle=Top";
            series4.IsValueShownAsLabel = true;
            series4.IsVisibleInLegend = false;
            series4.LabelBackColor = System.Drawing.Color.White;
            series4.LabelBorderColor = System.Drawing.Color.LightGray;
            series4.Legend = "Legend1";
            series4.MarkerStep = 2;
            series4.Name = "Series1";
            this.chart4.Series.Add(series4);
            this.chart4.Size = new System.Drawing.Size(603, 519);
            this.chart4.TabIndex = 6;
            this.chart4.Text = "chart1";
            this.chart4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart4_MouseDown);
            this.chart4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart4_MouseMove);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel_estadisticas, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1004, 600);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // panel_estadisticas
            // 
            this.panel_estadisticas.Controls.Add(this.splitContainer1);
            this.panel_estadisticas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_estadisticas.Location = new System.Drawing.Point(3, 74);
            this.panel_estadisticas.Name = "panel_estadisticas";
            this.panel_estadisticas.Size = new System.Drawing.Size(998, 523);
            this.panel_estadisticas.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.graficos_barra);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart4);
            this.splitContainer1.Size = new System.Drawing.Size(998, 523);
            this.splitContainer1.SplitterDistance = 387;
            this.splitContainer1.TabIndex = 0;
            // 
            // label_sector
            // 
            this.label_sector.AutoSize = true;
            this.label_sector.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sector.Location = new System.Drawing.Point(388, 18);
            this.label_sector.Name = "label_sector";
            this.label_sector.Padding = new System.Windows.Forms.Padding(5);
            this.label_sector.Size = new System.Drawing.Size(125, 36);
            this.label_sector.TabIndex = 1;
            this.label_sector.Text = "SECTOR: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.FechaDesde);
            this.groupBox1.Controls.Add(this.FechaHasta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label_sector);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(998, 65);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasta";
            // 
            // FechaDesde
            // 
            this.FechaDesde.CustomFormat = "dd/MM/yyyy";
            this.FechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaDesde.Location = new System.Drawing.Point(15, 32);
            this.FechaDesde.Name = "FechaDesde";
            this.FechaDesde.Size = new System.Drawing.Size(121, 24);
            this.FechaDesde.TabIndex = 16;
            // 
            // FechaHasta
            // 
            this.FechaHasta.CustomFormat = "dd/MM/yyyy";
            this.FechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaHasta.Location = new System.Drawing.Point(142, 32);
            this.FechaHasta.Name = "FechaHasta";
            this.FechaHasta.Size = new System.Drawing.Size(121, 24);
            this.FechaHasta.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 17;
            this.button1.Text = "Aplicar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // formStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 600);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "formStat";
            this.Text = "Estadisticas";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.formStat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartAll)).EndInit();
            this.graficos_barra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel_estadisticas.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartAll;
        private System.Windows.Forms.TableLayoutPanel graficos_barra;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartM;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartT;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel_estadisticas;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label_sector;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FechaDesde;
        private System.Windows.Forms.DateTimePicker FechaHasta;
        private System.Windows.Forms.Button button1;


    }
}