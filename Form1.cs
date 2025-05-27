using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IlacTakipSistemi;
using Guna.UI2.WinForms;
using System.Media;

namespace IlacTakipSistemi
{
    public partial class Form1 : Form
    {
        private Kullanici aktifKullanici; // Aktif kullanıcı bilgisi tut  
        private System.Windows.Forms.Timer ilacTimer;

        List<Ilac> genelIlaclar = new List<Ilac>();
        public Form1(Kullanici kullanici)
        {
            InitializeComponent();
            this.aktifKullanici = kullanici;

            this.Load += Form1_Load;

            ilacTimer = new System.Windows.Forms.Timer();
            ilacTimer.Interval = 60000;
            ilacTimer.Tick += ilacTimer_Tick;
        }
        private void ilacTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            foreach (var ilac in ilacListesi)
            {
                if (now.Date >= ilac.BaslangicTarihi.Date && now.Date <= ilac.BitisTarihi.Date)
                {
                    TimeSpan fark = now.TimeOfDay - ilac.AlmaSaati;

                    if (Math.Abs(fark.TotalMinutes) < 1)
                    {
                        SystemSounds.Exclamation.Play();
                        MessageBox.Show($"İlacınızı almanız gerekiyor: {ilac.Adi} - {ilac.Doz} mg", "İlaç Hatırlatma");
                    }
                }
            }
        }

        List<Ilac> ilacListesi = new List<Ilac>();
        private void Form1_Load(object sender, EventArgs e)
        {
            // Verileri çek
            ilacListesi = VeriTabaniBaglanti.IlaclariGetir(aktifKullanici.Id);

            // DataGridView'e veri bağla
            dgvIlaclar.DataSource = null;
            dgvIlaclar.DataSource = ilacListesi;
            if (dgvIlaclar.Columns.Contains("AlmaSaati"))
            {
                dgvIlaclar.Columns["AlmaSaati"].DefaultCellStyle.Format = @"hh\:mm";
            }

            if (dgvIlaclar.Columns.Contains("Id"))
                dgvIlaclar.Columns["Id"].Visible = false;

            if (dgvIlaclar.Columns.Contains("IlaclarId"))
                dgvIlaclar.Columns["IlaclarId"].Visible = false;

            if (dgvIlaclar.Columns.Contains("Adi"))
                dgvIlaclar.Columns["Adi"].HeaderText = "İlaç Adı";

            if (dgvIlaclar.Columns.Contains("Doz"))
                dgvIlaclar.Columns["Doz"].HeaderText = "Doz (mg)";

            if (dgvIlaclar.Columns.Contains("AlmaSaati"))
                dgvIlaclar.Columns["AlmaSaati"].HeaderText = "Saat";

            if (dgvIlaclar.Columns.Contains("BaslangicTarihi"))
                dgvIlaclar.Columns["BaslangicTarihi"].HeaderText = "Başlangıç";

            if (dgvIlaclar.Columns.Contains("BitisTarihi"))
                dgvIlaclar.Columns["BitisTarihi"].HeaderText = "Bitiş";

            RiskliEtkilesimKontrolEt(ilacListesi);

            // Cmbbox ı doldur
            genelIlaclar = VeriTabaniBaglanti.GenelIlaclariGetir();
            cmbIlaclar.DisplayMember = "Adi";
            cmbIlaclar.ValueMember = "Id";
            cmbIlaclar.DataSource = genelIlaclar;

            ilacTimer.Start();
        }

