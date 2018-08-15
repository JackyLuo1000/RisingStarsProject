using RisingStarProject.IngedientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisingStarProject.RecipeModel
{
  class Program
    {
        [Serializable]
        public class Recipe
        {

            public string Name { get; set; }
            public string Type { get; set; }
            public List<Ingredient> Ingredients { get; set; }

            public Recipe()
            {
                Name = "Recipe";
                Type = "Type";
                Ingredients = new List<Ingredient>();
            }

            public Recipe(string name, string type)
            {
                Name = name;
                Type = type;
            }
            

            public override string ToString()
            {


                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(Name))
                {
                    sb.AppendLine($"Recipe Name: {Name}");
                }
                if (!string.IsNullOrEmpty(Type))
                {
                    sb.AppendLine($"Recipe Type: {Name}");
                }
                if (Ingredients != null && Ingredients.Count() != 0)
                {
                    foreach(Ingredient i in Ingredients)
                    {
                        sb.AppendLine( i.ToString() );
                    }
                }
                return sb.ToString();
            }
        }
    }
}
