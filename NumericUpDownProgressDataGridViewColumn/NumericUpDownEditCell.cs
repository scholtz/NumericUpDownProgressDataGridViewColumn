using System;
using System.Collections.Generic;
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
    public class NumericUpDownEditCell : NumericUpDown, IDataGridViewEditingControl
    {
        public NumericUpDownEditCell() : base()
        {
            Minimum = 0;
            Maximum = 100;
            Increment = 10M;

        }
        public DataGridView EditingControlDataGridView { get; set; }
        public object EditingControlFormattedValue
        {
            get {
                return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            }
            set {
                if (value is string)
                {
                    if (decimal.TryParse((string)value, out var val))
                    {
                        this.Value = val;
                    }
                }
                else
                {
                    this.Value = Convert.ToDecimal(value);
                }
            }
        }
        public int EditingControlRowIndex { get; set; }
        public bool EditingControlValueChanged { get; set; }
        public Cursor EditingPanelCursor => this.Cursor;
        public bool RepositionEditingControlOnValueChange => false;


        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.BackColor = dataGridViewCellStyle.BackColor;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            return true;
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {

            return this.Value.ToString("N2");
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {

        }

        protected override void OnValueChanged(EventArgs e)
        {
            EditingControlValueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(e);
        }

    }
}
