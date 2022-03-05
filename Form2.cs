using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thats_right
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public Form2()
        {
            InitializeComponent();
            instance = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (File.Exists("Words.txt"))
            {
                Form1 form = new Form1();

                form.Show();
            }
            else
                MessageBox.Show("There is no file");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("Words.txt"))
            {
                Form3 form = new Form3();
                form.Show();
            }
                else
                MessageBox.Show("There is no file");
        }
    }
}
