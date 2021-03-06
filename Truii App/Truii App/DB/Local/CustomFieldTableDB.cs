﻿using System;
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

namespace Truii_App.DB.Local
{
    public class CustomFieldTableDB
    {
        string docsFolder;
        string path;
        SqliteConnection connection;
        Context context;

        /// <summary>
        /// Initialise the database
        /// </summary>
        /// <param name="context">Allows it to know which activity it is calling it from</param>
        public CustomFieldTableDB(Context context)
        {
            this.context = context;
            docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            path = System.IO.Path.Combine(docsFolder, "TruiiCustomFieldTable.db");
            connection = new SqliteConnection("Data Source=" + path);
        }

        /// <summary>
        /// Creates the CustomFieldTable database within the phone's library
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
                        command.CommandText = "CREATE TABLE CustomFieldTable(CustomFieldID INTEGER PRIMARY KEY AUTOINCREMENT, FieldID INTEGER NOT NULL, GraphID INTEGER NOT NULL, Red INTEGER NOT NULL, Green INTEGER NOT NULL, Blue INTEGER NOT NULL)";
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
                    command.CommandText = "SELECT * FROM CustomFieldTable";
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
        /// Collects the data within the CustomFieldTable Database
        /// </summary>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>A list of integers of the TableID</returns>
        public List<int> readInt(string fieldName)
        {
            List<int> data = new List<int>();
            connection.Open();
            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM CustomFieldTable";
                    var read = command.ExecuteReader();
                    while (read.Read())
                    {
                        data.Add((int)read[fieldName]);
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
        /// Inserts data to the CustomFieldTable database
        /// </summary>
        /// <param name="FieldID">The ID of the Field it will be colouring</param>
        /// <param name="GraphID">The ID of the Graph it will be coming from</param>
        /// <param name="Red">The Red of the RGB colour model (must be between 0 to 255)</param>
        /// <param name="Green">The Green of the RGB colour model (must be between 0 to 255)</param>
        /// <param name="Blue">The Blue of the RGB colour model (must be between 0 to 255)</param>
        public void InsertData(int FieldID, int GraphID, int Red, int Green, int Blue)
        {
            Red = ColourCheck(Red);
            Green = ColourCheck(Green);
            Blue = ColourCheck(Blue);
            connection.Open();
            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("INSERT INTO CustomFieldTable(FieldID, GraphID, Red, Green, Blue) VALUES ( {0}, {1}, {2}, {3}, {4})", FieldID, GraphID, Red, Green, Blue);
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
                    command.CommandText = "Select * FROM CustomFieldTable";
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

        /// <summary>
        /// Converts any number that is either less than 0 or greater than 255
        /// </summary>
        /// <param name="colour">The colour code number</param>
        /// <returns>The colour code number that could either be 0, 255 or a number between them</returns>
        private int ColourCheck(int colour)
        {
            if (colour < 0)
            {
                return 0;
            }
            else if (colour > 255)
            {
                return 255;
            }
            return colour;
        }
    }
}