using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace cursul_10
{
    class Engine
    {
        public static Bitmap bmp;
        public static Graphics grp;
        public static PictureBox display;
        public static Color backcolor = Color.LightBlue;

        public static void init_graph(PictureBox _display)
        {
            display = _display;
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(backcolor);
            display.Image = bmp;
        }

        public static void refresh()
        {
            display.Image = bmp;
        }

        public static int[,] ma;
        public static int n;
        public static void load(string fileName)
        {
            TextReader load = new StreamReader(fileName);
            n = int.Parse(load.ReadLine());
            ma = new int[n, n];
            string buffer;
            while ((buffer = load.ReadLine()) != null)
            {
                int i = int.Parse(buffer.Split(' ')[0]);
                int j = int.Parse(buffer.Split(' ')[1]);
                ma[i, j] = 1;
                ma[j, i] = 1;
            }
        }
        public static void draw()
        {
            float alfa = (float)(Math.PI * 2) / n;
            PointF[] coord = new PointF[n];
            PointF C = new PointF(display.Width / 2, display.Height / 2);
            float R = 150;
            for (int i = 0; i < n; i++)
            {
                float x = C.X + R*(float)Math.Cos(alfa * i);
                float y= C.Y + R*(float)Math.Sin(alfa * i);
                coord[i] = new PointF(x, y);
            }
            for (int i = 0; i < n; i++)
            {
                grp.DrawEllipse(Pens.Black, coord[i].X - 5, coord[i].Y - 5, 11, 11);
                grp.DrawString(i.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Red, coord[i]);
            }
            for (int i = 0; i <n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (ma[i, j] != 0)
                        grp.DrawLine(Pens.Black, coord[i], coord[j]);
                }

            }
            refresh();
        }
    }
}
