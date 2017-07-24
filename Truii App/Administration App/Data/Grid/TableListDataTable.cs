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
            tableListdb.CreateTable();
            tableListdb.InsertData("Green", "NickConstantine", new DateTime());
            string tableID = "TableID";
            string tableName = "TableName";
            string userName = "UserName";
            string dateCreated = "DateCreated";

            var dataColumns = new Dictionary<string, float>();
            dataColumns.Add("  " + tableID, 100);
            dataColumns.Add(tableName, 100);
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

            List<string> PrimaryKeyList = tableListdb.readString(tableID);
            List<string> TableNameList = tableListdb.readString(tableName);
            List<string> UserNameList = tableListdb.readString(userName);
            int row = tableListdb.Count();
            for (int i = 0; i < row; i += 1)
            {
                var dataRows = new DSDataRow();
                dataRows["  " + tableID] = "  " + PrimaryKeyList[i];
                dataRows[tableName] = TableNameList[i];
                dataRows[userName] = UserNameList[i];
                dataRows[dateCreated] = tableListdb.readDateTime(dateCreated, 0);
                Rows.Add(dataRows);
            }
        }
    }
}