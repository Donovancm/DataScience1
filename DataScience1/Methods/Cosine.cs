using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataScience1.Methods
{
    class Cosine
    {
        public static double ComputeCosine(Dictionary<int, double> User, Dictionary<int, double> User2)
        {
            double distance = 0.0;
            double upper = 0.0;
            double lower1 = 0.0;
            double lower2 = 0.0;
            //var fstPick = SelectUser.selectUserCosine(User);
            //var sndPick = SelectUser.selectUserCosine(User2);

            foreach (var item in User)
            {
                if (!User2.ContainsKey(item.Key))
                {
                    User2.Add(item.Key, 0.0);
                }
            }
            foreach (var item in User2)
            {
                if (!User.ContainsKey(item.Key))
                {
                    User.Add(item.Key, 0.0);
                }
            }


            foreach (var item1 in User)
            {
                foreach (var item2 in User2.Where(x => x.Key == item1.Key))
                {
                    upper += item1.Value * item2.Value;
                    lower1 += Math.Pow(item1.Value, 2);
                    lower2 += Math.Pow(item2.Value, 2);
                }
                distance = upper / (Math.Sqrt(lower1)  * Math.Sqrt(lower2));
            }
            return distance;
        }
    }
}
