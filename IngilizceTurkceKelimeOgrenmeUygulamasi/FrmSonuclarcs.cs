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
    public partial class FrmSonuclarcs : Form
    {
        public FrmSonuclarcs()
        {
            InitializeComponent();
        }
        OleDbConnection oldbbaglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\fenny\Desktop\eğitim proje dökümanları\ingilizce kelime öğrenme projesi dökümanları\dbSozluk.accdb");

        private void FrmSonuclarcs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbSozlukDataSet.TblKullanici' table. You can move, or remove it, as needed.
            //this.tblKullaniciTableAdapter.Fill(this.dbSozlukDataSet.TblKullanici);
            oldbbaglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select KullaniciAdıSoyadı as 'Ad Soyad', DogruSayisi as 'Doğru Sayısı' from TblKullanici", oldbbaglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            oldbbaglanti.Close();

        }
    }
}
