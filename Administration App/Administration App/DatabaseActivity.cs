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

namespace Administration_App
{
    [Activity(Label = "DatabaseActivity")]
    public class DatabaseActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DatabaseView);
            // Create your application here
            string databaseName = Intent.GetStringExtra("DatabaseName");
            if (databaseName == "User"){
                OperateUser();
            }
            else if(databaseName == "Graph"){
                OperateGraph();
            }
            else if(databaseName == "Field"){
                OperateField();
            }
            else if(databaseName == "Table"){
                OperateTable();
            }
            else{
                OperateVarious(databaseName);
            }
        }
        private void OperateUser()
        {

        }

        private void OperateGraph()
        {

        }
        
        private void OperateTable()
        {

        }

        private void OperateField()
        {

        }

        private void OperateVarious(string TableName)
        {

        }
    }
}