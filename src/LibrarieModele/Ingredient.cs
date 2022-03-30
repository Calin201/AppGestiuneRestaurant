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

        //private int Id;
        public string Denumire { get; set; }
        public int Cantitate { get; set; }
        public DateTime DataAchizitie { get; set; }
        public DateTime DataExpirare { get; set; }

        public Ingredient()
        {
            Denumire = null;
            Cantitate = 0;
            DataAchizitie = DateTime.MaxValue;
            DataExpirare = DateTime.MinValue;
        }
        public Ingredient( string _denumire, int _cantitate, DateTime _dataAchizitie, DateTime _dataExpirare)
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
        public Ingredient(string _denumire, string options)
        {
            if (options == "IngredientMancare")
            {
                Denumire = _denumire;
                Console.WriteLine("Cantitatea:");
                Cantitate = Convert.ToInt32(Console.ReadLine());
                DataAchizitie = DataExpirare = DateTime.MaxValue;
            }
        }
        public void Citire()
        {
            Console.WriteLine("Alegeti numele ingredientului:");
            Denumire = Console.ReadLine();
            Console.WriteLine("Alegeti cantitatea:");
            Cantitate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Alegeti data achizitiei sub forma xx.xx.20xx:");
            DataAchizitie = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Alegeti data expirarii sub forma xx.xx.20xx:");
            DataExpirare = Convert.ToDateTime(Console.ReadLine());
        }
        public string ConversieLaSir_PentruFisier()
        {
            string SirIngredientPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Denumire ?? "NECUNOSCUT"),
                Cantitate,
                DataAchizitie.ToString("d"),
                DataExpirare.ToString("d"));

            return SirIngredientPentruFisier;
        }
        public string ConversieLaSir_PentruFelMancare()
        {
            string SirIngredientePentruFisier = string.Format("{0}{1} {2}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Denumire ?? "NECUNOSCUT"),
                Cantitate
                );
            return SirIngredientePentruFisier;
        }
    }
}
