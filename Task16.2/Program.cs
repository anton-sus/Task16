using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;



namespace Task16._2
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = "../../../Products.json";

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                jsonString = sr.ReadToEnd();
                sr.Close();
                Console.WriteLine(jsonString);
               
            }
            Good[] itemOfGood = JsonSerializer.Deserialize<Good[]>(jsonString);

            Good maxPrice = itemOfGood[0];
            foreach (Good g in itemOfGood)
            {
                if (g.price>maxPrice.price)
                {
                    maxPrice = g;
                }
            }
            Console.WriteLine($" название самого дорогого товара: {maxPrice.code} {maxPrice.name} {maxPrice.price}");
            Console.ReadKey();
        }
    }

    public class Good
    {
        [JsonPropertyName("Код товара")]
        public int code { get; set; }
        [JsonPropertyName("Название товара")]
        public string name { get; set; }
        [JsonPropertyName("Цена товара")] 
        public double price { get; set; }
    }


}

