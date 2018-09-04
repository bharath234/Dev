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
    [Activity(Label = "HomePage")]
    public class HomePageActivity : Activity
    {
     
        ListView lstView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomePage);
            lstView = FindViewById<ListView>(Resource.Id.listView);
            lstView.Adapter = new MyCustomListAdapter(UserData.Users);
            FindViewById<Button>(Resource.Id.addBtn).Click += AddUser_Click;
        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AddUserActivity));
        }
    }
}