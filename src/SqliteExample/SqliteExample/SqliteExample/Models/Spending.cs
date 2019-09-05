using SQLite;
using System;

namespace SqliteExample.Models
{
    [Table("Spendings")]
    public class Spending
    {
        [PrimaryKey]
        public Guid SpendingId { get; set; }
        public string Description { get; set; }
        public DateTimeOffset SpendingDate { get; set; }
        public decimal Amount { get; set; }
        public int TotalOfInstallments { get; set; }
        public decimal InstallmentValue { get; set; }
    }
}
