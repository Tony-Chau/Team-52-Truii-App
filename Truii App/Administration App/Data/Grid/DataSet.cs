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
        public DataSet(Context EntryCode)
        {
            Tables.Add(new UserDataTable(EntryCode, "User"));
            Tables.Add(new GraphDataTable(EntryCode, "Graph"));
            Tables.Add(new TableListDataTable(EntryCode, "Table"));
            Tables.Add(new FieldDataTable(EntryCode, "Field"));
        }
    }
}