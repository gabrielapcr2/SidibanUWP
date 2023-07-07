using Connection.Commons;
using Connection.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Connection.DataBase
{
    public class DataBaseContext
    {

        private string _dataBasePath { get; set; }
        public DataBaseContext(string dbPath)
        {
            _dataBasePath = dbPath;
        }

        public async Task CreateDataBase()
        {
            GllobalParameters.DataBasePath = _dataBasePath; 

            using (var db = new CardsDataBase())
            {
                await db.Database.EnsureCreatedAsync();
            }
        }
        #region
        public async Task AddCard(Card newCard)
        {
            using (var db = new CardsDataBase())
            {
                db.Add(newCard);
                await db.SaveChangesAsync();
                //var nn = db.Model.Relational();
                
            }
        }
        public async Task DeleteCard(Card Card)
        {
            using (var db = new CardsDataBase())
            {
                db.Remove(Card);
                await db.SaveChangesAsync();
            }
        }
        public async Task UpdateCard(Card newCard)
        {
            using(var db = new CardsDataBase())
            {
                db.Update(newCard);
                await db.SaveChangesAsync();
            }
        }

        public List<Card> GetCard()
        {
            using (var db = new CardsDataBase())
            {
                return db.Cards.ToList();
            }
        }




        #endregion

    }
}
