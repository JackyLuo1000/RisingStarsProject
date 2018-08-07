using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingredients
{
    class IngredientFileIO
    {
        static void ReadTXT()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\RisingStarsProject\\RisingStarProject\\Ingredients\\TXTs\\IngredientTest.txt");

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
                StreamWriter sw = new StreamWriter("C:\\RisingStarsProject\\RisingStarProject\\Ingredients\\TXTs\\IngredientTest.txt");
                sw.WriteLine("");

                sw.Close();
            }
            catch(Exception e)
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
