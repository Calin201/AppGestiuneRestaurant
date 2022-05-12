using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
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
        static string numeFisierIngrediente = "Ingrediente.txt";
        static string numeFisierFeluriMancare = "FeluriMancare.txt";
        static string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        static string caleCompletaFisierIngrediente = locatieFisierSolutie + "\\" + numeFisierIngrediente;
        static string caleCompletaFisierFeluriMancare = locatieFisierSolutie + "\\" + numeFisierFeluriMancare;
        AdministrareIngredient_FisierText _administrareIngredient = new AdministrareIngredient_FisierText(caleCompletaFisierIngrediente);
        AdministrareFelMancare_FisierText _administrareFelMancare = new AdministrareFelMancare_FisierText(caleCompletaFisierFeluriMancare);

        //FelMancare[] FeluriMancare = _administrareFelMancare.GetFeluriMancare(out int nrFeluriMancare);
        //Ingredient[] Ingrediente = _administrareIngredient.GetIngrediente(out int nrIngrediente);


        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 100;
        private const int OFFSET_X = 100;




        public FereastraPrincipala()
        {
            InitializeComponent();
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Gestiune Restaurant";
            label1.Text = "Ingrediente";
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Afiseaza_Ingrediente();
            //Afiseaza_FeluriMancare();
        }
        private void Afiseaza_Ingrediente()
        {
            Ingredient[] Ingrediente = _administrareIngredient.GetIngrediente(out int nrIngrediente);
            dataGridView1.ColumnCount = 4;
            DeleteGridInfo();
            dataGridView1.Columns[0].Name = "Denumire";
            dataGridView1.Columns[1].Name = "Cantitate";
            dataGridView1.Columns[2].Name = "Data Achizitiei";
            dataGridView1.Columns[3].Name = "Data Expirarii";

            for (int i = 0; i < nrIngrediente; i++)
            {

                string[] linie = {Ingrediente[i].Denumire, Ingrediente[i].Cantitate.ToString(),
                    Ingrediente[i].DataAchizitie.ToString("dd/MM/yyyy"),Ingrediente[i].DataExpirare.ToString("dd/MM/yyyy") };
                dataGridView1.Rows.Add(linie);

            }

        }
        private void Afiseaza_FeluriMancare()
        {
            FelMancare[] FeluriMancare = _administrareFelMancare.GetFeluriMancare(out int nrFeluriMancare);

            dataGridView1.ColumnCount = 2;
            DeleteGridInfo();
            dataGridView1.Columns[0].Name = "Denumire";
            dataGridView1.Columns[1].Name = "Ingrediente";


            for (int i = 0; i < nrFeluriMancare; i++)
            {

                string[] linie = { FeluriMancare[i].Denumire, FeluriMancare[i].ListaIngrediente[0].Denumire };
                for (int j = 1; j < FeluriMancare[i].ListaIngrediente.Count; j++)
                {
                    linie[1] += "," + FeluriMancare[i].ListaIngrediente[0].Denumire;
                }
                dataGridView1.Rows.Add(linie);
            }

        }


        private void DeleteGridInfo()
        {
            while (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows.RemoveAt(0);
        }
        private void DeleteBoxes()
        {
            this.Controls.Remove(textBox1);
            this.Controls.Remove(textBox2);
            this.Controls.Remove(dateTimePicker1);
            this.Controls.Remove(dateTimePicker2);
            this.Controls.Remove(button5);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteBoxes();
            this.Controls.Add(dataGridView1);
            Afiseaza_Ingrediente();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DeleteBoxes();
            this.Controls.Add(dataGridView1);
            Afiseaza_FeluriMancare();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(dataGridView1);
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(dateTimePicker1);
            this.Controls.Add(dateTimePicker2);
            this.Controls.Add(button5);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(dataGridView1);
        }
        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == String.Empty && textBox2.Text != String.Empty )
            {
                MessageBox.Show("Denumirea nu a fost adaugata");
            }
            else if (textBox1.Text != String.Empty && textBox2.Text == String.Empty )
            {
                MessageBox.Show("Cantitatea nu a fost adaugata");
            }
            else
            {
                
                var a = dateTimePicker1.Text;
                var b = dateTimePicker2.Text;
                int.TryParse(textBox2.Text, out int x);
                //_administrareIngredient.AddIngredient(new Ingredient(textBox1.Text,x, a,b));
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
