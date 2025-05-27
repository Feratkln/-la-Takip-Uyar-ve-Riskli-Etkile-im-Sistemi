using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IlacTakipSistemi
{
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponents();
        }
        private void GirisForm_Load(object sender, EventArgs e)
        {
            
        }


        private void InitializeComponents()
        {
            this.Text = "Giriş";
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGray;
            this.ClientSize = new Size(400, 450);

           // kapatma
            var btnKapat = new Guna2Button
            {
                Text = "X",
                Size = new Size(30, 30),
                Location = new Point(360, 10),
                FillColor = Color.Red,
                ForeColor = Color.White,
                BorderRadius = 5
            };
            btnKapat.Click += (s, e) => this.Close();
            this.Controls.Add(btnKapat);

            
            var container = new Guna2Panel
            {
                Size = new Size(320, 300),
                Location = new Point(40, 75),
                BorderRadius = 20,
                FillColor = Color.White
            };
            this.Controls.Add(container);

            // başık
            var lblTitle = new Guna2HtmlLabel
            {
                Text = "İlaç Takip Sistemi",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(70, 15),
                AutoSize = true
            };
            container.Controls.Add(lblTitle);

            var txtKullaniciAdi = new Guna2TextBox
            {
                Name = "txtKullaniciAdi",
                PlaceholderText = "Kullanıcı Adı",
                Location = new Point(20, 70),
                Size = new Size(280, 40),
                BorderRadius = 10
            };
            container.Controls.Add(txtKullaniciAdi);

            var txtSifre = new Guna2TextBox
            {
                Name = "txtSifre",
                PlaceholderText = "Şifre",
                Location = new Point(20, 125),
                Size = new Size(280, 40),
                BorderRadius = 10,
                PasswordChar = '*'
            };
            container.Controls.Add(txtSifre);

            var btnGiris = new Guna2Button
            {
                Text = "Giriş Yap",
                Location = new Point(20, 190),
                Size = new Size(125, 40),
                BorderRadius = 10,
                FillColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White
            };
            btnGiris.Click += btnGiris_Click;
            container.Controls.Add(btnGiris);

            var btnKayit = new Guna2Button
            {
                Text = "Kayıt Ol",
                Location = new Point(175, 190),
                Size = new Size(125, 40),
                BorderRadius = 10,
                FillColor = Color.FromArgb(72, 133, 237),
                ForeColor = Color.White
            };
            btnKayit.Click += btnKayit_Click;
            container.Controls.Add(btnKayit);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            var txtKullaniciAdi = this.Controls.Find("txtKullaniciAdi", true).FirstOrDefault() as Guna2TextBox;
            var txtSifre = this.Controls.Find("txtSifre", true).FirstOrDefault() as Guna2TextBox;

            if (txtKullaniciAdi == null || txtSifre == null) return;

            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (VeriTabaniBaglanti.GirisYap(kullaniciAdi, sifre, out int kullaniciId))
            {
                Kullanici aktifKullanici = new Kullanici
                {
                    Id = kullaniciId,
                    KullaniciAdi = kullaniciAdi,
                    Sifre = sifre
                };

                Form1 form1 = new Form1(aktifKullanici);
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            KayitForm kayitForm = new KayitForm();
            kayitForm.ShowDialog();
        }
    }
}