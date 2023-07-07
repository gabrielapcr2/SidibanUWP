using Connection.DataBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SidibanWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App ()
        {

             CreateDataBase();
            
        }
        public async void CreateDataBase()
        {
            using (var db = new CardsDataBase())
            {
                await db.Database.EnsureCreatedAsync();
            }
        }

    }
}
