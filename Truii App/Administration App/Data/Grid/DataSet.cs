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
                //Tables.Add(new FieldDataTable(EntryCode, "Field"));
            }else{

            }
            
        }
    }
}