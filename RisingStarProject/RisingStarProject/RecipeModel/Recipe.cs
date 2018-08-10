using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisingStarProject.RecipeModel
{
  class Program
    {
        public class Recipe
        {
            public string Name { get; set; }
            public string Type { get; set; }

            public Recipe()
            {
            }

            public Recipe(string name, string type)
            {
                this.Name = name;
                this.Type = type;

            }

            List<Ingredient> ingredients { get; set; };

            public override string ToString()
            {
                return $"Recipe Name: {Name}, Recipe Type: {Type}.";
            }
        }
    }
}
