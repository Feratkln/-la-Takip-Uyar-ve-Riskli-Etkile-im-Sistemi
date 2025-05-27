using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlacTakipSistemi
{
    internal class MockDataBase
    {
        public static List<Kullanici> KullaniciListesi = new List<Kullanici>()
          {
        new Kullanici { KullaniciAdi = "admin", Sifre = "1234" },
        new Kullanici { KullaniciAdi = "user1", Sifre = "abcd" }
        
    };
        public static Dictionary<string, List<Ilac>> KullaniciIlaclari = new Dictionary<string, List<Ilac>>();
    }
}
