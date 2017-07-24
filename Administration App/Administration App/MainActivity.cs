using Android.App;
using Android.Widget;
using Android.OS;

namespace Administration_App
{
    [Activity(Label = "Administration_App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnUser;
        Button btnTable;
        Button btnGraph;
        Button btnField;
        Button btnVarious;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            btnUser = FindViewById<Button>(Resource.Id.btnUser);
            btnTable = FindViewById<Button>(Resource.Id.btnTable);
            btnGraph = FindViewById<Button>(Resource.Id.btnGraph);
            btnField = FindViewById<Button>(Resource.Id.btnField);
            btnVarious = FindViewById<Button>(Resource.Id.btnVarious);
        }
        
    }
}

