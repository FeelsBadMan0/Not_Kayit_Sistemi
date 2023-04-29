using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Not_Kayit_Sistemi
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }


        public string numara;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PNOIT9G\\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True");
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLDERS where OGRNUMARA =@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                lblSınav1.Text = dr[4].ToString();
                lblSınav2.Text = dr[5].ToString();
                lblSınav3.Text = dr[6].ToString();
                lblOrtalama.Text = dr[7].ToString();
                lblDurum.Text = dr[8].ToString();

                if (lblDurum.Text == "True")
                {
                    lblDurum.Text = "Geçti";
                }
                else
                {
                    lblDurum.Text = "Kaldı";
                }
            }

            baglanti.Close();
        }
    }
}
