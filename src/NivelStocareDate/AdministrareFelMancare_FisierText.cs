using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AdministrareFelMancare_FisierText
    {
        private const int NR_MAX_FELURI_MANCARE = 200;
        private string numeFisier;
        public AdministrareFelMancare_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddFelMancare(FelMancare FelMancare)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(FelMancare.ConversieLaSir_PentruFisier());
            }
        }
        public FelMancare[] GetFeluriMancare(out int nrFeluriMancare)
        {
            FelMancare[] FeluriMancare = new FelMancare[NR_MAX_FELURI_MANCARE];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrFeluriMancare = 0;

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    FeluriMancare[nrFeluriMancare++] = new FelMancare(linieFisier);
                }
            }

            return FeluriMancare;
        }
        public FelMancare CautaFelMancare(FelMancare[] FeluriMancare, string denumire)
        {
            foreach (var mancare in FeluriMancare)
            {
                if (mancare.Denumire == denumire)
                    return mancare;
            }
            return new FelMancare();
        }
    }
}
