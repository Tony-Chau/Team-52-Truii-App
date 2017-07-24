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
using DSoft.UI.Grid;
using Administration_App.Data.Grid;

namespace Administration_App
{
    [Activity(Label = "DatabaseActivity")]
    public class DatabaseActivity : Activity
    {
        DSGridView dsGrid;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DatabaseView);
            // Create your application here
            dsGrid = FindViewById<DSGridView>(Resource.Id.dataGrid);
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
            //dsGrid.SetMinimumHeight(Resources.DisplayMetrics.HeightPixels / 2);
        }
        private void OperateUser()
        {
            if (dsGrid != null)
            {
                dsGrid.DataSource = new DataSet(this);
                dsGrid.TableName = "User";
            }
        }

        private void OperateGraph()
        {
            if (dsGrid != null)
            {
                dsGrid.DataSource = new DataSet(this);
                dsGrid.TableName = "Graph";
            }
        }
        
        private void OperateTable()
        {
            if (dsGrid != null)
            {
                TableListDB Table = new TableListDB(this);
                Table.InsertData("Green", "NickConstantine", new DateTime());
                dsGrid.DataSource = new DataSet(this);
                dsGrid.TableName = "Table";
            }
        }

        private void OperateField()
        {
            if (dsGrid != null)
            {
                dsGrid.DataSource = new DataSet(this);
                dsGrid.TableName = "Field";
            }
        }

        private void OperateVarious(string TableName)
        {

        }
    }
}