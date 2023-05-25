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
        private string Name;
        private string Email;

        //Constructor
        public Author(string Name)
        {
            this.Name = Name;
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
            return Name;
        }
        public string GetAuthor()
        {
            return Name;
        }
    }
}
