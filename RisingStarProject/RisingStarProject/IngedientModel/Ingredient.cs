using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisingStarProject.IngedientModel
{
    public class Ingredient
    {
        public string Name { get; set; }//Ex: Brown Sugar, Chicken.
        public string Type { get; set; }//Seasoning, Poultry.
        public float QTY { get; set; }//2.
        public string Measurement { get; set; }//Ex: Tablespoon(TBS), Pounds (LB).

        public Ingredient()
        {
        }

        public Ingredient(string name, string type, float qty, string measurement)
        {
            this.Name = name;
            this.Type = type;
            this.QTY = qty;
            this.Measurement = measurement;
        }

        public override string ToString()
        {
            return $"Ingredient Name: {Name}, Ingredient Type: {Type}, Quantity: {QTY} {Measurement}.";
        }
    }

    /*
     * Example for Ingredient class and IngredientFileIO:
        static void Main(string[] args)
        {
            Ingredient I1 = new Ingredient();
            I1.Name = "Diced Tomatoes";
            I1.Type = "Vegetable";
            I1.QTY = 1;
            I1.Measurement = "Cup";

            Ingredient I2 = new Ingredient();
            I2.Name = "Cheese";
            I2.Type = "Dairy";
            I2.QTY = 0.5f;
            I2.Measurement = "Cup";

            List<Ingredient> list = new List<Ingredient>();
            list.Add(I1);
            list.Add(I2);

            IngredientFileIO IO = new IngredientFileIO();
            IO.WriteTXT("TestVotV2.txt", list);
            IO.ReadTXT("TestVotV2.txt");

            Console.WriteLine("\n" + I1.ToString() + " " + I2.ToString());

            Console.WriteLine("\nPress any key to close command prompt: ");
            Console.ReadKey();
        }
    */
}
