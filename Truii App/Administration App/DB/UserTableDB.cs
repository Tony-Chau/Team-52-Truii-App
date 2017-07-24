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
using Mono.Data.Sqlite;
using Java.IO;

namespace Administration_App.DB
{
    public class UserTableDB
    {
        string docsFolder;
        string path;
        SqliteConnection connection;
        Context context;
        public UserTableDB(Context context)
        {
            this.context = context;
            docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            path = System.IO.Path.Combine(docsFolder, "Truii.db");
            connection = new SqliteConnection("Data Source=" + path);
        }

        /// <summary>
        /// Collects the data from the database depending on the name of the field. 
        /// This only collects data if their type is a string format or a primary key
        /// </summary>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>A list string data from the database that was recorded</returns>
        public List<string> readString(string fieldName)
        {
            List<string> data = new List<string>();
            connection.Open();
            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM UserTable";
                    var read = command.ExecuteReader();
                    while (read.Read())
                    {
                        data.Add(read[fieldName].ToString());
                    }
                    connection.Close();
                    return data;
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(context, ex.Message, ToastLength.Long).Show();
            }
            connection.Close();
            return data;
        }

        
        /// <summary>
        /// Creates the TableName database within the phone's library
        /// </summary>
        public async void CreateTable()
        {
            var connectionString = string.Format("Data Source={0};Version=3", path);
            try
            {
                SqliteConnection.CreateFile(path);
            }
            catch (IOException ex)
            {
                Toast.MakeText(this.context, ex.Message, ToastLength.Long).Show();
            }
            connection.Open();
            try
            {
                using (var connect = new SqliteConnection((connectionString)))
                {
                    await connect.OpenAsync();
                    using (var command = connect.CreateCommand())
                    {
                        command.CommandText = "CREATE TABLE UserTable(UserName varchar(255) NOT NULL, Password VARCHAR(255) NOT NULL)";
                        command.CommandType = System.Data.CommandType.Text;
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this.context, ex.Message, ToastLength.Long).Show();
            }
            connection.Close();
        }

        /// <summary>
        /// Insert data to the database
        /// </summary>
        /// <param name="UserName">The name of the Username</param>
        /// <param name="Password">The Username's password</param>
        public void InsertData(string UserName, string Password)
        {
            connection.Open();
            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("INSERT INTO UserTable(UserName, Password) VALUES( \"{0}\", \"{1}\")", UserName, Password);
                    var rowcount = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this.context, ex.Message, ToastLength.Long).Show();
            }
            connection.Close();
        }


        /// <summary>
        /// Counts the number of rows within the database
        /// </summary>
        /// <returns>The number of rows</returns>
        public int Count()
        {
            int count = 0;
            connection.Open();
            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "Select * FROM UserTable";
                    var read = command.ExecuteReader();
                    while (read.Read())
                    {
                        count += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this.context, ex.Message, ToastLength.Long).Show();
            }
            connection.Close();
            return count;
        }
    }
}