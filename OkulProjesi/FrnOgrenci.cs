using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace OkulProjesi
{
    public partial class FrnOgrenci : Form
    {
        public FrnOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Purple;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Red;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Transparent;
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-URKG832\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds =new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FrnOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLKULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt= new DataTable();
            da.Fill(dt);
            CmbKulup.DisplayMember = "KULUPAD";
            CmbKulup.ValueMember = "KULUPID";
            CmbKulup.DataSource = dt;  
            baglanti.Close();
        }
        string c = " ";
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked==true)
            {
                c = "Kız";
            }
            if (radioButton2.Checked==true)
            {
                c = "Erkek";
            }
            ds.OgrenciEkle(TxtOgrAd.Text, TxtOgrSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Kaydı Başırılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
           

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void CmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TxtOgrId.Text = CmbKulup.SelectedValue.ToString();  kulüp id sini ogrid ye yazdırıyor.
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(TxtOgrId.Text));
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtOgrId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOgrAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtOgrSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            label5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (label5.Text=="Kız")
            {

                radioButton1.Checked = true;
            }
           
            if (label5.Text=="Erkek")
            {
                radioButton2.Checked = true;
            }
            
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGüncelle(TxtOgrAd.Text,TxtOgrSoyad.Text,byte.Parse( CmbKulup.SelectedValue.ToString()),c,int.Parse(TxtOgrId.Text));
            MessageBox.Show("Kayıt Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
          
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=  ds.OgrenciGetir(int.Parse(TxtAra.Text));
        }
    }
}
