﻿using System;
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

namespace OkulProjesi
{
    public partial class FrmSınavNotlar : Form
    {
        public FrmSınavNotlar()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.TBLNOTLARTableAdapter ds = new DataSet1TableAdapters.TBLNOTLARTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-URKG832\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.NotListesi(int.Parse(TxtOgrId.Text));
        }

        
        private void FrmSınavNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLDERSLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDers.DisplayMember = "DERSAD";
            CmbDers.ValueMember = "DERSID";
            CmbDers.DataSource = dt;
            baglanti.Close();
        }

        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse ( dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtOgrId .Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
           TxtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        double sinav1, sinav2, sinav3, proje;

        double ortalama;

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit ();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmOgretmen frmOgretmen= new FrmOgretmen();
            frmOgretmen.Show();
            this.Hide();
        }

        string durum;
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            
            double ortalama;
            string durum;
            sinav1 = Convert.ToDouble(TxtSınav1.Text);
            sinav2 = Convert.ToDouble(TxtSınav2.Text);
            sinav3 = Convert.ToDouble (TxtSınav3.Text);
            proje = Convert. ToDouble(TxtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            TxtOrtalama.Text =(ortalama.ToString());
            if (ortalama >=50)
            {
                TxtDurum.Text = "Geçti";
            }
            else { TxtDurum.Text = "Kaldı"; }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            ds.NotGüncelle(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(TxtOgrId.Text),byte.Parse (TxtSınav1.Text), byte.Parse(TxtSınav2.Text), byte.Parse (TxtSınav3.Text) , byte.Parse (TxtProje.Text),decimal.Parse(TxtOrtalama.Text), bool.Parse(TxtDurum.Text), notid);
        }
    }
}
