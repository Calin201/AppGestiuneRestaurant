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
            var da = new Ingredient();
            Console.WriteLine(da.Cantitate);
            Console.WriteLine(da.Denumire);
            Console.WriteLine(da.DataAchizitie);
            Console.WriteLine(da.DataExpirare);
            Console.ReadKey();
            da = new Ingredient(69, "Cu Bianca", DateTime.Now, DateTime.Now);
            Console.WriteLine(da.Cantitate);
            Console.WriteLine(da.Denumire);
            Console.WriteLine(da.DataAchizitie);
            Console.WriteLine(da.DataExpirare);
            Console.ReadKey();
        }
    }
}
