using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;


namespace IlacTakipSistemi
{
    public static class VeriTabaniBaglanti
    {
        private static string baglantiCumlesi = "Data Source=(localdb)\\TakipDB;Initial Catalog=takipVT;Persist Security Info=True;User ID=takipuser;Password=ferat1234;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;";

        public static bool GirisYap(string kullaniciAdi, string sifre, out int kullaniciId)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT Id FROM Kullanicilar WHERE KullaniciAdi=@kadi AND Sifre=@sifre", baglanti);
                komut.Parameters.AddWithValue("@kadi", kullaniciAdi);
                komut.Parameters.AddWithValue("@sifre", sifre);

                var sonuc = komut.ExecuteScalar();
                if (sonuc != null)
                {
                    kullaniciId = Convert.ToInt32(sonuc);
                    return true;
                }
                else
                {
                    kullaniciId = -1;
                    return false;
                }
            }
        }

        public static void KayitOl(string kullaniciAdi, string sifre)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO Kullanicilar (KullaniciAdi, Sifre) VALUES (@kadi, @sifre)", baglanti);
                komut.Parameters.AddWithValue("@kadi", kullaniciAdi);
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.ExecuteNonQuery();
            }
        }

        public static int IlacEkle(Ilac ilac, int kullaniciId)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand(@"
            INSERT INTO Ilac (KullaniciID, IlaclarId, Adi, Doz, AlmaSaati, BaslangicTarihi, BitisTarihi) 
            OUTPUT INSERTED.ID
            VALUES (@kid, @ilaclarId, @adi, @doz, @saat, @bas, @bit)", baglanti);

                komut.Parameters.AddWithValue("@kid", kullaniciId);
                komut.Parameters.AddWithValue("@ilaclarId", ilac.IlaclarId); // 🔸 Bu satır eklendi
                komut.Parameters.AddWithValue("@adi", ilac.Adi);
                komut.Parameters.AddWithValue("@doz", ilac.Doz);
                komut.Parameters.AddWithValue("@saat", ilac.AlmaSaati);
                komut.Parameters.AddWithValue("@bas", ilac.BaslangicTarihi);
                komut.Parameters.AddWithValue("@bit", ilac.BitisTarihi);

                int yeniId = (int)komut.ExecuteScalar();
                return yeniId;
            }
        }


        public static List<Ilac> IlaclariGetir(int kullaniciId)
        {
            List<Ilac> ilacListesi = new List<Ilac>();
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM Ilac WHERE KullaniciID=@kid", baglanti);
                komut.Parameters.AddWithValue("@kid", kullaniciId);
                SqlDataReader okuyucu = komut.ExecuteReader();

                while (okuyucu.Read())
                {
                    Ilac ilac = new Ilac
                    {
                        Id = (int)okuyucu["ID"],
                        IlaclarId = (int)okuyucu["IlaclarId"], // ✅ EKLENDİ
                        Adi = okuyucu["Adi"].ToString(),
                        Doz = (int)okuyucu["Doz"],
                        AlmaSaati = (TimeSpan)okuyucu["AlmaSaati"],
                        BaslangicTarihi = (DateTime)okuyucu["BaslangicTarihi"],
                        BitisTarihi = (DateTime)okuyucu["BitisTarihi"]
                    };
                    ilacListesi.Add(ilac);
                }
            }
            return ilacListesi;
        }

        public static List<Ilac> GenelIlaclariGetir()
        {
            List<Ilac> ilaclar = new List<Ilac>();
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM Ilaclar", baglanti); // Genel ilaçların olduğu tablo
                SqlDataReader okuyucu = komut.ExecuteReader();

                while (okuyucu.Read())
                {
                    Ilac ilac = new Ilac
                    {
                        Id = (int)okuyucu["Id"],
                        Adi = okuyucu["Adi"].ToString(),
                        Doz = Convert.ToDecimal(okuyucu["Doz"]),
                        AlmaSaati = TimeSpan.Zero, // 0 yap
                        BaslangicTarihi = DateTime.MinValue,
                        BitisTarihi = DateTime.MinValue
                    };
                    ilaclar.Add(ilac);
                }
            }
            return ilaclar;
        }
        public static void IlacSil(int ilacId, int kullaniciId)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("DELETE FROM Ilac WHERE Id = @id AND KullaniciId = @kullaniciId", baglanti);
                komut.Parameters.AddWithValue("@id", ilacId);
                komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                komut.ExecuteNonQuery();
            }
        }

        public static bool EtkilesimVarMi(string ilacAdi1, string ilacAdi2)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand(@"
            SELECT COUNT(*) FROM IlacEtkilesim 
            WHERE (Ilac1 = @i1 AND Ilac2 = @i2) OR (Ilac1 = @i2 AND Ilac2 = @i1)", baglanti);

                komut.Parameters.AddWithValue("@i1", ilacAdi1);
                komut.Parameters.AddWithValue("@i2", ilacAdi2);

                int sayi = (int)komut.ExecuteScalar();
                return sayi > 0;
            }
        }
        public static List<RiskliIlacEtkilesimi> RiskliEtkilesimleriGetir()
        {
            List<RiskliIlacEtkilesimi> liste = new List<RiskliIlacEtkilesimi>();

            using (SqlConnection conn = new SqlConnection(baglantiCumlesi))
            {
                conn.Open();
                string query = "SELECT Ilac1Id, Ilac2Id FROM RiskliIlacEtkilesimleri";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    liste.Add(new RiskliIlacEtkilesimi
                    {
                        Ilac1Id = reader.GetInt32(0),
                        Ilac2Id = reader.GetInt32(1)
                    });
                }
            }

            return liste;
        }

    }
}

