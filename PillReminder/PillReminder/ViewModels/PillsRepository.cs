using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;
using PillReminder.Models;

namespace PillReminder.ViewModels
{
    public class PillsRepository
    {
        SQLiteConnection database;
        public PillsRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Pill>();
        }
        public IEnumerable<Pill> GetItems()
        {
            return database.Table<Pill>().ToList();
        }
        public Pill GetItem(int id)
        {
            return database.Get<Pill>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Pill>(id);
        }
        public int SaveItem(Pill item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}

