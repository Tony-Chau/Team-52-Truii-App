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
    public class UserDataTable : DSDataTable
    {
        public UserDataTable()
        {

        }

        /// <summary>
        /// Initialises UserDataTable
        /// Pulls Data from the database and generates columns and rows to match the said data
        /// and inputs that dta afterwards 
        /// </summary>
        /// <param name="context">Allows it to know which activity it is calling it from</param>
        /// <param name="Name">Used to Determine which spreadsheet is to be openned</param>
        public UserDataTable(Context context, String Name) : base(Name)
        {
            UserTableDB userTabledb = new UserTableDB(context);
            
            string userName = "UserName";
            string passWord = "Password";

            var dataColumns = new Dictionary<string, float>();
            dataColumns.Add("  " + userName, 150);
            dataColumns.Add(passWord, 150);

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

            List<string> UserNameList = userTabledb.readString(userName);
            List<string> PassWordList = userTabledb.readString(passWord);
            int row = userTabledb.Count();
            for (int i = 0; i < row; i += 1)
            {
                var dataRows = new DSDataRow();

                dataRows["  " + userName] = "  " + UserNameList[i];
                dataRows[passWord] = PassWordList[i];

                Rows.Add(dataRows);
            }
        }
    }
}