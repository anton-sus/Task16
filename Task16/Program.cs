using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Task16
{
    class Program
    {
        static void Main(string[] args)
        {
            const int amount = 3;
            Good[] itemOfGood = new Good[amount];
            for (int i = 0; i < amount; i++)
            {
                itemOfGood[i] = new Good();
                itemOfGood[i].GetInfo();
                Console.WriteLine(" товар-{0}: ok!\n", i + 1);
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString1 = JsonSerializer.Serialize(itemOfGood, options);
            Console.WriteLine(jsonString1);


            string path = "../../../Products.json";
            //if (!File.Exists(path))
            //{
            //    File.Create(path);
            //}
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(jsonString1);
                sw.Close();
                Console.WriteLine("\nфайл Products.json записан");
            }
            Console.ReadKey();
        }
    }
}
class Good
{
    [JsonPropertyName("Код товара")]
    public int code { get; set; }
    [JsonPropertyName("Название товара")]
    public string name { get; set; }
    [JsonPropertyName("Цена товара")]
    public double price { get; set; }

    public void GetInfo()
    {
        Console.WriteLine("код, название, цена:");
        code = Convert.ToInt32(Console.ReadLine());
        name = Convert.ToString(Console.ReadLine());
        price = Convert.ToDouble(Console.ReadLine());
    }

}
