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
    public class DataSet : DSDataSet
    {
        /// <summary>
        /// The Function used to Generate the Spreadsheet
        /// </summary>
        /// <param name="EntryCode">Allows it to know which activity it is calling it from</param>
        /// <param name="tableName">Used to Determine which spreadsheet to create and open</param>
        public DataSet(Context EntryCode, string tableName)
        {
            if (tableName == "User")
            {
                Tables.Add(new UserDataTable(EntryCode, "User"));
            }
            else if (tableName == "Graph"){
                Tables.Add(new GraphDataTable(EntryCode, "Graph"));
            }
            else if (tableName == "Table"){
                Tables.Add(new TableListDataTable(EntryCode, "Table"));
            }
            else if (tableName == "Field"){
                Tables.Add(new FieldDataTable(EntryCode, "Field"));
            }
            else if(tableName == "CustomField")
            {
                Tables.Add(new CustomFieldDataTable(EntryCode, "CustomField"));
            }else{

            }
            
        }
    }
}