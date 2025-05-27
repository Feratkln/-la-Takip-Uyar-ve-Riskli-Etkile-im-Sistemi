using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlacTakipSistemi
{
    public class Ilac
    {
        public int Id { get; set; } 
        public int IlaclarId { get; set; }
        public string Adi { get; set; }
        public decimal Doz { get; set; }
        public TimeSpan AlmaSaati { get; set; }
        public DateTime BaslangicTarihi { get; set; }  
        public DateTime BitisTarihi { get; set; }      


        public override string ToString()
        {
            return $"{Adi} - {Doz} mg - {AlmaSaati.ToString(@"hh\:mm")} ({BaslangicTarihi:dd.MM.yyyy} - {BitisTarihi:dd.MM.yyyy})";
        }
    }
}
