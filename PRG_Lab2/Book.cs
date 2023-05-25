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
            History,
            Fiction,
            Drama
        }

        //Private Fields
        
        private string Title;
        private Author Author;
        private bool isAudio;
        private string PublisherName;
        private int Year;
        private int NumberOfPages;
        private int AvailableCopies;

        //Private static for incrementing ISBN number
        //Its Static so that all instantiated objects will have the same value for Number number variable
        //ISBN should be unique
        private int ISBN;

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
            return GenreTypes.History;
        }
        public Book CreateBook(string ISBN,string Title, string AuthorName, bool isAudio, string publisherName, int year, int numberofPages, int availableCopies)
        {
            try 
            {
                Book book = new Book();
                book.ISBN = Int32.Parse(ISBN);

                //Title Validation Step
                bool checkTitleValue = titleCheck(Title);
                if (checkTitleValue)
                {
                    book.Title = Title;
                }
                else
                {
                    throw new Exception("Title should only contain Alphabetical Characters!!!");
                }

                //Checking Author Name Validation
                bool authorValidation = authorCheck(AuthorName);
                if (authorValidation)
                {
                    book.Author = new Author(AuthorName);
                }
                else
                {
                    throw new Exception("Author Name should only contain Alphabetical Characters!!!");
                }

                if (isAudio == false | isAudio == true)
                {
                    book.isAudio = isAudio;
                }
                else
                {
                    throw new Exception("Value of Audio should either be true or false!!!");
                }
               
                book.PublisherName = publisherName;
                
                //Year Validation Step
                bool yearCheckValue = yearCheck(year);
                if (yearCheckValue)
                {
                    book.Year = year;
                }
                else
                {
                    throw new Exception("Value of Year should not be 0 or negative!");
                }
                book.NumberOfPages = numberofPages;
                book.AvailableCopies = availableCopies;
                return book;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            return null;

        }

        #region Validation Methods

        public void ISBNCheck()
        { 
        
        }
        public bool authorCheck(string author)
        {
            // Specify the pattern to match alphabet characters
            string pattern = @"^[a-zA-Z]+$"; // Matches one or more alphabet characters

            // Use Regex.IsMatch() to check if the input contains only alphabet characters
            if (Regex.IsMatch(author, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool titleCheck(string title)
        {
            // Specify the pattern to match alphabet characters
            string pattern = @"^[a-zA-Z]+$"; // Matches one or more alphabet characters

            // Use Regex.IsMatch() to check if the input contains only alphabet characters
            if (Regex.IsMatch(title, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool yearCheck(int year)
        {
            if (year < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void pagesCheck()
        { 
        
        }
        public void copiesCheck()
        { 
        
        }

        #endregion

        #endregion
    }

    //Implementing 3 Types of Books

    #region History Class
    public class History : Book
    {
        //Public Methods
        public override GenreTypes GetGenre()
        {
            return GenreTypes.History;
        }

    }
    #endregion

    #region Fiction Class
    public class Fiction : Book
    {
        //List<string> CharactersList = new List<string>();
        List<string> charactersList;

        //Constructor
        public Fiction()
        {
            charactersList = new List<string>();
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
    #endregion

    #region Drama Class
    public class Drama : Book
    {
        //Public Methods
        public override GenreTypes GetGenre()
        {
            return GenreTypes.Drama;
        }
    }
    #endregion


}
