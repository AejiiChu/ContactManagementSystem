using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManagementSystem
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }
        // 🟦 Panel hover
        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            p.BackColor = Color.FromArgb(200, 220, 255);
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            p.BackColor = Color.Transparent;
        }

        // 🟩 Icon hover + zoom
        private void Icon_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.LightBlue;
            pb.Size = new Size(pb.Width + 5, pb.Height + 5);
        }

        private void Icon_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.Transparent;
            pb.Size = new Size(pb.Width - 5, pb.Height - 5);
        }










        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide(); 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valorant is not good for you, go to Contacts only 😆");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Minecraft is too addicting, go to Contacts only 😆");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stop league its toxic, go to Contacts only 😆");

        }


    }
}
