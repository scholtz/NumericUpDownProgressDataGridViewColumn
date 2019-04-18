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
    public class NumericUpDownProgressDataGridViewColumn : DataGridViewColumn
    {
        public NumericUpDownProgressDataGridViewColumn()
        {
            this.CellTemplate = new DataGridViewProgressCell();
        }

    }
}
