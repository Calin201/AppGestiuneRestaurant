using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarieModele;
using NivelStocareDate;
namespace WindowToInformation
{

       
    public partial class FereastraPrincipala : Form
    {
        static AdministrareIngredient_FisierText _administrareIngredient = new AdministrareIngredient_FisierText("Ingrediente.txt");
        static AdministrareFelMancare_FisierText _administrareFelMancare = new AdministrareFelMancare_FisierText("FeluriMancare.txt");

        int nrFeluriMancare = 0;
        int nrIngrediente = 0;
        FelMancare[] FeluriMancare = _administrareFelMancare.GetFeluriMancare(out int nrFeluriMancare);
        Ingredient[] Ingrediente = _administrareIngredient.GetIngrediente(out int nrIngrediente);




        public FereastraPrincipala()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
