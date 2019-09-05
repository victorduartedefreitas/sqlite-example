using SQLite;
using SqliteExample.Models;

namespace SqliteExample.DataAccess
{
    public abstract class BaseDataAccess
    {
        protected readonly string dbPath;

        public BaseDataAccess()
        {
            string applicationFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mywallet");
            dbPath = System.IO.Path.Combine(applicationFolderPath, "mywallet.db");

            CreateDataBase();
        }

        private void CreateDataBase()
        {
            using (var db = new SQLiteConnection(dbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite))
            {
                db.CreateTable<Spending>();
            }
        }
    }
}
