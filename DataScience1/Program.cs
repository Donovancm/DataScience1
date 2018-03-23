using DataScience1.Methods;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataScience1
{
    class Program
    {
        public static int choice;
        public static Dictionary<int, Dictionary<int, double>> dictionary;
        static void Main(string[] args)
        {
            //ReadFile();
            dictionary = Dictionary.CosineData();
            PickAlgorithm();
            Console.ReadLine();
        }
        public static void PickAlgorithm()
        {
            Console.WriteLine("Pick 1 for Euclidean");
            Console.WriteLine("Pick 2 for Pearson");
            Console.WriteLine("Pick 3 for Cosine");
            choice = int.Parse(Console.ReadLine());
            var user1 = SelectUser.selectUserCosine(dictionary);
            var user2 = SelectUser.selectUserCosine(dictionary);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("You have chosen Euclidian");
                    Console.WriteLine("The similarity is: " + Euclidean.ComputeEuclidean(user1,user2));
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("You have chosen Pearson");
                    Console.WriteLine("The similarity is: " + Pearson.ComputePearson(user1, user2));
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("You have chosen Cosine");
                    Console.WriteLine("The similarity is: " + Cosine.ComputeCosine(user1, user2));
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
