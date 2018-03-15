using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataScience1.Methods
{
    class Pearson : InterfaceMethods
    {
        static double similarity;
        public static double ComputePearson(Dictionary<int, List<UserInfo>> dictonary)
        {
            double distance = 0.0;
            var fstPick = SelectUser.selectUser(dictonary);
            var sndPick = SelectUser.selectUser(dictonary);

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


            foreach (var item1 in fstPick)
            {
                foreach (var item2 in sndPick.Where(x => x.Article == item1.Article))
                {
                    leftUpper += (item1.Rating * item2.Rating);
                    //rightUpper += (item1.Rating * item2.Rating);
                    rightUpper1 += item1.Rating;
                    rightUpper2 += item2.Rating;
                    leftdown1 += Math.Pow(item1.Rating, 2);
                    //leftdown2 += (Math.Pow(item1.Rating, 2));
                    leftdown2 += item1.Rating;
                    rightdown1 += (Math.Pow(item2.Rating, 2));
                    //rightdown2 += (Math.Pow(item2.Rating, 2));
                    rightdown2 += item2.Rating;
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
