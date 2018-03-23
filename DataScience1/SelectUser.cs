using System;
using System.Collections.Generic;
using System.Text;
using static DataScience1.Program;

namespace DataScience1
{
    class SelectUser
    {
        public static int selectedUser;
        //public static List<UserInfo> selectUser(Dictionary<int, List<UserInfo>> dictonary)
        //{
        //    int selectedUser = int.Parse(Console.ReadLine());
        //    var user = dictonary[selectedUser];
        //    return user;
        //}
        public static Dictionary<int, double> selectUserCosine(Dictionary<int, Dictionary<int, double>> dictionary)
        {
            selectedUser = int.Parse(Console.ReadLine());
            var user = dictionary[selectedUser];
            return user;
        }
    }
}
