using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlDeReparacion
{
    class gridEdit
    {
        public int col = 0;
        public int row = 0;
        public DataGridView grid;
        private DataGridViewCell celda;
        private string valorAnterior; 

        public void set(DataGridView _grid,int _col,int _row)
        {
            grid = _grid;
            col = _col;
            row = _row;

            celda = grid.Rows[row].Cells[col];
            valorAnterior = celda.Value.ToString();
        }

        public void ComboBox(string[] data)
        {
            grid.ReadOnly = false;

            DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
            combo.Items.AddRange(data);

            grid.Rows[row].Cells[col] = combo; // Seteo control comboBox
            celda = grid.Rows[row].Cells[col];

            grid.CurrentCell = celda;
            grid.BeginEdit(true);

            grid.CellEndEdit += gridPlacas_fin_combo;
        }

        public void TextArea()
        {
            grid.ReadOnly = false;

            grid.CurrentCell = celda;
            grid.BeginEdit(true);

            grid.CellEndEdit += gridPlacas_fin_texto;
        }

        private void gridPlacas_fin_texto(object sender, DataGridViewCellEventArgs e)
        {
            string nuevo = celda.Value.ToString();
            MessageBox.Show("Set: " + nuevo);

            grid.CellEndEdit -= gridPlacas_fin_texto;
            grid.ReadOnly = true;
        }

        private void gridPlacas_fin_combo(object sender, DataGridViewCellEventArgs e)
        {
            string nuevo = "";
            DataGridViewCell comboCell = grid.Rows[row].Cells[col];
            if (comboCell.Value == null)
            {
                nuevo = valorAnterior;
            }
            else
            {
                nuevo = comboCell.Value.ToString();
            }

            DataGridViewTextBoxCell text = new DataGridViewTextBoxCell();
            text.Value = nuevo;

            grid.Rows[row].Cells[col] = text; // Seteo nuevo control - TextArea

            grid.CellEndEdit -= gridPlacas_fin_combo;
            grid.ReadOnly = true;
        }
    }
}
