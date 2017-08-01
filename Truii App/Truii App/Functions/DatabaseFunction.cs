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

        /// <summary>
        /// Creates the all the database within the app (except VariousTables)
        /// </summary>
        public void CreateDatabase()
        {
            UserTable.CreateTable();
            CustomFieldTable.CreateTable();
            FieldTable.CreateTable();
            GraphTable.CreateTable();
            TableList.CreateTable();
        }
        
        /// <summary>
        /// Checks if one of the .db file is located within the phone
        /// </summary>
        /// <returns>a confirmation if the file exist</returns>
        public bool CheckIfDatabaseExist()
        {
            string docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string path = System.IO.Path.Combine(docsFolder, "TruiiUserTable.db");
            return File.Exists(path);
        }

        public bool UserAndPasswordCheck(string User, string password)
        {
            return false;
        }


    }
}