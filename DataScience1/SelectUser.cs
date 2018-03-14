using System;
using System.Collections.Generic;
using System.Text;
using static DataScience1.Program;

namespace DataScience1
{
    class SelectUser
    {
        public static List<UserInfo> selectUser(Dictionary<int, List<UserInfo>> dictonary)
        {
            int selectedUser = int.Parse(Console.ReadLine());
            var user = dictonary[selectedUser];
            return user;
        }
    }
}
