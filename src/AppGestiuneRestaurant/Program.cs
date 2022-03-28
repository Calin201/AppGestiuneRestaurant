using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestiuneRestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            var da = new AlimentBaza();
            Console.WriteLine(da.Cantitate);
            Console.WriteLine(da.Denumire);
            Console.WriteLine(da.DataAchizitie);
            Console.WriteLine(da.DataExpirare);
            Console.ReadKey();
            da = new AlimentBaza(69, "Cu Bianca", DateTime.Now, DateTime.Now);
            Console.WriteLine(da.Cantitate);
            Console.WriteLine(da.Denumire);
            Console.WriteLine(da.DataAchizitie);
            Console.WriteLine(da.DataExpirare);
            Console.ReadKey();
        }
    }
}
