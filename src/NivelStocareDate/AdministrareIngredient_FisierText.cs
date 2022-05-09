using LibrarieModele;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NivelStocareDate
{
    public class AdministrareIngredient_FisierText
    {
        private const int NR_MAX_INGREDIENTE = 200;
        private string numeFisier;
        public AdministrareIngredient_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddIngredient(Ingredient alimentBaza)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(alimentBaza.ConversieLaSir_PentruFisier());
            }
        }
        public Ingredient[] GetIngrediente(out int nrIngrediente)
        {
            Ingredient[] ingrediente = new Ingredient[NR_MAX_INGREDIENTE];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrIngrediente = 0;

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    ingrediente[nrIngrediente++] = new Ingredient(linieFisier);
                }
            }

            return ingrediente;
        }
        public Ingredient[] CautaIngredient(Ingredient[] ingrediente, string denumire)
        {
            IList<Ingredient> ingrediente_gasite = null;
            foreach (var ingr in ingrediente)
            {
                if (ingr.Denumire == denumire)
                    ingrediente_gasite.Add(ingr);
            }
            if (ingrediente_gasite.Count == 0)
            {
                return new Ingredient[1];
            }
            else
            {
                return ingrediente_gasite.ToArray();
            }

        }
    }
}
