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
        public void ReadTXT(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
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

        public void WriteTXT(string path, List<Ingredient> list)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    System.Collections.IList list1 = list;
                    for (int i = 0; i < list1.Count; i++)
                    {
                        string obj = (string)list1[i].ToString();
                        sw.WriteLine(obj);
                    }

                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error, file could not be written: " + e.Message);
            }
        }
    }
}
