using System.Windows.Forms;

namespace Symulator.Interface.Control
{
    public class FastDataGridView : DataGridView
    {
        public FastDataGridView()
        {
            this.DoubleBuffered = true;
            this.AutoGenerateColumns = false;
            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }
    }
}
