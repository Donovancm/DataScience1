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
        public static double ComputeEuclidean(Dictionary<int, List<UserInfo>> dictonary)
        {
            double distance = 0.0;
            var fstPick = SelectUser.selectUser(dictonary);
            var sndPick = SelectUser.selectUser(dictonary);
            //Console.WriteLine(distance);
            foreach (var user1 in fstPick)
            {
                foreach (var user2 in sndPick.Where(x => x.Article == user1.Article))
                {
                    distance += Math.Pow((user1.Rating - user2.Rating), 2);
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
