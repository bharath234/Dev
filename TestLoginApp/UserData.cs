using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TestLoginApp
{
    public static class UserData
    {
        public static List<UserDetails> Users { get; private set; }
        static UserData()
        {
            var temp = new List<UserDetails>();

            AddUser(temp);
            AddUser(temp);
            AddUser(temp);

            Users = temp.OrderBy(i => i.Name).ToList();
        }

        static void AddUser(List<UserDetails> users)
        {
            users.Add(new UserDetails()
            {
                Name = "TestUser"
            });

        }
    }
}