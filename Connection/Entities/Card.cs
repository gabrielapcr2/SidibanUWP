using Connection.Enumerates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Connection.Entities
{
    public class Card
    {
        [Key]
        public string Title { get; set; }
        public  EnumCardGroups group { get; set; }
        public string Description { get; set; }

       

        public override string ToString()
        {
            return $"Card = [Title: {Title}, Description: {Description}]";
        }
    
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Card other = obj as Card;
            bool isTitleAreTheSame = this.Title == other.Title;
            bool isDescriptionAreTheSame = this.Description == other.Description;
            return isTitleAreTheSame && isDescriptionAreTheSame;
        }

        
 
    }
}
