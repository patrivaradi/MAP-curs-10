using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace cursul_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.init_graph(pictureBox1);
            Engine.load(@"..\..\TextFile1.txt");
            for (int i = 0; i < Engine.n; i++)
            {
                string buffer = "";
                for (int j = 0; j < Engine.n; j++)
                {
                    buffer += Engine.ma[i, j] + " ";
                }
                
            }
            Engine.draw();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
