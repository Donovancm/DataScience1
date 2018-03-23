using System;
using System.Collections.Generic;
using System.Text;
using static DataScience1.Program;

namespace DataScience1
{
    class SelectUser
    {
        private static int selectedUser;
        public static List<UserInfo> selectUser(Dictionary<int, List<UserInfo>> dictonary)
        {
            int selectedUser = int.Parse(Console.ReadLine());
            var user = dictonary[selectedUser];
            return user;
        }
        public static int selectUserCosine(Dictionary<int, Dictionary<int, double>> dictionary2)
        {
            int selectedUser = int.Parse(Console.ReadLine());
            return selectedUser;
        }
    }
}
