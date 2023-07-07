using Connection.Enumerates;
using System;
using System.Collections.Generic;
using Connection.DataBase;
using System.Linq;
using System.Text;
using System.Threading;

namespace Connection.Entities
{
    public class CardGroup
    {
        public string Name { get; set; }
        private List<Card> Cards { get; set; }

        public CardGroup(string name)
        {
            Name = name;
           
        }
        
        public void Add(Card card)
        {
            Cards.Add(card);
        }

        public void Remove(Card card)
        {
            Cards.Remove(card);
        }
        

        public Card Get(string name)
        {
            Card wantedCard = Cards.Find(c => c.Title.Equals(name));
            return wantedCard;
        }
        public void Move(Card card)
        {
           Cards.GetEnumerator().MoveNext();
        }
        

    }
}
