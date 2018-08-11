﻿using RisingStarProject.IngedientModel;
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

            private StringBuilder sb = new StringBuilder();
            public string Name { get; set; }
            //public string Type { get; set; }
            public List<Ingredient> Ingredients { get; set; }

            public Recipe()
            {
                Name = "Recipe";
                Ingredients = new List<Ingredient>();
            }

            public Recipe(string name, string type)
            {
                this.Name = name;
                //this.Type = type;

            }


            public override string ToString()
            {
                if (!Name.Equals(""))
                {
                    sb.AppendLine($"Recipe Name: {Name}");
                }
                //if (!Type.Equals(""))
                //{
                //    sb.AppendLine($"Recipe Type: {Name}");
                //}
                if(Ingredients.Count() != 0)
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
