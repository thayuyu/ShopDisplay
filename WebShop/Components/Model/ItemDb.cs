﻿using Microsoft.Data.Sqlite;

namespace WebShop.Components.Model
{
    public class ItemDb
    {
        public SqliteConnection connection;

        public void CreateFile()
        {
            string databaseFileName = AppContext.BaseDirectory + @"\ShopDisplay.db";
            if (!File.Exists(databaseFileName))
            {
                var myFile = File.Create(databaseFileName);
                myFile.Close();
            }
        }

        public void OpenConnection()
        {
            string databaseFileName = AppContext.BaseDirectory + @"\ShopDisplay.db";
            connection = new SqliteConnection("Data Source=" + databaseFileName);
            connection.Open();
        }

        public void CreateTable()
        {
            OpenConnection();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"CREATE TABLE IF NOT EXISTS Items([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [Name] NVARCHAR(64) NOT NULL, [PictureLink] NVARCHAR(64) NOT NULL, [Desc] NVARCHAR(200) NOT NULL, [Price] REAL NOT NULL)";
                command.ExecuteNonQuery();
            }
        }

        public List<Item> GetItems()
        {
            var list = new List<Item>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Items";
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    Item item = new Item();
                    item.Id = result.GetInt32(0);
                    item.Name = result.GetString(1);
                    item.Description = result.GetString(2);
                    item.PictureLink = result.GetString(3);
                    item.Description = result.GetString(4);
                    item.Price = result.GetDouble(5);
                    list.Add(item);
                }

            }

            return list;
        }

        public void DeleteItem(int id)
        {
            OpenConnection();

            using (var command = connection.CreateCommand())
            {
                string query = $"DELETE FROM Items where ID = '{id}'";
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
        }

        public void EditItem(int id, string changedattribute, string newvalue)
        {
            using (var command = connection.CreateCommand())
            {
                string query = $"UPDATE Item SET {changedattribute} = '{newvalue}' where ID = '{id}'";
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
        }
    }
}
