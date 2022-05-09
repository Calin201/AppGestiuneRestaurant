using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;
using NivelStocareDate;

namespace AppGestiuneRestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            //Argumente(args);

            //string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            //string _numeFisier = ConfigurationManager.AppSettings["_NumeFisier"];
            AdministrareIngredient_FisierText _administrareIngredient = new AdministrareIngredient_FisierText("Ingrediente.txt");
            AdministrareFelMancare_FisierText _administrareFelMancare = new AdministrareFelMancare_FisierText("FeluriMancare.txt");

            int nrFeluriMancare = 0;
            int nrIngrediente = 0;
            FelMancare[] FeluriMancare= _administrareFelMancare.GetFeluriMancare(out nrFeluriMancare);
            Ingredient[] Ingrediente = _administrareIngredient.GetIngrediente(out nrIngrediente);

            FelMancare felMancare = new FelMancare();
            Ingredient ingredient = new Ingredient();
            string optiune;
            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("------------------------F. Afisare feluri de mancare         ------------------------");
                Console.WriteLine("------------------------A. Afisare ingrediente achizitionate ------------------------");
                Console.WriteLine("------------------------S. Adaugare fel de mancare citit     ------------------------");
                Console.WriteLine("------------------------H. Adaugare ingredient citit         ------------------------");
                Console.WriteLine("------------------------C. Citire fel mancare                ------------------------");
                Console.WriteLine("------------------------K. Citire ingredient                 ------------------------");
                Console.WriteLine("------------------------L. Cautare fel mancare dupa nume     ------------------------");
                Console.WriteLine("------------------------Z. Cautare ingrediente dupa nume     ------------------------");
                Console.WriteLine("------------------------X. Inchidere program                 ------------------------");
                Console.WriteLine("------------------------Alegeti o optiune                    ------------------------\n");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "F":
                        FeluriMancare = _administrareFelMancare.GetFeluriMancare(out nrFeluriMancare);
                        AfisareFeluriMancare(FeluriMancare, nrFeluriMancare);
                        break;
                    case "A":
                        Ingrediente = _administrareIngredient.GetIngrediente(out nrIngrediente);
                        AfisareIngrediente(Ingrediente, nrIngrediente);
                        break;
                    case "S":
                        nrFeluriMancare++;
                        _administrareFelMancare.AddFelMancare(felMancare);
                        break;
                    case "H":
                        nrIngrediente++;
                        _administrareIngredient.AddIngredient(ingredient);
                        break;
                    case "C":
                        /*Laborator 3. Citire FelMancare*/
                        felMancare = new FelMancare();
                        felMancare.Citire();
                        break;
                    case "K":
                        /*Laborator 4. Citire Ingredient*/
                        ingredient = new Ingredient();
                        ingredient.Citire();
                        break;
                    case "L":
                        /*Laborator 3. Cautare dupa criterii*/
                        string numeFelMancare = Console.ReadLine();
                        FeluriMancare = _administrareFelMancare.GetFeluriMancare(out nrFeluriMancare);
                        FelMancare gasit = _administrareFelMancare.CautaFelMancare(FeluriMancare,numeFelMancare);
                        if (gasit.Denumire == null)
                        {
                            Console.WriteLine("Nu a fost gasit ingredientul cautat");
                        }
                        else
                        {
                            FelMancare[] temp = new FelMancare[1];
                            temp[0] = gasit;
                            AfisareFeluriMancare(temp, 1);
                        }
                        break;
                    case "Z":
                        /*Laborator 4. Cautare dupa criterii*/
                        string numeIngredient = Console.ReadLine();
                        Ingrediente = _administrareIngredient.GetIngrediente(out nrIngrediente);
                        Ingredient[] Gasite = _administrareIngredient.CautaIngredient(Ingrediente, numeIngredient);
                        if (Gasite.First().Denumire==null)
                        {
                            Console.WriteLine("Nu a fost gasit ingredientul cautat");
                        }
                        else
                        {
                            AfisareIngrediente(Gasite, Gasite.Length);
                        }
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }


        public static void AfisareFeluriMancare(FelMancare[] feluriMancare, int nrFeluriMancare)
        {
            Console.WriteLine("Felurile de mancare sunt:");
            for (int contor = 0; contor < nrFeluriMancare; contor++)
            {

                string infoFelMancare = $"{feluriMancare[contor].Denumire}\n";
                foreach(var ingrediente in feluriMancare[contor].ListaIngrediente)
                {
                    infoFelMancare += $"Ingredient:{ingrediente.Denumire} Cantitate: {ingrediente.Cantitate}\n";
                }
                Console.WriteLine(infoFelMancare);
                
            }
        }
        public static void AfisareIngrediente(Ingredient[] ingrediente, int nrIngrediente)
        {
            Console.WriteLine("Ingredientele achizitionate pana acum sunt:");
            for (int contor = 0; contor < nrIngrediente; contor++)
            {

                string infoIngredient = string.Format("Ingredient: {0} \n Cantitate: {1} \n Valabilitate: {2} - {3} ",
                   (ingrediente[contor].Denumire ?? " NECUNOSCUT "),
                   (ingrediente[contor].Cantitate),
                   (ingrediente[contor].DataAchizitie.ToString("d") ?? " NECUNOSCUT "),
                   (ingrediente[contor].DataExpirare.ToString("d") ?? " NECUNOSCUT ")
                   );

                Console.WriteLine(infoIngredient);
                
            }
        }
        public static void Argumente(string[] args)
        {
            int i = 0;

            var aca =args.GroupBy(arg => arg.First()).OrderBy(arg => arg.Key).ToList();
             string[][] t = new string[aca.Count()][];
             foreach(var beta in aca)
             {
                int j = 0;
                t[i]= new string[beta.Count()];
                 foreach (var xin in beta)
                {
                    t[i][j] = xin;
                    j++;
                }
                i++;
             }


            foreach (var linie in t)
            {
                Console.WriteLine($"{linie.First()[0]}:");
                foreach (var item in linie)
                {
                    Console.WriteLine(item + " ");
                }
                Console.WriteLine();
            }
            
            Console.ReadKey();
        }
    }

}


