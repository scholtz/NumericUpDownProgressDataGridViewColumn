using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public class SampleClass
        {
            public string Name { get; set; }
            public decimal Value { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.Columns.Add(new DataGridViewRolloverCell())

            sampleClassBindingSource.Add(new SampleClass() { Name = "First", Value = 15M });
            sampleClassBindingSource.Add(new SampleClass() { Name = "Second", Value = 90M });
            sampleClassBindingSource.Add(new SampleClass() { Name = "Third", Value = 30M });
        }
    }
}
