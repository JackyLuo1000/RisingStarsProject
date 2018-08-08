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
        static void ReadTXT()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("IngredientTester.txt");

                line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }

                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("");
            }
        }

        static void WriteTXT()
        {
            Ingredient ingredient = new Ingredient();

            try
            {
                StreamWriter sw = new StreamWriter("IngredientTester.txt");
                sw.WriteLine(ingredient.ToString());

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("");
            }
        }
    }
}
