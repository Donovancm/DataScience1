using DataScience1.Methods;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataScience1
{
    class Program
    {
        public static int choice;
        readonly static string path = "C:/Users/Donovan/Desktop/DataScience1/userItem.data";
        public static Dictionary<int, List<UserInfo>> dictonary = new Dictionary<int, List<UserInfo>>();
        static void Main(string[] args)
        {
            ReadFile();
            PickAlgorithm();
            Console.ReadLine();
        }
        public static void ReadFile()
        {
            var reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');

                int userId = int.Parse(values[0]);
                int article = int.Parse(values[1]);
                double rating = double.Parse(values[2]);
                PutInDictonary(userId, article, rating);
            }
            foreach (KeyValuePair<int, List<UserInfo>> pair in dictonary)
            {
                Console.WriteLine(pair.Key);
                foreach (var item in pair.Value)
                {
                    Console.WriteLine("Article :{1} , Rating of: {2} ", item.UserId, item.Article, item.Rating);
                    Console.WriteLine();
                }
            }
        }
        public static void PutInDictonary(int userId, int article, double rating)
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
        public static void PickAlgorithm()
        {
            Console.WriteLine("Pick 1 for Euclidean");
            Console.WriteLine("Pick 2 for Pearson");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("You have chosen Euclidian");
                    Console.WriteLine("The similarity is: " + Euclidean.ComputeEuclidean(dictonary));
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("You have chosen Pearson");
                    Console.WriteLine("The similarity is: " + Pearson.ComputePearson(dictonary));
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Closed");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
