using Android.App;
using Android.Widget;
using Android.OS;
using System;
using SQLite;
using System.IO;

namespace TestLoginApp
{
    [Activity(Label = "TestApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText txtusername;
        EditText txtpassword;
        Button login;
        Button register;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            txtusername = FindViewById<EditText>(Resource.Id.txtUserName);
            txtpassword = FindViewById<EditText>(Resource.Id.txtPassword);
            login = FindViewById<Button>(Resource.Id.loginButton);
            register = FindViewById<Button>(Resource.Id.registerButton);
            login.Click += Login_Click;
            register.Click += Register_Click;
            DBCreate();

        }

        public string DBCreate()
        {
            var output = "";
            output += "Creating Databse if it doesnt exists";
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user1.db3"); //Create New Database  
            var db = new SQLiteConnection(dpPath);
            output += "\n Database Created....";
            return output;
        }

        private void Register_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
        }

        private void Login_Click(object sender, System.EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user1.db3"); //Call Database  
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<LoginClass>(); //Call Table  
                var data1 = data.Where(x => x.Username == txtusername.Text && x.Password == txtpassword.Text).FirstOrDefault(); //Linq Query  
                if (data1 != null)
                {
                    StartActivity(typeof(HomePageActivity));
                    Toast.MakeText(this, "Login Success", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "Username or Password invalid", ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}

