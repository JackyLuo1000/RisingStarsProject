//using RisingStarProject.IngedientModel;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Serialization;

//namespace RisingStarProject
//{
//    public class IngredientFileIO
//    {
//        public void ReadTXT(string path)
//        {
//            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListOfIngredients));
//            try
//            {
//                using (StreamReader sr = new StreamReader(path))
//                {
//                    ListOfIngredients line = (ListOfIngredients)xmlSerializer.Deserialize(sr);
//                    foreach (Ingredient i in line.Ingredients)
//                    {
//                        Console.WriteLine(i.ToString());
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("Error, file could not be read: " + e.Message);
//            }
//        }

//        public void WriteTXT(string path, ListOfIngredients list)
//        {
//            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListOfIngredients));
//            try
//            {
//                using (StreamWriter sw = (File.CreateText(path)))
//                {
//                    xmlSerializer.Serialize(sw, list);
//                    sw.Flush();
//                    sw.Close();
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("Error, file could not be written: " + e.Message);
//            }
//        }
//    }
//}
