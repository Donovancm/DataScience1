using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataScience1.Methods
{
    class Pearson : InterfaceMethods
    {
        static double similarity;
        public static double ComputePearson(Dictionary<int, double> User, Dictionary<int, double> User2)
        {
            double distance = 0.0;
            //var fstPick = SelectUser.selectUser(dictonary);
            //var sndPick = SelectUser.selectUser(dictonary);

            double leftUpper = 0.0;
            double rightUpper = 0.0;
            double rightUpper1 = 0.0;
            double rightUpper2 = 0.0;
            double leftdown1 = 0.0;
            double leftdown2 = 0.0;
            double leftdown22 = 0.0;
            double rightdown1 = 0.0;
            double rightdown2 = 0.0;
            double rightdown22 = 0.0;
            int totalArticles = 0;
            double upper = 0.0;
            double down = 0.0;


            foreach (var item1 in User)
            {
                foreach (var item2 in User.Where(x => x.Key == item1.Key))
                {
                    leftUpper += (item1.Value * item2.Value);
                    //rightUpper += (item1.Rating * item2.Rating);
                    rightUpper1 += item1.Value;
                    rightUpper2 += item2.Value;
                    leftdown1 += Math.Pow(item1.Value, 2);
                    //leftdown2 += (Math.Pow(item1.Rating, 2));
                    leftdown2 += item1.Value;
                    rightdown1 += (Math.Pow(item2.Value, 2));
                    //rightdown2 += (Math.Pow(item2.Rating, 2));
                    rightdown2 += item2.Value;
                    totalArticles++;
                }
            }

            leftdown22 = Math.Pow(leftdown2, 2);
            rightdown22 = Math.Pow(rightdown2, 2);
            rightUpper = rightUpper1 * rightUpper2;
            upper = leftUpper - (rightUpper / totalArticles);
            down = Math.Sqrt(leftdown1 - (leftdown22 / totalArticles)) * Math.Sqrt(rightdown1 - (rightdown22) / totalArticles); Console.WriteLine(down);
            distance = upper / down;

            return distance;
        }

        public double ComputeSimilarity(Dictionary<int, List<UserInfo>> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
