using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Ingredient
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int DENUMIRE = 0;
        private const int CANTITATE = 1;
        private const int DATAACHIZITIE = 2;
        private const int DATAEXPIRARE = 3;


        public string Denumire { get; set; }
        public int Cantitate { get; set; }
        public DateTime DataAchizitie { get; set; }
        public DateTime DataExpirare { get; set; }

        public Ingredient()
        {
            Denumire = string.Empty;
            Cantitate = 0;
            DataAchizitie = DateTime.MaxValue;
            DataExpirare = DateTime.MinValue;
        }
        public Ingredient(int _cantitate, string _denumire, DateTime _dataAchizitie, DateTime _dataExpirare)
        {
            Denumire = _denumire;
            Cantitate = _cantitate;
            DataAchizitie = _dataAchizitie;
            DataExpirare = _dataExpirare;
        }
        public Ingredient(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            Denumire = dateFisier[DENUMIRE];
            Cantitate = Convert.ToInt32(dateFisier[CANTITATE]);
            DataAchizitie = Convert.ToDateTime(dateFisier[DATAACHIZITIE]);
            DataExpirare = Convert.ToDateTime(dateFisier[DATAEXPIRARE]);
        }
        public string ConversieLaSir_PentruFisier()
        {
            string SirIngredientPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Denumire ?? "NECUNOSCUT"),
                Cantitate,
                DataAchizitie.ToString(),
                DataExpirare.ToString());

            return SirIngredientPentruFisier;
        }
        public IList Returna
    }
}
