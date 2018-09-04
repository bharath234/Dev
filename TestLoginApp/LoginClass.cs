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
using SQLite;

namespace TestLoginApp
{
    public class LoginClass
    {
        [PrimaryKey,AutoIncrement,Column("_Id"),MaxLength(10)]
        public int Id { get; set; }

        [MaxLength(25)]
        public string Username { get; set; }

        [MaxLength(15)]
        public string Password { get; set; }


    }
}