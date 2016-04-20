using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Citra_Kumpul
{
    public partial class Form2 : Form
    {
        float[] h = new float[256], u = new float[256];
        public float[] ReturnArray { get; set; } //getter dan setter untuk array chart

        public Form2()
        {
            InitializeComponent();
            Shown += Form2_Shown; // memanggil method saat form dimuat
        }

        private void Form2_Shown(object sender, EventArgs e) // method yang dijalankan ketika form dimuat
        {
            chart2.Series["Series1"].Points.Clear();
            h = ReturnArray;                        // ambil nilai dari setter
            for (int i = 0; i < 256; i++)
            {
                chart2.Series["Series1"].Points.AddXY(i + 1, h[i]);
            }
        }
    }
}
