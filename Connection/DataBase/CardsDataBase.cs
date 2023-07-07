using Connection.Commons;
using Connection.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Windows.Storage;

namespace Connection.DataBase
{
    public class CardsDataBase : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"DataSource={Path.Combine(ApplicationData.Current.LocalFolder.Path, "users.db")}");
    }
}
