﻿using LibrarieModele;
using System.IO;



namespace NivelStocareDate
{
    public class AdministrareIngredient_FisierText
    {
        private const int NR_MAX_Ingrediente = 50;
        private string numeFisier;
        public AdministrareIngredient_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddAlimentBaza(Ingredient alimentBaza)
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
            Ingredient[] ingrediente = new Ingredient[NR_MAX_Ingrediente];

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
    }
}