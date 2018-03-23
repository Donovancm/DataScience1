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
        public static Dictionary<int, Dictionary<int, double>> dictionary2;
        static void Main(string[] args)
        {
            //ReadFile();
            dictionary2 = Dictionary.CosineData();
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
                PutInDictonary(userId, article, rating);
                if (!dictionary2.ContainsKey(userId))
                {
                    dictionary2.Add(userId, new Dictionary<int, double>());
                }
                dictionary2[userId].Add(article, rating);
            }
            return dictionary2;
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
            Console.WriteLine("Pick 3 for Cosine");
            choice = int.Parse(Console.ReadLine());
            int selectedUser = int.Parse(Console.ReadLine());
            int user = SelectUser.selectUserCosine(dictionary2);
            int user2 = SelectUser.selectUserCosine(dictionary2);

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
                case 3:
                    Console.WriteLine("You have chosen Cosine");
                    Cosine.ComputeCosine(user , user2, dictionary2);
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
