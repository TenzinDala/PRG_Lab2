using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seneca
{
    public class Author
    {
        //Private Fields
        private string authorName;

        //Constructor
        public Author(string Name)
        {
            this.authorName = Name;
            //if (string.IsNullOrWhiteSpace(Email))
            //{
            //    this.Email = Email;
            //}
            //else
            //{
            //    Console.WriteLine("Email should not have any white Spaces!!!");
            //}

        }

        //Public methods
        public string GetName()
        { 
            return authorName;
        }
        public string GetAuthor()
        {
            return authorName;
        }
    }
}
