using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static DataScience1.UserInfocs;

namespace DataScience1
{
    class FiletoDictonary
    {
        static Dictionary<int, List<UserInfo>> dictonary = new Dictionary<int, List<UserInfo>>();
        public static void ReadFile()
        {
            string filePath = "C:/Users/Donovan/Desktop/DataScience1/userItem.data";
            var reader = new StreamReader(filePath);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');

                int userId = int.Parse(values[0]);
                int article = int.Parse(values[1]);
                double rating = double.Parse(values[2]);
                FileToDict(userId, article, rating);
            }
            foreach (KeyValuePair<int, List<UserInfo>> pair in dictonary)
            {
                Console.WriteLine("User" + pair.Key);
                foreach (var item in pair.Value)
                {
                    Console.WriteLine("Article :{1} , Rating of: {2} ", item.UserId, item.Article, item.Rating);
                    Console.WriteLine();
                }
            }
        }
        public static void FileToDict(int userId, int article, double rating)
        {
            if (dictonary.ContainsKey(userId))
            {
                dictonary[userId].Add(new UserInfo
                {
                    UserId = userId,
                    Article = article,
                    Rating = rating
                });
            }
            else
            {
                dictonary.Add(userId, new List<UserInfo>());
                dictonary[userId].Add(new UserInfo { UserId = userId, Article = article, Rating = rating });
            }
        }
    }
}
