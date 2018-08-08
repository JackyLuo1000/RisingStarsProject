using RisingStarProject.IngedientModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisingStarProject
{
    public class IngredientFileIO
    {
        public void ReadTXT()
        {
            try
            {
                var ingredientPath = Path.GetFileName("IngredientTester.txt");
                using (StreamReader sr = new StreamReader(ingredientPath))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error, file could not be read: " + e.Message);
            }
        }

        public void WriteTXT(List<Ingredient> list)
        {
            Ingredient ingredient = new Ingredient();

            try
            {
                var ingredientPath = Path.GetFileName("IngredientTester.txt");
                using (StreamWriter sw = new StreamWriter(ingredientPath))
                {
                    sw.Write(list.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error, file could not be written: " + e.Message);
            }
        }
    }
}
