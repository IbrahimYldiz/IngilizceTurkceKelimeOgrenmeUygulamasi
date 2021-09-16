using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace IngilizceTurkceKelimeOgrenmeUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection oldbbaglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\fenny\Desktop\eğitim proje dökümanları\ingilizce kelime öğrenme projesi dökümanları\dbSozluk.accdb");
        Random rast = new Random();
        int sure = 20;
        int kelime = 0;
        public string isim;
        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = isim;

        }
        void getir()
        {
            int sayi;
            sayi = rast.Next(1, 2489);
            
            oldbbaglanti.Open();
            OleDbCommand oledbkomut = new OleDbCommand("Select * from sozluk where id=@p1", oldbbaglanti);
            oledbkomut.Parameters.AddWithValue("@p1", sayi);
            OleDbDataReader dr = oledbkomut.ExecuteReader();
            while (dr.Read())
            {
                TxtIngilizce.Text = dr[1].ToString();
                LblCevap.Text = dr[2].ToString().ToLower();
            }
            oldbbaglanti.Close();
            LblHataliBildirimi.Visible = false;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sure = 20;
            getir();
        }

        private void BtnKontrol_Click(object sender, EventArgs e)
        {
            LblHataliBildirimi.Visible = false;
            
            
            if (TxtIngilizce.Text.Trim()!="")
            {
                
                if (TxtTurkce.Text.ToLower() == LblCevap.Text)
                {
                    kelime++;
                    LblKelime.Text = kelime.ToString();
                    getir();
                    TxtTurkce.Clear();
                    sure = 20;
                }
                else
                {
                    LblHataliBildirimi.Text = "Hatalı Cevap";
                    LblHataliBildirimi.Visible = true;
                    
                    
                }
                
                
                
            }
            if(TxtIngilizce.Text.Trim()=="")
            {
                LblHataliBildirimi.Visible = true;
                LblHataliBildirimi.Text = "Lütfen Kelime Getir Butonuna Basınız.";
            }
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sure--;
            LblSure.Text = sure.ToString();
            if (sure==0)
            {
                oldbbaglanti.Open();
                OleDbCommand komut2 = new OleDbCommand("INSERT INTO TblKullanici (KullaniciAdıSoyadı,DogruSayisi)"+" values (@p1,@p2)", oldbbaglanti);
                komut2.Parameters.AddWithValue("@p1", isim);
                komut2.Parameters.AddWithValue("@p2", LblKelime.Text);
                komut2.ExecuteNonQuery();
                oldbbaglanti.Close();
                TxtTurkce.Enabled = false;
                LblCevap.Visible = true;
                timer1.Stop();
                MessageBox.Show("Süre İçerisinde Cevap Veremediniz." + " Cevap: " + LblCevap.Text);
                
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmSonuclarcs fr = new FrmSonuclarcs();
            fr.Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
