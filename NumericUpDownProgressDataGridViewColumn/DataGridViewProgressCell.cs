using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumericUpDownProgressDataGridViewColumn
{
    [
        ComVisible(true),
        ClassInterface(ClassInterfaceType.AutoDispatch)
    ]
    public class DataGridViewProgressCell : DataGridViewTextBoxCell
    {
        public override Type EditType => typeof(NumericUpDownEditCell);
        public override Type ValueType => typeof(decimal);
        public override object DefaultNewRowValue => 0;
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            NumericUpDownEditCell ctl = DataGridView.EditingControl as NumericUpDownEditCell;
            // Use the default row value when Value property is null.
            if (this.Value == null)
            {
                ctl.Value = (decimal)this.DefaultNewRowValue;
            }
            else
            {
                ctl.Value = (decimal)this.Value;
            }

        }

        protected override void Paint(
            Graphics graphics,
            Rectangle clipBounds,
            Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates cellState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // Call the base class method to paint the default cell appearance.
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
                value, formattedValue, errorText, cellStyle,
                advancedBorderStyle, paintParts);

            // Retrieve the client location of the mouse pointer.
            Point cursorPosition =
                this.DataGridView.PointToClient(Cursor.Position);

            Rectangle fullRect = new Rectangle(cellBounds.X + 1,
                cellBounds.Y + 1, cellBounds.Width - 4,
                cellBounds.Height - 4);
            var valueMax1 = Math.Min(Convert.ToDecimal(value), 100) / 100;
            Rectangle newRect = new Rectangle(cellBounds.X + 1,
                cellBounds.Y + 1, Convert.ToInt32(Math.Round(cellBounds.Width * valueMax1)) - 4,
                cellBounds.Height - 4);
            graphics.FillRectangle(Brushes.White, fullRect);
            graphics.DrawRectangle(Pens.Green, newRect);
            graphics.FillRectangle(Brushes.GreenYellow, newRect);
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 10);

            graphics.DrawString((Convert.ToDecimal(value)).ToString("N2") + " %", drawFont, Brushes.DarkGray, new Point(cellBounds.X, cellBounds.Y));
        }

        // Force the cell to repaint itself when the mouse pointer enters it.
        protected override void OnMouseEnter(int rowIndex)
        {
            this.DataGridView.InvalidateCell(this);
        }

        // Force the cell to repaint itself when the mouse pointer leaves it.
        protected override void OnMouseLeave(int rowIndex)
        {
            this.DataGridView.InvalidateCell(this);
        }
    }
}
