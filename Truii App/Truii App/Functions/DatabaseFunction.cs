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
        public DatabaseFunction(Context context) {
            UserTable = new UserTableDB(context);
        }

        public void CreateDatabase()
        {
            UserTable.CreateTable();
        }
        
        public bool CheckIfDatabaseExist()
        {
            string docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string path = System.IO.Path.Combine(docsFolder, "TruiiUserTable.db");
            return File.Exists(path);
        }
    }
}