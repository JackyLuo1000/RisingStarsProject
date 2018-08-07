using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingredients
{
    class Ingredient
    {
        string Name = "";//Ex: Brown Sugar, Chicken
        string Type = "";//Seasoning, Poultry
        float QTY = 0;//2
        string Measurment = "";//Ex: Tablespoon(TBS), Pounds (LB)

        public Ingredient(string name, string type, float qty, string measurement)
        {
            this.Name = name;
            this.Type = type;
            this.QTY = qty;
            this.Measurment = measurement;
        }

        public override string ToString()
        {
            return $"Ingredient Name: {Name}, Ingredient Type: {Type}, Quantity: {QTY}{Measurment}.";
        }
    }
}
