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

        /// <summary>
        /// Initialises GraphDataTable
        /// Pulls Data from the database and generates columns and rows to match the said data
        /// and inputs that dta afterwards 
        /// </summary>
        /// <param name="context">Allows it to know which activity it is calling it from</param>
        /// <param name="Name">Used to Determine which spreadsheet is to be openned</param>
        public GraphDataTable(Context context, String Name) : base(Name)
        {
            GraphTableDB graphTabledb = new GraphTableDB(context);
            
            string graphID = "GraphID";
            string tableID = "TableID";
            string userName = "UserName";
            string dateCreated = "DateCreated";

            var dataColumns = new Dictionary<string, float>();
            dataColumns.Add("  " + graphID, 100);
            dataColumns.Add(tableID, 100);
            dataColumns.Add(userName, 150);
            dataColumns.Add(dateCreated, 300);

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

            List<string> PrimaryKeyList = graphTabledb.readString(graphID);
            List<string> TableIDList = graphTabledb.readString(tableID);
            List<string> UserNameList = graphTabledb.readString(userName);
            int row = graphTabledb.Count();
            for (int i = 0; i < row; i += 1)
            {
                var dataRows = new DSDataRow();
                
                dataRows["  " + graphID] = "  " + PrimaryKeyList[i];
                dataRows[tableID] = TableIDList[i];
                dataRows[userName] = UserNameList[i];
                dataRows[dateCreated] = graphTabledb.readDateTime(dateCreated, i);

                Rows.Add(dataRows);
            }
        }
    }
}