using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;


namespace AppGestiuneRestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            Argumente(args);
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


