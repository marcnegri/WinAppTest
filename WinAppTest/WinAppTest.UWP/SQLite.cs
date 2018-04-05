using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTest;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(WinAppTest.UWP.SQLite))]
namespace WinAppTest.UWP
{
    public class SQLite : ISQLite
    {
        public global::SQLite.SQLiteConnection GetConnection()
        {
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "TodoSQLite.db3");
            return new global::SQLite.SQLiteConnection(path);
        }

    }
}