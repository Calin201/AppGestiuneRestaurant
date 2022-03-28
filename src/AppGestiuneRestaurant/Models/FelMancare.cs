using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestiuneRestaurant.Models
{
    class FelMancare
    {
        string Denumire { get; set; }
        IList<AlimentBaza> ListaIngrediente { get; set; }

    }
}
