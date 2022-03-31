using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class FelMancare
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = '`';
        private const char SEPARATOR_LISTA_INGREDIENTE = '-';
        private const int DENUMIRE = 1;
        private const int LISTAINGREDIENTE = 2;

        public string Denumire { get; set; }
        public List<Ingredient> ListaIngrediente { get; set; }


        public FelMancare()
        {
            Denumire = null;
            ListaIngrediente= new List<Ingredient> { new Ingredient() } ;
        }
        public FelMancare(string _denumire,List<Ingredient> _listaIngrediente)
        {
            Denumire = _denumire;
            ListaIngrediente = _listaIngrediente;
        }
        public FelMancare(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            int flag = 0;
            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            Denumire = dateFisier[DENUMIRE];
            ListaIngrediente = new List<Ingredient> { new Ingredient() };
            foreach (var data in dateFisier[LISTAINGREDIENTE].Split(SEPARATOR_LISTA_INGREDIENTE))
            {
                ListaIngrediente.Append<Ingredient>(new Ingredient(data ?? string.Empty));
            }
            ListaIngrediente.RemoveAt(0);
        }
        public void Citire()
        {
            Console.WriteLine("Alegeti un nume sugestiv felului de mancare:");
            Denumire= Console.ReadLine();
            Console.WriteLine("Va rugam introduceti numele si gramajul fiecarui ingredient si apoi scrieti stop pentru a va opri:");
            Console.WriteLine("Denumirea:");
            string denumire = Console.ReadLine();
            do
            {
                Ingredient temp = new Ingredient(denumire, "IngredientMancare");

                ListaIngrediente.Append(temp);
                Console.WriteLine("Denumirea:");
                denumire = Console.ReadLine();
            } while (denumire.ToUpper() != "STOP");
            
        }
        private string ListaIngrediente_PentruFisier()
        {
            string ListaIngredientePentruFisier = SEPARATOR_LISTA_INGREDIENTE.ToString();

            for(int i=0;i<ListaIngrediente.Count;i++)
            {
                if (ListaIngrediente.First().Denumire != null)
                {
                    ListaIngredientePentruFisier += ListaIngrediente[i].ConversieLaSir_PentruFelMancare() + SEPARATOR_LISTA_INGREDIENTE;
                }
            }
            return ListaIngredientePentruFisier;
        }
        public string ConversieLaSir_PentruFisier()
        {
            string SirIngredientPentruFisier = string.Format("{0}{1}{0}\n{2}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Denumire ?? "NECUNOSCUT"),
                ListaIngrediente_PentruFisier()
                );

            return SirIngredientPentruFisier;
        }

    }
}
