using SqliteExample.DataAccess;
using SqliteExample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SqliteExample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly SpendingDataAccess spendingDataAccess = new SpendingDataAccess();
        public MainPage()
        {
            InitializeComponent();

            var s = new Spending
            {
                SpendingId = Guid.NewGuid(),
                Description = "Notebook",
                Amount = 2499.90m,
                TotalOfInstallments = 10,
                InstallmentValue = 244.99m,
                SpendingDate = DateTime.Now
            };

            spendingDataAccess.Save(s);
            var find1 = spendingDataAccess.GetSpendings("note");
        }
    }
}
