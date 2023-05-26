﻿using System;
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
        private string Email;

        //Constructor
        public Author(string Name)
        {
            this.authorName = Name;
        }

        //Public methods
        public string GetName()
        { 
            return authorName;
        }
        public string GetEmail()
        {
            return Email;
        }
    }
}
