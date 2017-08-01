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
using System.IO;
using Truii_App.DB.Local;

namespace Truii_App.Functions
{
    public class DatabaseFunction
    {
        UserTableDB UserTable;
        CustomFieldTableDB CustomFieldTable;
        FieldTableDB FieldTable;
        GraphTableDB GraphTable;
        TableListDB TableList;
        public DatabaseFunction(Context context) {
            UserTable = new UserTableDB(context);
            CustomFieldTable = new CustomFieldTableDB(context);
            FieldTable = new FieldTableDB(context);
            GraphTable = new GraphTableDB(context);
            TableList = new TableListDB(context);
        }

        public void CreateDatabase()
        {
            UserTable.CreateTable();
            CustomFieldTable.CreateTable();
            FieldTable.CreateTable();
            GraphTable.CreateTable();
            TableList.CreateTable();
        }
        
        public bool CheckIfDatabaseExist()
        {
            string docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string path = System.IO.Path.Combine(docsFolder, "TruiiUserTable.db");
            return File.Exists(path);
        }
    }
}