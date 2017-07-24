using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

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
            btnUser.Click += BtnUser_Click;
            btnTable.Click += BtnTable_Click;
            btnGraph.Click += BtnGraph_Click;
            btnField.Click += BtnField_Click;
        }

        private void BtnField_Click(object sender, System.EventArgs e)
        {
            NextPage("Field");
        }

        private void BtnGraph_Click(object sender, System.EventArgs e)
        {
            NextPage("Graph");
        }

        private void BtnTable_Click(object sender, System.EventArgs e)
        {
            TableListDB Table = new TableListDB(this);
            Table.CreateTable();
            Table.InsertData("Green", "NickConstantine", new System.DateTime());
            NextPage("Table");
        }

        private void BtnUser_Click(object sender, System.EventArgs e)
        {
            NextPage("User");
        }
        private void NextPage(string DatabaseName)
        {
            Intent intent = new Intent(this, typeof(DatabaseActivity));
            intent.PutExtra("DatabaseName", DatabaseName);
            StartActivity(intent);
        }
    }
}

