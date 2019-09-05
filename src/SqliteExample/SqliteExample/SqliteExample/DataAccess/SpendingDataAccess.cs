using SQLite;
using SqliteExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SqliteExample.DataAccess
{
    public class SpendingDataAccess : BaseDataAccess
    {
        public Spending GetSpending(Guid id)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                return db.Get<Spending>(id);
            }
        }

        public IList<Spending> GetSpendings(string description)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                return (from s in db.Table<Spending>()
                       where s.Description.Contains(description)
                       select s).ToList();
            }
        }

        public IList<Spending> GetSpendings(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                var query = "SELECT * FROM SPENDING WHERE SPENDINGDATE >= ? AND SPENDINGDATE <= ?";
                return db.Query<Spending>(query, startDate, endDate);
            }
        }

        public void Save(Spending spending)
        {
            if (spending == null)
                return;

            using (var db = new SQLiteConnection(dbPath))
            {
                db.InsertOrReplace(spending);
            }
        }

        public void Delete(Guid spendingId)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                db.Delete<Spending>(spendingId);
            }
        }
    }
}
