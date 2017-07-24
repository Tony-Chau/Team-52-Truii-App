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
    public class TableNameDB
    {
        string docsFolder;
        string path;
        SqliteConnection connection;
        Context context;
        public TableNameDB(Context context)
        {
            this.context = context;
            docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            path = System.IO.Path.Combine(docsFolder, "Truii.db");
            connection = new SqliteConnection("Data Source=" + path);
        }

        public DateTime readDateTime(string fieldName, int index)
        {
            List<DateTime> data = new List<DateTime>();
            connection.Open();
            try
            {
                using (var command = connection.CreateCommand())
                {

                    command.CommandText = "SELECT * FROM TableName";
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

        public int readInt(string fieldName, int index)
        {
            List<int> data = new List<int>();
            connection.Open();
            try
            {
                using (var command = connection.CreateCommand())
                {

                    command.CommandText = "SELECT * FROM TableName";
                    var read = command.ExecuteReader();
                    while (read.Read())
                    {
                        data.Add((int)read[fieldName]);
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
            return -1;
        }


        public string readString(string fieldName, int index)
        {
            List<string> data = new List<string>();
            connection.Open();
            try
            {
                using (var command = connection.CreateCommand())
                {

                    command.CommandText = "SELECT * FROM TableName";
                    var read = command.ExecuteReader();
                    while (read.Read())
                    {
                        data.Add(read[fieldName].ToString());
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
            return "";
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
                        string QueryCommand = "CREATE TABLE TableName(TableID INTEGER PRIMARY KEY AUTOINCREMENT, TableName varchar(255) NOT NULL, UserName VARCHAR(255) NOT NULL, DateCreated DATETIME NOT NULL)";
                        command.CommandText = QueryCommand;
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
        public async void InsertData(string TableName, string UserName, DateTime TimeCreated)
        {
            connection.Open();
            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("INSERT INTO TableName(TableName, UserName, DateCreated) VALUES( {0}, {1}, {2})", TableName, UserName, TimeCreated);
                    var rowcount = command.ExecuteNonQuery();
                }
            }catch (Exception ex)
            {
                Toast.MakeText(this.context, ex.Message, ToastLength.Long).Show();
            }
            connection.Close();
        }
    }
}