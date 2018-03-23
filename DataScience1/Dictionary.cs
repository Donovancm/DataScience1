using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataScience1
{
    class Dictionary
    {
        readonly static string path = "C:/Users/Donovan/Desktop/DataScience1/userItem.data";
        public static Dictionary<int, Dictionary<int, double>> CosineData()
        {
            Dictionary<int, Dictionary<int, double>> dictionary = new Dictionary<int, Dictionary<int, double>>();
            var reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');

                int userId = int.Parse(values[0]);
                int article = int.Parse(values[1]);
                double rating = double.Parse(values[2]);
                if (!dictionary.ContainsKey(userId))
                {
                    dictionary.Add(userId, new Dictionary<int, double>());
                }
                dictionary[userId].Add(article, rating);

            }
            foreach (var dictpair in dictionary)
            {
                Console.WriteLine(dictpair.Key);
                foreach (var item in dictpair.Value)
                {
                    Console.WriteLine(" Article: {0} Rating: {1} ", item.Key, item.Value);
                }
                Console.ReadLine();
            }
            return dictionary;
        }
    }
}
