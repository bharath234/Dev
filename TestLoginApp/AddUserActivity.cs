using System;
using System.Collections.Generic;
using System.IO;
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
    [Activity(Label = "AddUser")]
    public class AddUserActivity : Activity
    {
        EditText txtFirstName;
        Button add;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddUserLayout);
            txtFirstName = FindViewById<EditText>(Resource.Id.regUserName);
            add = FindViewById<Button>(Resource.Id.addButton);
            add.Click += Add_Click;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                UserDetails userAdd = new UserDetails();
                userAdd.Name = txtFirstName.Text;
                if (!string.IsNullOrEmpty(userAdd.Name))
                {
                    UserData.Users.Add(userAdd);
                    StartActivity(typeof(HomePageActivity));
                    Toast.MakeText(this, "Record Added Successfully", ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}