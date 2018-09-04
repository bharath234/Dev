using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using SQLite;

namespace TestLoginApp
{
    [Activity(Label = "RegisterPage")]
    public class RegisterActivity : Activity
    {

        EditText txtusername;
        EditText txtpassword;
        Button btnRegister;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegisterUser);
            // Create your application here
            txtusername = FindViewById<EditText>(Resource.Id.regUserName);
            txtpassword = FindViewById<EditText>(Resource.Id.regPassword);
            btnRegister = FindViewById<Button>(Resource.Id.registerButton);


            btnRegister.Click += BtnRegister_Click;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtusername.Text.Length < 5 && txtpassword.Text.Length < 5)
                    Toast.MakeText(this, "Please check the username and password", ToastLength.Short).Show();
                else
                {
                    string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user1.db3"); //Call Database  
                    var db = new SQLiteConnection(dpPath);
                    db.CreateTable<LoginClass>();
                    LoginClass login = new LoginClass();
                    login.Username = txtusername.Text;
                    login.Password = txtpassword.Text;
                    db.Insert(login);
                    StartActivity(typeof(MainActivity));
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