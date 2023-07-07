using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Validation
{
    public static class CardValidation
    {
        public static string ValidateCard(string Title, string Description)
        {
            string errors = "";

            // Budget Amount Validation
            if (Title == "")
            {
                errors += "Dont have any Title \n";
            }
            else if (Description == "")
            {
                errors += "Dont have any Description \n";
            }
            else
            {
                errors = null;
            }
            return errors;
        }
    }
}
