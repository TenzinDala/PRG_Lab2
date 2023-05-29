using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Seneca
{
    public class Book
    {
        //Enum for three different types of Books
        public enum GenreTypes
        {
            Unknown,
            History,
            Fiction,
            Drama
        }

        //Private Fields
        private string ISBN;
        private string Title;
        private Author Author;
        private bool isAudio;
        private string PublisherName;
        private int Year;
        private int NumberOfPages;
        private int AvailableCopies;

        //List is Static so that all instantiated objects will have the same value for Number number variable
        //ISBN should be unique
        public static List<string> ISBNList = new List<string>();

        //Public Methods
        #region Public Methods
        //ISBN should be unique
        public string GetISBN()
        {
            return ISBN.ToString();
        }

        public string GetTitle()
        {
            return Title;
        }

        public Author GetAuthor()
        {
            return Author;
        }
        public bool GetisAudio()
        {
            return isAudio;
        }
        public string GetPublisherName()
        {   
            return PublisherName;
        }
        public int GetYear()
        {
            return Year;
        }
        public int GetNumberOfPages()
        {
            return NumberOfPages;
        }
        public int GetAvailableCopies()
        {
            return AvailableCopies;
        }
        public virtual GenreTypes GetGenre()
        {
            return GenreTypes.Unknown;
        }
        public bool CreateBook(string ISBN,string Title, Author author, bool isAudio, string publisherName, int year, int numberOfPages, int availableCopies)
        {
            try 
            {
                bool checkISBNValue = ISBNCheck(ISBN);
                if(checkISBNValue)
                {
                    this.ISBN = ISBN;
                    ISBNList.Add(ISBN);
                }
                else
                {
                    throw new Exception("ISBN already exists!!!");
                }

                //Title Validation Step
                this.Title = Title;

                //Author Input
                this.Author = Author;

                this.isAudio = isAudio;

                //Publisher Name Input
                this.PublisherName = publisherName;

                //Year Validation Step
                bool yearCheckValue = validatingNumber(year);
                if (yearCheckValue)
                {
                    this.Year = year;
                }
                else
                {
                    throw new Exception("Value of Year should not be 0 or negative!");
                }
                bool pagesCheckValue = validatingNumber(numberOfPages);
                if (pagesCheckValue)
                {
                    this.NumberOfPages = numberOfPages;
                }
                else
                {
                    throw new Exception("Number should not be less than 0 or contain any decimal point!");
                }

                //Year Validation Step
                bool copiesCheckValue = validatingNumber(availableCopies);
                if (copiesCheckValue)
                {
                    this.AvailableCopies = availableCopies;
                }
                else
                {
                    throw new Exception("Number should not be less than 0 or contain any decimal point!");
                }
                return true;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        //Validation Methods
        public bool ISBNCheck(string isbn)
        {
            return !ISBNList.Contains(isbn);
        }
        public bool stringSpecialCharactersCheck(string str)
        {
            string pattern = "^[a-zA-Z ]*$"; 

            if (Regex.IsMatch(str, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool validatingNumber(int number)
        {
            if(number < 0 | number.ToString().Contains("."))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
    }

    //Implementing 3 Types of Books

    public class History : Book
    {
        //Public Methods
        public override GenreTypes GetGenre()
        {
            return GenreTypes.History;
        }

    }
    
    public class Fiction : Book
    {
        List<string> charactersList;

        //Constructor
        public Fiction()
        {
            this.charactersList = new List<string>();
        }

        //Public Methods
        public override GenreTypes GetGenre()
        {
            return GenreTypes.Fiction;
        }
        public List<string> GetFictionalCharacters()
        {
            return charactersList;
        }
        public void StoreFictionalCharacter(string characterName)
        {
            charactersList.Add(characterName);
        }
    }

    public class Drama : Book
    {
        //Public Methods
        public override GenreTypes GetGenre()
        {
            return GenreTypes.Drama;
        }
    }
}
