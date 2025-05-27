using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace IlacTakipSistemi
{
    public partial class KayitForm : Form
    {
        private Guna2TextBox txtKullanici;
        private Guna2TextBox txtSifre;
        private Guna2Button btnKayit;
        private Guna2HtmlLabel lblBaslik;

        public KayitForm()
        {
            InitializeComponents();
        }
        private void KayitForm_Load(object sender, EventArgs e)
        {

        }
        private void InitializeComponents()
        {
            this.Text = "Kayıt Ol";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.White;

            lblBaslik = new Guna2HtmlLabel()
            {
                Text = "Kayıt Ol",
                Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold),
                AutoSize = false,
                Size = new System.Drawing.Size(380, 50),
                Location = new System.Drawing.Point(10, 10),
                TextAlignment = ContentAlignment.MiddleCenter, 
            };
            this.Controls.Add(lblBaslik);

            txtKullanici = new Guna2TextBox()
            {
                PlaceholderText = "Kullanıcı Adı",
                Location = new System.Drawing.Point(50, 80),
                Size = new System.Drawing.Size(300, 40),
                BorderRadius = 10
            };
            this.Controls.Add(txtKullanici);

            txtSifre = new Guna2TextBox()
            {
                PlaceholderText = "Şifre",
                Location = new System.Drawing.Point(50, 130),
                Size = new System.Drawing.Size(300, 40),
                PasswordChar = '*',
                BorderRadius = 10
            };
            this.Controls.Add(txtSifre);

            btnKayit = new Guna2Button()
            {
                Text = "Kayıt Ol",
                Location = new System.Drawing.Point(50, 190),
                Size = new System.Drawing.Size(300, 45),
                BorderRadius = 10,
                FillColor = System.Drawing.Color.MediumSlateBlue,
                ForeColor = System.Drawing.Color.White
            };
            btnKayit.Click += btnKayit_Click;
            this.Controls.Add(btnKayit);
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullanici.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz.", "Hata");
                return;
            }

            if (KullaniciVarMi(kullaniciAdi))
            {
                MessageBox.Show("Bu kullanıcı adı zaten mevcut.");
                return;
            }

            VeriTabaniBaglanti.KayitOl(kullaniciAdi, sifre);
            MessageBox.Show("Kayıt başarılı.");
            this.Close();
        }

        private bool KullaniciVarMi(string kullaniciAdi)
        {
            string baglantiCumlesi = "Data Source=(localdb)\\TakipDB;Initial Catalog=takipVT;Persist Security Info=True;User ID=takipuser;Password=ferat1234;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;";

            using (var baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                var komut = new SqlCommand("SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi=@kadi", baglanti);
                komut.Parameters.AddWithValue("@kadi", kullaniciAdi);
                int sayi = (int)komut.ExecuteScalar();
                return sayi > 0;
            }
        }
    }
}
