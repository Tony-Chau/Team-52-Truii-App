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
    public class UserDataTable : DSDataTable
    {
        public UserDataTable()
        {

        }
        
        public UserDataTable(Context context, String Name) : base(Name)
        {
            var dataColumns = new Dictionary<string, float>();
            dataColumns.Add("  UserID", 75);
            dataColumns.Add("UserName/Email", 200);
            dataColumns.Add("Password", 150);

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

                ID = Loop+1;

                dataRows["  UserID"] = "  User" + ID;
                dataRows["UserName/Email"] = "user" + ID;
                dataRows["Password"] = "password" + ID;

                Rows.Add(dataRows);
            }
        }
    }
}