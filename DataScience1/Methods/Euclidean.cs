using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static DataScience1.Program;

namespace DataScience1.Methods
{
    class Euclidean : InterfaceMethods
    {
        static double similarity;
        public static double ComputeEuclidean(Dictionary<int, double> User, Dictionary<int, double> User2)
        {
            double distance = 0.0;
            //Console.WriteLine(distance);
            foreach (var user1 in User)
            {
                foreach (var user2 in User2.Where(x => x.Key == user1.Key))
                {
                    distance += Math.Pow((user1.Value- user2.Value), 2);
                }
                similarity = 1 / (1 + Math.Sqrt(distance));
                //return similarity;
            }
            return similarity;
        }

        public double ComputeSimilarity(Dictionary<int, List<UserInfo>> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
