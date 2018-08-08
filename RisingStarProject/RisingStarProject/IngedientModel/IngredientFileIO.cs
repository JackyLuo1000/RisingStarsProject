using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisingStarProject
{
    class IngredientFileIO
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
            try
            {
                StreamWriter sw = new StreamWriter("IngredientTester.txt");
                sw.WriteLine("----Ingredients go here----");

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
