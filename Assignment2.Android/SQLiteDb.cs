using System;
using System.IO;
using SQLite;
using Assignment2.Droid;
using Assignment2.Persistence;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteDb))]

namespace Assignment2.Droid
{
    public class SQLiteDb : ISQLiteDB
    {

        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "PunchRecords.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
