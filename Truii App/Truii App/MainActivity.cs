using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using UK.CO.Chrisjenx.Calligraphy;
using Truii_App.Functions;
using Truii_App.DB.Local;

namespace Truii_App
{
    [Activity(Label = "Truii_App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            FontFunction font = new FontFunction();
            UserTableDB User = new UserTableDB(this);
            CheckIfDBExist();
            NextPage(User.Count() == 0);
        }

        /// <summary>
        /// Takes users to the next page depending on the check
        /// </summary>
        /// <param name="check"></param>
        private void NextPage(bool check)
        {
            if (check)
            {
                StartActivity(new Intent(this, typeof(LoginActivity)));
                Finish();
            }else
            {
                //go to the home page
            }
        }

        /// <summary>
        /// Checks if the database exist, if not then it will generate one
        /// </summary>
        private void CheckIfDBExist()
        {
            DatabaseFunction database = new DatabaseFunction(this);
            if (!database.CheckIfDatabaseExist())
            {
                database.CreateDatabase();
            }
        }

        protected override void AttachBaseContext(Context @base)
        {
            base.AttachBaseContext(CalligraphyContextWrapper.Wrap(@base));
        }

    }
}

