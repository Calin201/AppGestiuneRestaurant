using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class FelMancare
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int DENUMIRE = 0;
        private const int LISTAINGREDIENTE = 1;

        string Denumire { get; set; }
        IList<Ingredient> ListaIngrediente { get; set; }


        public FelMancare()
        {
            Denumire = string.Empty;
            ListaIngrediente = null;
        }
        public FelMancare(string _denumire,IList<Ingredient> _listaIngrediente)
        {
            Denumire = _denumire;
            ListaIngrediente = _listaIngrediente;
        }
        public FelMancare(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            Denumire = dateFisier[DENUMIRE];
            ListaIngrediente = dateFisier[LISTAINGREDIENTE].map;
        }
        public string ConversieLaSir_PentruFisier()
        {
            string SirIngredientPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Denumire ?? "NECUNOSCUT"),
                "WIP"   // WIP
                );

            return SirIngredientPentruFisier;
        }

    }
}
