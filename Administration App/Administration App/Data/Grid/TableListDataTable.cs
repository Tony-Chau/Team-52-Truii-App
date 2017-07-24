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
            TableListDB tableListdb = new TableListDB(context);
            string tableName = "TableName";
            string userName = "UserName";
            string dateCreated = "DateCreated";

            var dataColumns = new Dictionary<string, float>();
            dataColumns.Add("  " + tableName, 100);
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

            
            for (int Loop = 0; Loop < tableListdb.Count(); Loop++)
            {
                var dataRows = new DSDataRow();
                dataRows["  " + tableName] = "  " + tableListdb.readString(tableName, Loop);
                dataRows[userName] = tableListdb.readString(userName, Loop);
                dataRows[dateCreated] = tableListdb.readDateTime(dateCreated, Loop);
                Rows.Add(dataRows);
            }
        }
    }
}