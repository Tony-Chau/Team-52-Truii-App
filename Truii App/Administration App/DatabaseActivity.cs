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
using Administration_App.DB;

namespace Administration_App
{
    [Activity(Label = "Database", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class DatabaseActivity : Activity
    {
        DSGridView dsGrid;
        string databaseName;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DatabaseView);
            // Create your application here
            dsGrid = FindViewById<DSGridView>(Resource.Id.dataGrid);
            databaseName = Intent.GetStringExtra("DatabaseName");
            SetTitle(); //sets the title of the page
            if (databaseName == "User"){
                OperateUser();
            }
            else if (databaseName == "Table")
            {
                OperateTable();
            }
            else if(databaseName == "Graph"){
                OperateGraph();
            }
            else if(databaseName == "Field"){
                OperateField();
            }
            else if (databaseName == "CustomField"){
                OperateCustomField();
            }
            
        }

        /// <summary>
        ///  Creates a spreadsheet to show the UserTable
        /// </summary>
        private void OperateUser()
        {
            if (dsGrid != null)
            {
                dsGrid.DataSource = new DataSet(this, databaseName);
                dsGrid.TableName = "User";
            }
        }

        /// <summary>
        ///  Creates a spreadsheet to show the TableList
        /// </summary>
        private void OperateTable()
        {
            if (dsGrid != null)
            {
                dsGrid.DataSource = new DataSet(this, databaseName);
                dsGrid.TableName = "Table";
            }
        }

        /// <summary>
        /// Creates a spreadsheet to show the GraphTable 
        /// </summary>
        private void OperateGraph()
        {
            if (dsGrid != null)
            {
                dsGrid.DataSource = new DataSet(this, databaseName);
                dsGrid.TableName = "Graph";
            }
        }

        /// <summary>
        ///  Creates a spreadsheet to show the FieldTable
        /// </summary>
        private void OperateField()
        {
            if (dsGrid != null)
            {
                dsGrid.DataSource = new DataSet(this, databaseName);
                dsGrid.TableName = "Field";
            }
        }

        /// <summary>
        /// Creates a spreadsheet to show the CustomFieldTable 
        /// </summary>
        private void OperateCustomField()
        {
            if (dsGrid != null)
            {
                dsGrid.DataSource = new DataSet(this, databaseName);
                dsGrid.TableName = "CustomField";
            }
        }

        /// <summary>
        /// Sets the title of the page
        /// </summary>
        private void SetTitle()
        {
            if (databaseName == "Table")
            {
                this.Title = databaseName + "List";
            }
            else
            {
                this.Title = databaseName + "Table";
            }
        }
    }
}