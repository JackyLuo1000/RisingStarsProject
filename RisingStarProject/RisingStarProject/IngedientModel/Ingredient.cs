using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace RisingStarProject.IngedientModel
{
    [ProtoContract]
    public class Ingredient : INotifyPropertyChanged
    {
        [ProtoIgnore]
        private string name;
        [ProtoIgnore]
        private string type;
        [ProtoIgnore]
        private float qty;
        [ProtoIgnore]
        private string measurement;

        [ProtoMember(1)]
        public string Name {
            get { return name; }
            set
            {
                name = value;
                FieldChanged();
            }
        }//Ex: Brown Sugar, Chicken.
        [ProtoMember(2)]
        public string Type {
            get { return type; }
            set
            {
                type = value;
                FieldChanged();
            }
        }//Seasoning, Poultry.
        [ProtoMember(3)]
        public float QTY {
            get { return qty; }
            set
            {
                qty = value;
                FieldChanged();
            }
        }//2.
        [ProtoMember(4)]
        public string Measurement {
            get { return measurement; }
            set
            {
                measurement = value;
                FieldChanged();
            }
        }//Ex: Tablespoon (TBS), Pounds (LB).
        

        public Ingredient()
        {

        }

        public Ingredient(string name, string type, float qty, string measurement)
        {
            Name = name;
            Type = type;
            QTY = qty;
            Measurement = measurement;
        }

        public override string ToString()
        {
            return $"Ingredient Name: {Name}, Ingredient Type: {Type}, Quantity: {QTY} {Measurement}.";
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void FieldChanged([CallerMemberName]string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    /*
     * Example for how to use IngredientFileI/O with the Ingredient class:
        static void Main(string[] args)
        {
            //Recipe = Homestyle Pico De Gallo.

            Ingredient I1 = new Ingredient();
            I1.Name = "Diced Tomatoes";
            I1.Type = "Fruit";
            I1.QTY = 1;
            I1.Measurement = "Cup"; 

            Ingredient I2 = new Ingredient();
            I2.Name = "Sliced Jalapenos";
            I2.Type = "Fruit";
            I2.QTY = 0.5f;
            I2.Measurement = "Cup";

            Ingredient I3 = new Ingredient();
            I3.Name = "Roasted Diced Tomatillo";
            I3.Type = "Fruit";
            I3.QTY = 0.25f;
            I3.Measurement = "Cup";

            Ingredient I4 = new Ingredient();
            I4.Name = "Minced Coriander";
            I4.Type = "Vegetable";
            I4.QTY = 1f;
            I4.Measurement = "Tablespoon";

            Ingredient I5 = new Ingredient();
            I5.Name = "Minced Garlic";
            I5.Type = "Vegetable";
            I5.QTY = 0.5f;
            I5.Measurement = "Tablespoon";

            Ingredient I6 = new Ingredient();
            I6.Name = "A1 Sauce";
            I6.Type = "Seasoning (Sauce)";
            I6.QTY = 2f;
            I6.Measurement = "Tablespoons";

            Ingredient I7 = new Ingredient();
            I7.Name = "Salt";
            I7.Type = "Seasoning";
            I7.QTY = 2f;
            I7.Measurement = "Teaspoons";

            Ingredient I8 = new Ingredient();
            I8.Name = "Avocado Slices";
            I8.Type = "Fruit";
            I8.QTY = 150f;
            I8.Measurement = "Grams (Whole Avocado)";

            ListOfIngredients list = new ListOfIngredients();
            list.Ingredients.Add(I1);
            list.Ingredients.Add(I2);
            list.Ingredients.Add(I3);
            list.Ingredients.Add(I4);
            list.Ingredients.Add(I5);
            list.Ingredients.Add(I6);
            list.Ingredients.Add(I7);
            list.Ingredients.Add(I8);

            IngredientFileIO IO = new IngredientFileIO();
            IO.WriteTXT("Test.txt", list);
            IO.ReadTXT("Test.txt");

            Console.WriteLine("\nPress any key to close command prompt: ");
            Console.ReadKey();
        }
    */
}
