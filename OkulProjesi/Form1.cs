using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OkulProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            FrmOgranciNotlar frm = new FrmOgranciNotlar();
            frm.numara = TxtNumaraGirisi.Text;
            frm.Show();
            FrmOgranciNotlar.ActiveForm.Text = TxtNumaraGirisi.Text;   //textbox 1 deki değeri form textine yazdırma
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //if (NumaraGirisi.Text == " ")
            //{
            //    MessageBox.Show("Lütfen Numara Giriniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            FrmOgretmen fr = new FrmOgretmen();
            fr.Show();
            this.Hide();
        }

    }
}
