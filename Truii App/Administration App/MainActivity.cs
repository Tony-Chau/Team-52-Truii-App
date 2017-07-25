using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Administration_App.DB;
using System;

namespace Administration_App
{
    [Activity(Label = "Administration_App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        UserTableDB userTabledb;
        TableListDB tableListdb;
        GraphTableDB graphTabledb;
        FieldTableDB fieldTable;
        CustomFieldTableDB customFieldTable;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            Button btnUser = FindViewById<Button>(Resource.Id.btnUser);
            Button btnTable = FindViewById<Button>(Resource.Id.btnTable);
            Button btnGraph = FindViewById<Button>(Resource.Id.btnGraph);
            Button btnField = FindViewById<Button>(Resource.Id.btnField);
            Button btnCustomField = FindViewById<Button>(Resource.Id.btnCustomField);
            Button btnReset = FindViewById<Button>(Resource.Id.btnReset);
            Button btnAdd = FindViewById<Button>(Resource.Id.btnAdd);

            btnUser.Click += BtnUser_Click;
            btnTable.Click += BtnTable_Click;
            btnGraph.Click += BtnGraph_Click;
            btnField.Click += BtnField_Click;
            btnCustomField.Click += BtnCustomField_Click;
            btnReset.Click += BtnReset_Click;
            btnAdd.Click += BtnAdd_Click;

            userTabledb = new UserTableDB(this);
            tableListdb = new TableListDB(this);
            graphTabledb = new GraphTableDB(this);
            fieldTable = new FieldTableDB(this);
            customFieldTable = new CustomFieldTableDB(this);

            userTabledb.CreateTable();
            tableListdb.CreateTable();
            graphTabledb.CreateTable();
            fieldTable.CreateTable();
            customFieldTable.CreateTable();
        }

        private void BtnUser_Click(object sender, System.EventArgs e)
        {
            NextPage("User");
        }

        private void BtnTable_Click(object sender, System.EventArgs e)
        {
            NextPage("Table");
        }

        private void BtnGraph_Click(object sender, System.EventArgs e)
        {
            NextPage("Graph");
        }

        private void BtnField_Click(object sender, System.EventArgs e)
        {
            NextPage("Field");
        }

        private void BtnCustomField_Click(object sender, System.EventArgs e)
        {
            NextPage("CustomField");
        }

        private void BtnReset_Click(object sender, System.EventArgs e)
        {
            userTabledb.CreateTable();
            tableListdb.CreateTable();
            graphTabledb.CreateTable();
            fieldTable.CreateTable();
            customFieldTable.CreateTable();
            Toast.MakeText(this, "All Databases has been reset", ToastLength.Long).Show();
        }
        
        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            userTabledb.InsertData("NickConstantine", "Green");
            tableListdb.InsertData("Green", "NickConstantine", DateTime.Now);
            graphTabledb.InsertData(1, "NickConstantine", DateTime.Now);
            fieldTable.InsertData("GreenField", 1, "type");
            customFieldTable.InsertData(1, 1, 0, 255, 0);
            Toast.MakeText(this, "Data has beed added to All Databases", ToastLength.Long).Show();
        }

        private void NextPage(string DatabaseName)
        {
            Intent intent = new Intent(this, typeof(DatabaseActivity));
            intent.PutExtra("DatabaseName", DatabaseName);
            StartActivity(intent);
        }
    }
}

