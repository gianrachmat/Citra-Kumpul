using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace Citra_Kumpul
{
    public partial class Form1 : Form
    {
        Image file;
        Bitmap bmp, bmp1;
        private float[] h = new float[256], rs = new float[256], //deklarasi variabel
            gs = new float[256], bs = new float[256];            //
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(135, 135);                     // membuat objek Bitmap kosong dengan ukuran 135 x 135
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.GaussianBlur3x3);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.GaussianBlur5x5);

            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Mean3x3);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Mean5x5);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Mean7x7);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Mean9x9);

            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Median3x3);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Median5x5);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Median7x7);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Median9x9);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Median11x11);

            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur5x5);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur5x5At135Degrees);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur5x5At45Degrees);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur7x7);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur7x7At135Degrees);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur7x7At45Degrees);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur9x9);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur9x9At135Degrees);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur9x9At45Degrees);

            cmbBlurFilter.SelectedIndex = 0;
        }
        
        private void button1_Click(object sender, EventArgs e)          // memuat file dengan openFileDialog
        {
            openFileDialog1.Title = "Select an image file.";
            openFileDialog1.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            openFileDialog1.Filter += "|Bitmap Images(*.bmp)|*.bmp";
            DialogResult d = openFileDialog1.ShowDialog();
            
            if (d == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = file;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = saveFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                file.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(file);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, w);
                }
            }
            pictureBox2.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(135, 135);
            
            int r, g, b;
            Color c = new Color();
            
            r = int.Parse(textBox1.Text);
            g = int.Parse(textBox2.Text);
            b = int.Parse(textBox3.Text);
            c = Color.FromArgb(r, g, b);

            for (int x = 0; x<bmp.Width; x++)
            {
                for(int y = 0; y<bmp.Height; y++)
                {
                    bmp.SetPixel(x, y, c);
                }
            }

            pictureBox6.Image = bmp;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            bmp1 = new Bitmap(bmp);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    bmp1.SetPixel(x, y, Color.Red);
                }
            }
            pictureBox3.Image = bmp1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            bmp1 = new Bitmap(bmp);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    bmp1.SetPixel(x, y, Color.FromArgb(0,255,0));
                }
            }
            pictureBox4.Image = bmp1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox7.Image);
            bmp1 = new Bitmap(bmp);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    bmp1.SetPixel(x, bmp.Height - 1 - y, w);
                }
            }
            pictureBox9.Image = bmp1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox7.Image);
            bmp1 = new Bitmap(bmp);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    bmp1.SetPixel(bmp.Height - 1 - y, x, w);
                }
            }
            pictureBox10.Image = bmp1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox7.Image);
            bmp1 = new Bitmap(bmp);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    bmp1.SetPixel(bmp.Width - 1 - x, bmp.Height - 1 - y, w);
                }
            }
            pictureBox11.Image = bmp1;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            bmp1 = new Bitmap(bmp);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    bmp1.SetPixel(x, y, Color.Blue);
                }
            }
            pictureBox5.Image = bmp1;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox12.Image);
            bmp1 = new Bitmap(bmp);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y=0; y< bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((r + g + b) / 3);
                    int xk = 16 * (int)(xg / 16);
                    Color nw = Color.FromArgb(xk, xk, xk);
                    bmp1.SetPixel(x, y, nw);
                }
            }
            pictureBox13.Image = bmp1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox12.Image);
            bmp1 = new Bitmap(bmp);
            int kuan = int.Parse(textBox4.Text);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((r + g + b) / 3);
                    int xk = kuan * (int)(xg / kuan);
                    Color nw = Color.FromArgb(xk, xk, xk);
                    bmp1.SetPixel(x, y, nw);
                }
            }
            pictureBox14.Image = bmp1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox16.Image = file;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear();
            chart2.Series["Series1"].Points.Clear(); //
            chart3.Series["Series1"].Points.Clear();// 
            chart4.Series["Series1"].Points.Clear();//
            bmp = new Bitmap(pictureBox16.Image);
            
            int i;
            for (i = 0; i < 256; i++)
            {
                h[i] = 0;
                rs[i] = 0;
                gs[i] = 0;
                bs[i] = 0;
            }
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((w.R + w.G + w.B) / 3);
                    h[xg] = h[xg] + 1;
                    rs[r] = rs[r] + 1;
                    gs[g] = gs[g] + 1;
                    bs[b] = bs[b] + 1;
                }
            }
            for (i = 0; i < 256; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i + 1, h[i]);
                chart2.Series["Series1"].Points.AddXY(i + 1, rs[i]);
                chart3.Series["Series1"].Points.AddXY(i + 1, gs[i]);
                chart4.Series["Series1"].Points.AddXY(i + 1, bs[i]);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox15.Image = file;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox15.Image);
            int kx = int.Parse(textBox5.Text);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    int red = w.R + kx;
                    if (red > 255) red = 255;
                    if (red < 0) red = 0;
                    int green = w.G + kx;
                    if (green > 255) green = 255;
                    if (green < 0) green = 0;
                    int blue = w.B + kx;
                    if (blue > 255) blue = 255;
                    if (blue < 0) blue = 0;
                    Color warna = Color.FromArgb(red, green, blue);
                    bmp.SetPixel(x, y, warna);
                }
            }
            pictureBox17.Image = bmp;
        }

        private void chart2_Click(object sender, EventArgs e) //klik pada chart RED
        {
            Form2 fr2 = new Form2();
            fr2.ReturnArray = rs;
            fr2.Show();
        }

        private void chart3_Click(object sender, EventArgs e) // klik pada chart GREEN
        {
            Form2 fr2 = new Form2();
            fr2.ReturnArray = gs;
            fr2.Show();
        }

        private void chart4_Click(object sender, EventArgs e) // klik pada chart BLUE
        {
            Form2 fr2 = new Form2();
            fr2.ReturnArray = bs;
            fr2.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox19.Image = file;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox20.Image = file;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            bmp  = new Bitmap(pictureBox19.Image);
            bmp1 = new Bitmap(pictureBox20.Image);
            Bitmap bmp2 = new Bitmap(bmp);
            double v1 = 0.5, v2 = 0.5;

            for (int x = 0; x < bmp.Height; x++)
            {
                for (int y = 0; y < bmp.Width; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    int r1 = w.R, g1 = w.G, b1 = w.B;
                    w = bmp1.GetPixel(x, y);
                    int r2 = w.R, g2 = w.G, b2 = w.B;
                    int r = (int)((v1 * r1) + (v2 * r2));
                    int g = (int)((v1 * g1) + (v2 * g2));
                    int b = (int)((v1 * b1) + (v2 * b2));
                    w = Color.FromArgb(r, g, b);
                    bmp2.SetPixel(x, y, w);
                }
            }
            pictureBox21.Image = bmp2;
        }

        private void button17_Click(object sender, EventArgs e)     // auto levels
        {
            int xmax = 0, xmin = 255;   
            bmp = new Bitmap(pictureBox15.Image);

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    int r = w.R, g = w.G, b = w.B;
                    if (r < xmin) xmin = r;
                    if (r > xmax) xmax = r;
                    if (g < xmin) xmin = g;
                    if (g > xmax) xmax = g;
                    if (b < xmin) xmin = b;
                    if (b > xmax) xmax = b;
                }
            }
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    int xr = w.R, xg = w.G, xb = w.B;
                    xr = (int)(255 * (xr - xmin) / (xmax - xmin));
                    xg = (int)(255 * (xg - xmin) / (xmax - xmin));
                    xb = (int)(255 * (xb - xmin) / (xmax - xmin));
                    Color nw = Color.FromArgb(xr, xg, xb);
                    bmp.SetPixel(x, y, nw);
                }
            }
            pictureBox18.Image = bmp;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            pictureBox16.Image = pictureBox18.Image;
        }

        private void chart1_Click(object sender, EventArgs e) // klik pada chart GRAYSCALE
        {
            Form2 fr2 = new Form2();            // buat objek dari form2
            fr2.ReturnArray = h;                // memberi nilai pada setter returnArray
            fr2.Show();                         // menampilkan form2
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox7.Image);
            bmp1 = new Bitmap(bmp);
            for (int x=0; x<bmp.Width; x++)
            {
                for (int y=0; y<bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    bmp1.SetPixel(bmp.Width - 1 - x, y, w);
                }
            }
            pictureBox8.Image = bmp1;
        }

        private Bitmap originalBitmap = null;

        private void grayscale_button_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(input_trans.Image);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((w.R + w.G + w.B) / 3);
                    w = Color.FromArgb(xg, xg, xg);
                    bmp.SetPixel(x, y, w);
                }
            }
            output_trans.Image = bmp;
        }

        private void input_trans_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                input_trans.Image = file;
            }
        }

        private void negative_button_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(input_trans.Image);
            int max = track_bar_trans.Value;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    int r = w.R, g = w.G, b = w.B;
                    w = Color.FromArgb(255 - r, 255 - g, 255 - b);
                    bmp.SetPixel(x, y, w);
                }
            }
            output_trans.Image = bmp;
        }

        private void LOG_button_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(input_trans.Image);
            int c = int.Parse(nilai_c_filter.Text);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    int r = w.R, g = w.G, b = w.B;
                    r = (int)(c * Math.Log(r + 1));
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    g = (int)(c * Math.Log(g + 1));
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    b = (int)(c * Math.Log(b + 1));
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;
                    w = Color.FromArgb(r, g, b);
                    bmp.SetPixel(x, y, w);
                }
            }
            output_trans.Image = bmp;
        }

        private void inverse_LOG_button_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(input_trans.Image);
            int c = int.Parse(nilai_c_filter.Text);
            int max = track_bar_trans.Value;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    int r = w.R, g = w.G, b = w.B;

                    r = (int)(c * Math.Log(max-(r + 1)));
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    g = (int)(c * Math.Log(max-(g + 1)));
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    b = (int)(c * Math.Log(max-(b + 1)));
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;
                    w = Color.FromArgb(r, g, b);
                    bmp.SetPixel(x, y, w);
                }
            }
            output_trans.Image = bmp;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void output_trans_Click(object sender, EventArgs e)
        {
            DialogResult d = saveFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                file = output_trans.Image;
                file.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
            }
        }

        private void nth_power_button_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(input_trans.Image);
            int c = int.Parse(nilai_c_filter.Text);
            int ny = int.Parse(nilai_y_filter.Text);
            double thc = (float)(c / 100.0);
            double thy = (float)(ny / 100.0);

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    int r = w.R, g = w.G, b = w.B;

                    r = (int)(thc * Math.Pow(r, 1.0 / thy));
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    g = (int)(thc * Math.Pow(g, 1.0 / thy));
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    b = (int)(thc * Math.Pow(b, 1.0 / thy));
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;

                    w = Color.FromArgb(r, g, b);
                    bmp.SetPixel(x, y, w);
                }
            }
            output_trans.Image = bmp;
        }

        private void nth_root_power_button_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(input_trans.Image);
            int c = int.Parse(nilai_c_filter.Text);
            int ny = int.Parse(nilai_y_filter.Text);
            double thc = (float)(c / 100.0);
            double thy = (float)(ny / 100.0);

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color w = bmp.GetPixel(x, y);
                    int r = w.R, g = w.G, b = w.B;

                    r = (int)(thc * Math.Pow(r, thy));
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    g = (int)(thc * Math.Pow(g, thy));
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    b = (int)(thc * Math.Pow(b, thy));
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;
                    /*int gray = (int)((r + g + b) / 3);
                    gray = (int)(thc * Math.Pow(gray, thy));
                    if (gray > 255) gray = 255;
                    if (gray < 0) gray = 0;*/


                    w = Color.FromArgb(r, g, b);
                    bmp.SetPixel(x, y, w);
                }
            }
            output_trans.Image = bmp;
        }

        private Bitmap toGrayScale(Bitmap bits)
        {
            for (int x = 0; x < bits.Width; x++)
            {
                for (int y =0; y < bits.Height; y++)
                {
                    Color w = bits.GetPixel(x, y);
                    int r = w.R, g = w.G, b = w.B;
                    int gray = (int)((r + g + b) / 3);
                    w = Color.FromArgb(gray, gray, gray);
                    bits.SetPixel(x, y, w);
                }
            }
            return bits;
        }

        private void contrass_enhanc_Click(object sender, EventArgs e)
        {

        }

        private Bitmap invert(Bitmap bitmp)
        {
            IR ir = new IR();
            bitmp =  new Bitmap(ir.InvertImageColorMatrix(bitmp));
            return bitmp;
        }

        private void ir_picBox_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                ir_picBox.Image = file;
            }
            bmp = new Bitmap(ir_picBox.Image);
            bmp = toGrayScale(bmp);
            bmp = invert(bmp);
            ir_output.Image = bmp;
        }

        private void ir_button_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(ir_picBox.Image);
            bmp = ImageProcessing.Process(bmp, new BrightnessCorrection());
            bmp = ImageProcessing.Process(bmp, new SaturationCorrection(0.35f));
            bmp = ImageProcessing.Process(bmp, new HueModifier(30));
            ir_output.Image = bmp;
        }

        private void ir_output_Click(object sender, EventArgs e)
        {

        }

        private void trackbarTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CobaTrackBar cbtb = new CobaTrackBar();
            cbtb.ShowDialog();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(ir_picBox.Image);
            hue_label.Text = "" + hue_track_bar.Value;
            bmp = new Bitmap(ir_picBox.Image);
            bmp1 = bmp;
            if (hue_track_bar.Value == 0)
                ir_output.Image = bmp1;
            else
            {
                bmp = ImageProcessing.Process(bmp, new HueModifier(hue_track_bar.Value));
                ir_output.Image = bmp;
            }
            bmp = bit;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            int satur_value = saturation_track_bar.Value;
            float percent = satur_value / 100;
            saturation_label.Text = "" + saturation_track_bar.Value;
            bmp = new Bitmap(ir_picBox.Image);
            bmp1 = bmp;
            if (saturation_track_bar.Value == 0)
            {
                ir_output.Image = bmp1;
            }
            else
            {
                bmp = ImageProcessing.Process(bmp, new SaturationCorrection(satur_value));
                ir_output.Image = bmp;
            }
            bmp1 = bmp;
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(135, 135);

            for(int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (y <= bmp.Height / 2) bmp.SetPixel(x, y, Color.Red);
                    else bmp.SetPixel(x, y, Color.White);
                }
            }
            pictureBox22.Image = bmp;
        }

        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;

        private void ApplyFilter(bool preview)
        {
            if (previewBitmap == null || cmbBlurFilter.SelectedIndex == -1)
            {
                return;
            }

            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;

            if (preview == true)
            {
                selectedSource = previewBitmap;
            }
            else
            {
                selectedSource = originalBitmap;
            }

            if (selectedSource != null)
            {
                ExtBitmap.BlurType blurType =
                    ((ExtBitmap.BlurType)cmbBlurFilter.SelectedItem);

                bitmapResult = selectedSource.ImageBlurFilter(blurType);
            }

            if (bitmapResult != null)
            {
                if (preview == true)
                {
                    input_filter.Image = bitmapResult;
                }
                else
                {
                    resultBitmap = bitmapResult;
                }
            }
        }

        private void FilterValueChangedEventHandler(object sender, EventArgs e)
        {
            ApplyFilter(true);
        }

    }
}
