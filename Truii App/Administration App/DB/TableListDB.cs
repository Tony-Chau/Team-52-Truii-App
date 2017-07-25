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

namespace Administration_App
{
    public class TableListDB
    {
        string docsFolder;
        string path;
        SqliteConnection connection;
        Context context;
        public TableListDB(Context context)
        {
            this.context = context;
            docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            path = System.IO.Path.Combine(docsFolder, "TruiiTL.db");
            connection = new SqliteConnection("Data Source=" + path);
        }

        /// <summary>
        /// Collects the data from the database depending on the name of the field. 
        /// This only collects data if their type is a DateTime format
        /// </summary>
        /// <param name="fieldName">Name of the Field</param>
        /// <returns>A list of DataTime data from the database that was recorded</returns>
        public DateTime readDateTime(string fieldName, int index)
        {
            List<DateTime> data = new List<DateTime>();
            connection.Open();
            try
            {
                using (var command = connection.CreateCommand())
                {

                    command.CommandText = "SELECT * FROM TableList";
                    var read = command.ExecuteReader();
                    while (read.Read())
                    {
                        data.Add((DateTime)read[fieldName]);
                    }
                    connection.Close();
                    return data[index];
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(context, ex.Message, ToastLength.Long).Show();
            }
            connection.Close();
            return new DateTime();
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
                    command.CommandText = "SELECT * FROM TableList";
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
        /// Creates the TableList database within the phone's library
        /// </summary>
        public async void CreateTable()
        {
            var connectionString = string.Format("Data Source={0};Version=3", path);
            try
            {
                SqliteConnection.CreateFile(path);
            }catch (IOException ex)
            {
                Toast.MakeText(this.context, ex.Message, ToastLength.Long).Show();
            }
            connection.Open();
            try
            {
                using (var connect = new SqliteConnection((connectionString)))
                {
                    await connect.OpenAsync();
                    using (var command= connect.CreateCommand())
                    {
                        command.CommandText = "CREATE TABLE TableList(TableID INTEGER PRIMARY KEY AUTOINCREMENT, TableName VARCHAR(255) NOT NULL, UserName VARCHAR(255) NOT NULL, DateCreated DATETIME NOT NULL)";
                        command.CommandType = System.Data.CommandType.Text;
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }catch (Exception ex)
            {
                Toast.MakeText(this.context, ex.Message, ToastLength.Long).Show();
            }
            connection.Close();
        }


        /// <summary>
        /// Insert Data to the database
        /// </summary>
        /// <param name="TableName">The name of the table</param>
        /// <param name="UserName">The name of the Username who created the table</param>
        /// <param name="TimeCreated">The time the database was created</param>
        public void InsertData(string TableName, string UserName, DateTime TimeCreated)
        {
            connection.Open();
            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("INSERT INTO TableList(TableName, UserName, DateCreated) VALUES( \"{0}\", \"{1}\", {2})", TableName, UserName, TimeCreated.ToString("yyyy-mm-dd"));
                    var rowcount = command.ExecuteNonQuery();
                }
            }catch (Exception ex)
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
                    command.CommandText = "Select * FROM TableList";
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