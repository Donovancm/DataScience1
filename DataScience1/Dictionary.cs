using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataScience1
{
    class Dictionary
    {
        readonly static string path = "C:/Users/Donovan/Desktop/DataScience1/userItem.data";
        static Dictionary<int, Dictionary<int, double>> dictionary2 = new Dictionary<int, Dictionary<int, double>>();
        public static Dictionary<int, Dictionary<int, double>> CosineData()
        {
            Dictionary<int, Dictionary<int, double>> dictionary2 = new Dictionary<int, Dictionary<int, double>>();
            var reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');

                int userId = int.Parse(values[0]);
                int article = int.Parse(values[1]);
                double rating = double.Parse(values[2]);
                PutInDictonary2(userId, article, rating);
                if (!dictionary2.ContainsKey(userId))
                {
                    dictionary2.Add(userId, new Dictionary<int, double>());
                }
                dictionary2[userId].Add(article, rating);
            }
            return dictionary2;
        }
        public static Dictionary<int, Dictionary<int, double>> PutInDictonary2(int userId, int article, double rating)
        {
            if (dictionary2.ContainsKey(userId))
            {
                dictionary2[userId].Add(article, rating);
            }
            else
            {
                dictionary2.Add(userId, new Dictionary<int, double>());
                dictionary2[userId].Add(article, rating);
            }
            return dictionary2;
        }

    }
}
