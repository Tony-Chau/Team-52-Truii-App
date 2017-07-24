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
    public class GraphDataTable : DSDataTable
    {
        public GraphDataTable()
        {

        }
        
        public GraphDataTable(Context context, String Name) : base(Name)
        {
            //GraphTableDB graphTabledb = new GraphTableDB(context);
            //graphTabledb.CreateTable();
            //graphTabledb.InsertData();

            string graphID = "GraphID";
            string tableID = "TableID";
            string userName = "UserName";
            string dateCreated = "DateCreated";

            var dataColumns = new Dictionary<string, float>();
            dataColumns.Add("  " + graphID, 100);
            dataColumns.Add(tableID, 100);
            dataColumns.Add(userName, 100);
            dataColumns.Add(dateCreated, 150);

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

            int row = 3;
            for (int i = 0; i < row; i += 1)
            {
                var dataRows = new DSDataRow();
                
                dataRows["  " + graphID] = "  Graph" + i+1;
                dataRows[tableID] = "Table" + i+1;
                dataRows[userName] = "User" + i+1;
                dataRows[dateCreated] = "2017/07/" + i+1;

                Rows.Add(dataRows);
            }
        }
    }
}