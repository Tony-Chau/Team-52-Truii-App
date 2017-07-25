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
using DSoft.Datatypes.Grid.Data;
using Administration_App.DB;

namespace Administration_App.Data.Grid
{
    public class CustomFieldDataTable : DSDataTable
    {
        public CustomFieldDataTable()
        {

        }

        /// <summary>
        /// Initialises CustomFieldDataTable
        /// Pulls Data from the database and generates columns and rows to match the said data
        /// and inputs that dta afterwards 
        /// </summary>
        /// <param name="context">Allows it to know which activity it is calling it from</param>
        /// <param name="Name">Used to Determine which spreadsheet is to be openned</param>
        public CustomFieldDataTable(Context context, String Name) : base(Name)
        {
            CustomFieldTableDB customFieldTable = new CustomFieldTableDB(context);
            
            string customFieldID = "CustomFieldID";
            string fieldID = "FieldID";
            string graphID = "GraphID";
            string red = "Red";
            string green = "Green";
            string blue = "Blue";

            var dataColumns = new Dictionary<string, float>();
            dataColumns.Add("  " + customFieldID, 150);
            dataColumns.Add(fieldID, 100);
            dataColumns.Add(graphID, 100);
            dataColumns.Add(red, 100);
            dataColumns.Add(green, 100);
            dataColumns.Add(blue, 100);

            foreach (var key in dataColumns.Keys)
            {
                var dc = new DSDataColumn(key);
                dc.Caption = key;
                dc.ReadOnly = true;
                dc.DataType = typeof(string);
                dc.AllowSort = true;
                dc.Width = dataColumns[key];
                Columns.Add(dc);
            }

            List<string> CustomFieldIDList = customFieldTable.readString(customFieldID);
            List<string> FieldIDList = customFieldTable.readString(fieldID);
            List<string> GraphIDList = customFieldTable.readString(graphID);
            List<string> RedList = customFieldTable.readString(red);
            List<string> GreenList = customFieldTable.readString(green);
            List<string> BlueList = customFieldTable.readString(blue);
            int row = customFieldTable.Count();
            for (int i = 0; i < row; i += 1)
            {
                var dataRows = new DSDataRow();
                
                dataRows["  " + customFieldID] = "  " + CustomFieldIDList[i];
                dataRows[fieldID] = FieldIDList[i];
                dataRows[graphID] = GraphIDList[i];
                dataRows[red] = RedList[i];
                dataRows[green] = GreenList[i];
                dataRows[blue] = BlueList[i];

                Rows.Add(dataRows);
            }
        }
    }
}