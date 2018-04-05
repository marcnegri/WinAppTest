using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using WinAppTest.Models;

namespace WinAppTest.Data
{
    /// <summary>
    /// Classe de BDD - couche d'abastraction entre le client xamarin et une base embarquée SQLite
    /// </summary>
    public class MenuItemDatabase
    {
        static readonly object locker = new object();
        readonly SQLiteConnection database;

        public MenuItemDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Models.MenuItem>();
        }

        public IEnumerable<Models.MenuItem> GetItems()
        {
            lock (locker)
            {
                return database.Table<Models.MenuItem>().ToList();
            }
        }

        public Models.MenuItem Find(string title)
        {
            lock (locker)
            {
                return database.Table<Models.MenuItem>().FirstOrDefault();
            }
        }

        public int Insert(Models.MenuItem item)
        {
            lock (locker)
            {
                return database.Insert(item);
            }
        }

        public int Update(Models.MenuItem item)
        {
            lock (locker)
            {
                return database.Update(item);
            }
        }

        public int Delete(string title)
        {
            lock (locker)
            {
                return database.Delete<Models.MenuItem>(title);
            }
        }
    }
}
