using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataScience1.Methods
{
    class Cosine
    {
        static double distance = 0.0;
        public static double ComputeCosine(Dictionary<int, List<UserInfo>> dictonary)
        {
            double distance = 0.0;
            double upper = 0.0;
            double lower1 = 0.0;
            double lower2 = 0.0;
            var fstPick = SelectUser.selectUser(dictonary);
            var sndPick = SelectUser.selectUser(dictonary);
            //foreach (var user1 in fstPick)
            //{
            //    foreach (var user2 in sndPick)
            //    {
            //        if (!fstPick.Contains(user1) || !sndPick.Contains(user2)
            //        {
            //            dictonary.Add(user1, 0.0);
            //            dictonary.Add(user2.Rating, 0.0);
            //        }
            //    }
            //}
            foreach (var item1 in fstPick)
            {
                foreach (var item2 in sndPick.Where(x => x.Article == item1.Article))
                {
                    upper = item1.Rating * item2.Rating;
                    lower1 += Math.Pow(item1.Rating, 2);
                    lower2 += Math.Pow(item2.Rating, 2);
                }
                distance = upper / (Math.Sqrt(lower1)  * Math.Sqrt(lower2));
            }
            return distance;
        }
    }
}
