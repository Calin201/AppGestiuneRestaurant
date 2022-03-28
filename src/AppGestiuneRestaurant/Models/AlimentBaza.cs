using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestiuneRestaurant.Models
{
    class AlimentBaza
    {
        public string Denumire { get; set; }
        public int Cantitate { get; set; }
        public DateTime DataAchizitie { get; set; }
        public DateTime DataExpirare { get; set; }

        public AlimentBaza()
        {
            Denumire = string.Empty;
            Cantitate = 0;
            DataAchizitie = DateTime.MaxValue;
            DataExpirare = DateTime.MinValue;
        }
        public AlimentBaza(int _cantitate, string _denumire,DateTime _dataAchizitie,DateTime _dataExpirare)
        {
            Denumire = _denumire;
            Cantitate = _cantitate;
            DataAchizitie = _dataAchizitie;
            DataExpirare = _dataExpirare;
        }
        
    }
}
