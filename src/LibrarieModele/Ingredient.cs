using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public enum IngredienteUzuale
    {
        Apa=0,
        Zahar=1,
        Ulei,
        Lapte,
        LapteCondensat,
        Sare,
        Piper,
        Boia,
        PulpePui,
        CotletPorc,
        Cartofi,
        Morcovi,
        Unt,
        Paine,
        Gem,
        Oua,
        Varza,
        Salata,
        SosRoze,
        Ketchup,
        Maioneza,
        Mustar,
    }
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
            Denumire = "Undefined";
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
            if (linieFisier == string.Empty)
            {
                Denumire = "Undefined";
                Cantitate = 0;
                DataAchizitie = DateTime.MaxValue;
                DataExpirare = DateTime.MinValue;
            }
            else
            {
                var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

                //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
                Denumire = dateFisier[DENUMIRE];
                Cantitate = Convert.ToInt32(dateFisier[CANTITATE]);
                DataAchizitie = DateTime.ParseExact(dateFisier[DATAACHIZITIE],"dd/MM/yyyy", CultureInfo.InvariantCulture);
                DataExpirare = DateTime.ParseExact(dateFisier[DATAEXPIRARE], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
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
            if(options == "CreareIngredientMancare")
            {
                var campuri = _denumire.Split();
                Denumire = campuri[0];
                Cantitate = Convert.ToInt32(campuri[1]);
                DataAchizitie = DataExpirare = DateTime.MaxValue;
            }
        }
        public void Citire()
        {
            Console.WriteLine("Alegeti numarul ingredientului:");
            var ingredienteUzuale = Enum.GetValues(typeof(IngredienteUzuale));
            for (int i = 0; i < ingredienteUzuale.Length; i++) //IngredienteUzuale ingredient in Enum.GetValues(typeof(IngredienteUzuale)))
            {
                Console.WriteLine($"{(int)ingredienteUzuale.GetValue(i)}-{ingredienteUzuale.GetValue(i)}" +
                    $"\t\t\t" +
                    $"{(int)ingredienteUzuale.GetValue(i)}-{ingredienteUzuale.GetValue(i)}");
                
            }
            Console.WriteLine("Sau scrieti alt ingredient");
            var input= Console.ReadLine();
            int number;
            if (int.TryParse(input, out number))
            {
                Denumire = ((IngredienteUzuale)number).ToString();
            }
            else
            {
                Denumire = input;
            }
            Console.WriteLine("Alegeti cantitatea:");
            Cantitate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Alegeti data achizitiei sub forma xx/xx/20xx:");
            DataAchizitie = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("Alegeti data expirarii sub forma xx/xx/20xx:");
            DataExpirare = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        public string ConversieLaSir_PentruFisier()
        {
            string SirIngredientPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Denumire ?? "NECUNOSCUT"),
                Cantitate,
                DataAchizitie.ToString("dd/MM/yyyy"),
                DataExpirare.ToString("dd/MM/yyyy"));

            return SirIngredientPentruFisier;
        }
        public string ConversieLaSir_PentruFelMancare()
        {
            string SirIngredientePentruFisier = string.Format("{1} {2}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Denumire ?? "NECUNOSCUT"),
                Cantitate
                );
            return SirIngredientePentruFisier;
        }
    }
}