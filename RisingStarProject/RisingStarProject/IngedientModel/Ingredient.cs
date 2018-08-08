using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisingStarProject
{
    class Ingredient
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
            return $"Ingredient Name: {Name}, Ingredient Type: {Type}, Quantity: {QTY}{Measurement}.";
        }
    }
}
