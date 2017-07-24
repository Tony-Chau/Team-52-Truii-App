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

namespace Administration_App.Data.Grid
{
    public class TableListDataTable : DSDataTable
    {
        public TableListDataTable()
        {

        }
        
        public TableListDataTable(Context context, String Name) : base(Name)
        {
            

            var dataColumns = new Dictionary<string, float>();
            dataColumns.Add("  TableID", 100);
            dataColumns.Add("TableName", 100);
            dataColumns.Add("UserID", 100);
            dataColumns.Add("DateCreated", 150);
            dataColumns.Add("CreatedFrom", 150);

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

            int ID;
            for (int Loop = 0; Loop < 3; Loop++)
            {
                var dataRows = new DSDataRow();

                ID = Loop + 1;

                dataRows["  TableID"] = "  Table" + ID;
                dataRows["TableName"] = "TableName" + ID;
                dataRows["UserID"] = "User" + ID;
                dataRows["DateCreated"] = "2017/07/" + ID;
                dataRows["CreatedFrom"] = "Person" + ID;
                Rows.Add(dataRows);
            }
        }
    }
}