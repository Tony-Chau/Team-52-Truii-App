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
    public class FieldDataTable : DSDataTable
    {
        public FieldDataTable()
        {

        }
        
        public FieldDataTable(Context context, String Name) : base(Name)
        {
            FieldTableDB fieldTable = new FieldTableDB(context);
            fieldTable.CreateTable();
            fieldTable.InsertData("GreenField", 1, "type");

            string fieldName = "FieldName";
            string tableID = "TableID";
            string dataType = "DataType";

            var dataColumns = new Dictionary<string, float>();
            dataColumns.Add("  " + fieldName, 100);
            dataColumns.Add(tableID, 100);
            dataColumns.Add(dataType, 100);

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

            List<string> FieldNameList = fieldTable.readString(fieldName);
            List<int> TableIDList = fieldTable.readInt(tableID);
            List<string> DataTypeList = fieldTable.readString(dataType);
            int row = fieldTable.Count();
            for (int i = 0; i < row; i += 1)
            {
                var dataRows = new DSDataRow();
                
                dataRows["  " + fieldName] = "  " + FieldNameList[i];
                dataRows[tableID] = TableIDList[i];
                dataRows[dataType] = DataTypeList[i];

                Rows.Add(dataRows);
            }
        }
    }
}