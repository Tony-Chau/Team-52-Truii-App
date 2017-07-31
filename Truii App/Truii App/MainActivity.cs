using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using UK.CO.Chrisjenx.Calligraphy;
using Truii_App.Functions;

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
            NextPage();
        }

        /// <summary>
        /// Takes User to the Login Page
        /// </summary>
        private void NextPage()
        {
            StartActivity(new Intent(this, typeof(LoginActivity)));
            Finish();
        }

        protected override void AttachBaseContext(Context @base)
        {
            base.AttachBaseContext(CalligraphyContextWrapper.Wrap(@base));
        }

    }
}