        private void RiskliEtkilesimKontrolEt(List<Ilac> kullaniciIlaclari)
        {
            var riskliList = VeriTabaniBaglanti.RiskliEtkilesimleriGetir();

            var ilaclarIdList = kullaniciIlaclari.Select(i => i.IlaclarId).ToList();

            foreach (var etkilesim in riskliList)
            {
                bool varMi = ilaclarIdList.Contains(etkilesim.Ilac1Id) && ilaclarIdList.Contains(etkilesim.Ilac2Id);

                if (varMi)
                {
                    string ilac1Adi = kullaniciIlaclari.FirstOrDefault(i => i.IlaclarId == etkilesim.Ilac1Id)?.Adi ?? "Bilinmiyor";
                    string ilac2Adi = kullaniciIlaclari.FirstOrDefault(i => i.IlaclarId == etkilesim.Ilac2Id)?.Adi ?? "Bilinmiyor";

                    MessageBox.Show(
                        $"Dikkat! '{ilac1Adi}' ve '{ilac2Adi}' ilaçları bir arada alınmamalıdır.",
                        "Riskli İlaç Etkileşimi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }
        
        private void btnIlacEkle_Click(object sender, EventArgs e)
        {
            if (cmbIlaclar.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ilaç seçin.");
                return;
            }

            Ilac secilenIlac = (Ilac)cmbIlaclar.SelectedItem;

            var yeniIlac = new Ilac
            {
                IlaclarId = secilenIlac.Id,
                Adi = secilenIlac.Adi,
                Doz = (int)numDoz.Value,
                AlmaSaati = dtpSaat.Value.TimeOfDay,
                BaslangicTarihi = dtpBaslangic.Value.Date,
                BitisTarihi = dtpBitis.Value.Date,
            };

            //VT EKLE
            int yeniIlacId = VeriTabaniBaglanti.IlacEkle(yeniIlac, aktifKullanici.Id);
            yeniIlac.Id = yeniIlacId;

            //LİSTEYİ ÇEK
            ilacListesi = VeriTabaniBaglanti.IlaclariGetir(aktifKullanici.Id);

            // Dgv güncelle
            dgvIlaclar.DataSource = null;
            dgvIlaclar.DataSource = ilacListesi;
            if (dgvIlaclar.Columns.Contains("AlmaSaati"))
            {
                dgvIlaclar.Columns["AlmaSaati"].DefaultCellStyle.Format = @"hh\:mm";
            }
            // kolonları gizle
            if (dgvIlaclar.Columns.Contains("Id"))
                dgvIlaclar.Columns["Id"].Visible = false;

            if (dgvIlaclar.Columns.Contains("IlaclarId"))
                dgvIlaclar.Columns["IlaclarId"].Visible = false;

            // Başlık özelleştir
            if (dgvIlaclar.Columns.Contains("Adi"))
                dgvIlaclar.Columns["Adi"].HeaderText = "İlaç Adı";

            if (dgvIlaclar.Columns.Contains("Doz"))
                dgvIlaclar.Columns["Doz"].HeaderText = "Doz (mg)";

            if (dgvIlaclar.Columns.Contains("AlmaSaati"))
                dgvIlaclar.Columns["AlmaSaati"].HeaderText = "Alma Saati";

            if (dgvIlaclar.Columns.Contains("BaslangicTarihi"))
                dgvIlaclar.Columns["BaslangicTarihi"].HeaderText = "Başlangıç";

            if (dgvIlaclar.Columns.Contains("BitisTarihi"))
                dgvIlaclar.Columns["BitisTarihi"].HeaderText = "Bitiş";



            RiskliEtkilesimKontrolEt(ilacListesi);

            // alanı Temizle
            numDoz.Value = 1;
            dtpSaat.Value = DateTime.Now;
        }

        // ilaçı ekle
        private void btnIlacSil_Click(object sender, EventArgs e)
        {
            if (dgvIlaclar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir ilaç seçin.");
                return;
            }

            // ilacı al
            Ilac seciliIlac = (Ilac)dgvIlaclar.SelectedRows[0].DataBoundItem;

            // Veritabanından sil
            VeriTabaniBaglanti.IlacSil(seciliIlac.Id, aktifKullanici.Id);

            // Bellekten sil
            ilacListesi.Remove(seciliIlac);

            // Dgv güncelle
            dgvIlaclar.DataSource = null;
            dgvIlaclar.DataSource = ilacListesi;

            if (dgvIlaclar.Columns.Contains("AlmaSaati"))
            {
                dgvIlaclar.Columns["AlmaSaati"].DefaultCellStyle.Format = @"hh\:mm";
            }
            MessageBox.Show("İlaç başarıyla silindi.");
            // kolonları gizle
            if (dgvIlaclar.Columns.Contains("Id"))
                dgvIlaclar.Columns["Id"].Visible = false;

            if (dgvIlaclar.Columns.Contains("IlaclarId"))
                dgvIlaclar.Columns["IlaclarId"].Visible = false;

            // Başlıkl özelleştir
            if (dgvIlaclar.Columns.Contains("Adi"))
                dgvIlaclar.Columns["Adi"].HeaderText = "İlaç Adı";

            if (dgvIlaclar.Columns.Contains("Doz"))
                dgvIlaclar.Columns["Doz"].HeaderText = "Doz (mg)";

            if (dgvIlaclar.Columns.Contains("AlmaSaati"))
                dgvIlaclar.Columns["AlmaSaati"].HeaderText = "Alma Saati";

            if (dgvIlaclar.Columns.Contains("BaslangicTarihi"))
                dgvIlaclar.Columns["BaslangicTarihi"].HeaderText = "Başlangıç";

            if (dgvIlaclar.Columns.Contains("BitisTarihi"))
                dgvIlaclar.Columns["BitisTarihi"].HeaderText = "Bitiş";
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void dgvIlaclar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

