using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Seneca.Book;

namespace Seneca
{
    public interface ILibrary
    {
        // Fields/Attributes

        public static List<string> IssuedBooks { get; set; }

        public bool Initialize(string bookDataFilePath);
        public bool AddBook(Book book);
        public List<Book> GetAvailableBookCopies();
        public bool BorrowBook(Book book);
        public List<Book> BorrowedBooks();
        public bool ReturnBook(Book book);
        public List<Book> SearchBookByTitle(string searchKeyword);
        public List<Book> SearchBookByAuthorName(string authorName);
        public List<Book> SearchBooksByGenre(GenreTypes genreTypes);
    }
}
