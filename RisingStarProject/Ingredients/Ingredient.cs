using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingredients
{
    class Ingredient
    {
        string Name = "";//Ex: Brown Sugar
        string Type = "";//Ex: Tablespoon (TBS)
        float QTY = 0;//2

        public Ingredient(string name, string type, float qty)
        {
            this.Name = name;
            this.Type = type;
            this.QTY = qty;
        }

        public override string ToString()
        {
            return $"Ingredient Name: {Name}, Measurement Type: {Type}, Quantity: {QTY}";
        }
    }
}
