using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
            Book book = new Book();
            book.ISBN = Int32.Parse(ISBN);
            book.Title = Title;
            book.Author = new Author(AuthorName);
            book.isAudio = isAudio;
            book.PublisherName = publisherName;
            book.Year = year;
            book.NumberOfPages = numberofPages;
            book.AvailableCopies = availableCopies;
            return book;
        }
        #endregion
    }

    //Implementing 3 Types of Books

    #region History Class
    public class History : Book
    {
        //Public Methods
        #region Public Methods
        public override GenreTypes GetGenre()
        {
            return GenreTypes.History;
        }
        #endregion

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
