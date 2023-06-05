/*
Programmer : Tenzin Dala
Student ID : 134244219
Course     : PRG455NAB
College    : Seneca College Newnham Campus
*/

using Seneca;
using static System.Net.Mime.MediaTypeNames;

namespace Seneca
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tCreate Book of your Choice!!!\n");

            //#region Create Book Method Check
            ////Testing Create Book Methods
            //History historyBook = new History();

            ////Book historyBook = history; //Upcasting to use parent's Method
            ////Book book = (Book)history;
            //Book book = historyBook.CreateBook("1232", "Reverant", "Tenzin Dala", true, "Tenzin", 2000, 2000, 23300);
            //Console.WriteLine($"\tISBN of the book is : {book.GetISBN()}");
            //Console.WriteLine($"\tTitle of the Book is : {book.GetTitle()}");
            //Console.WriteLine($"\tValue of Audio is : {book.GetisAudio()}");
            //Console.WriteLine($"\tPublisher's Name is : {book.GetPublisherName()}");
            //Console.WriteLine($"\tYear : {book.GetYear()}");
            //Console.WriteLine($"\tNumeber of Pages : {book.GetNumberOfPages()}");
            //Console.WriteLine($"\tAvailable Copies : {book.GetAvailableCopies()}\n");

            ////Upcasting to get the Genre Enum Value from the derived class
            //Book baseBook = historyBook;
            //Console.WriteLine($"\tGenre type is : {baseBook.GetGenre()}");

            ////Testing Author Class
            //Author author = book.GetAuthor();
            //string authorName = author.GetName();
            //Console.WriteLine($"\tAuthor's Name : {authorName}\n");

            //#endregion

            //Console.ReadKey();

            ////ISBN Check Test
            //#region ISBN Check
            //History ISBNCheck = new History();

            ////Book historyBook = history; //Upcasting to use parent's Method
            ////Book book = (Book)history;
            //Book Check = ISBNCheck.CreateBook("1232", "Reverant", "Tenzin Dala", true, "Tenzin", 2000, 2000, 23300);
            //#endregion
            //Console.ReadKey();

            ////To Check History Class
            //#region Checking History Methods
            //Console.WriteLine("\t\tInitiating History Class Test\n");
            //History history = new History();
            //Console.WriteLine($"\tGenre of the Book is : {history.GetGenre()}\n");

            //#endregion

            //Console.ReadKey();
            ////To Check Fictional Character Methods in Fiction Class
            //#region Checking Fictional Character Methods
            //Console.WriteLine("\t\tInitiating Fictional Character Test\n");
            //Fiction fiction = new Fiction();
            //fiction.StoreFictionalCharacter("Tenzin");
            //fiction.StoreFictionalCharacter("Daniel\n");

            //List<string> characters = fiction.GetFictionalCharacters();
            //Console.WriteLine($"\tGenre of the Book is : {fiction.GetGenre()}\n");

            //foreach (var character in characters)
            //{
            //    Console.WriteLine($"\tCharacter Name : {character}");
            //}

            //#endregion

            //Console.ReadKey();
            ////To Check Drama Class
            //#region Checking Drama Methods
            //Console.WriteLine("\t\tInitiating Drama Class Test\n");
            //Drama drama = new Drama();
            //Console.WriteLine($"\tGenre of the Book is : {drama.GetGenre()}\n");
            //Console.WriteLine("\tThe End!!!");
            //#endregion


            //############################### Lab 3 Assignment ################################

            Library testLibrary = new Library();
            string filePath = @"D:\PRG\Lab03\BookData.csv";
            testLibrary.Initialize(filePath);

            //Creating a history class and adding it to the Library
            History history = new History();
            Book historyBook = history;
            Author authorHistory = new Author("Tenzin Dala", "tenzindala@email");
            historyBook.CreateBook("123", "Reverant", authorHistory , true, "Tenzin", 2000, 2000, 23300);
            testLibrary.AddBook(historyBook);

            //Creating a Fiction class and adding it to the Library

            Fiction fiction = new Fiction();
            Book fictionBook = fiction;
            Author authorFiction = new Author("Smriti", "tenzindala@email");
            fictionBook.CreateBook("124", "Demon Slayer", authorFiction, true, "Tenzin", 20001, 20200, 23322200);
            testLibrary.AddBook(fictionBook);

            //Creating a Drama class and adding it to the Library

            Drama drama = new Drama();
            Book dramaBook = drama;
            Author authorDrama = new Author("Tenzin Dala", "tenzindala@email");
            dramaBook.CreateBook("125", "Reverant", authorDrama, true, "Tenzin", 2000, 2000, 23300);
            testLibrary.AddBook(dramaBook);

            foreach (var notebook in testLibrary.allBooks) { 
                Console.WriteLine(notebook.GetISBN());
            }
            Console.WriteLine("\nChecking Available Books! \n");
            List<Book> test = testLibrary.GetAvailableBookCopies();
            foreach (var testbook in test)
            {
                Console.WriteLine(testbook.GetISBN());
            }
            Console.WriteLine("\nCheck for Borrow Book status!\n");
            Book secondBook = new Book();
            Author secondAuthor = new Author("Preeti", "tenzindala@email");
            secondBook.CreateBook("2000", "Reverant", secondAuthor, true, "Tenzin", 2000, 2000, 23300);
            testLibrary.AddBook(secondBook);
            Console.WriteLine("First Borrow!\n");
            testLibrary.BorrowBook(historyBook);
            Console.WriteLine("\nSecond Borrow\n");
            testLibrary.BorrowBook(dramaBook);
            //Console.WriteLine("\nReturning Borrow\n");
            //testLibrary.ReturnBook(book);
            //Console.WriteLine("\nSecond Time Returning\n");
            //testLibrary.ReturnBook(book);
            Console.WriteLine("\nChecking for Borrwed Book\n");
            List<Book> borrowed = testLibrary.BorrowedBooks();
            foreach (var borrow in borrowed)
            {
                Console.WriteLine(borrow.GetISBN());
            }
            Console.WriteLine("\nSearch Test with Title Name\n");

            List<Book> titleSearch =  testLibrary.SearchBookByTitle("demon slayer");
            foreach (var bookSearch in titleSearch)
            {
                Console.WriteLine(bookSearch.GetGenre());
            }

            Console.WriteLine("\nSearch Test with Author Name\n");

            List<Book> authorSearch = testLibrary.SearchBookByAuthorName("smriti");
            foreach (var authorNameSearch in authorSearch)
            {
                Console.WriteLine(authorNameSearch.GetGenre());
                Console.WriteLine(authorNameSearch.GetISBN());
            }

            Console.WriteLine("\nGenre Search Test\n");

            List<Book> GenreSearch = testLibrary.SearchBooksByGenre(Book.GenreTypes.History);

            foreach (var GenreTypeSearch in GenreSearch)
            {
                Console.WriteLine(GenreTypeSearch.GetGenre());
                Console.WriteLine(GenreTypeSearch.GetISBN());
            }
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit; // Register the event handler

        }

        //############################## This Section will execute every time the Program Ends ##########################

        static void OnProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("Enter a key to delete the borrowed files!!!");
            Console.ReadLine(); // Start the Windows Forms application

            //Library testDeleteFile = new Library();
            //List<Book> borrowed = testDeleteFile.BorrowedBooks();
            //foreach (var borrow in borrowed)
            //{
            //    Console.WriteLine($"{borrow.GetISBN()} ISBN getting Deleted!!!");

            //}
            List<string> TEXT_NAME = new List<string>();
            TEXT_NAME.Add("123");
            TEXT_NAME.Add("125");
            foreach(string text in TEXT_NAME) 
            {
                string filePath = $@"D:\PRG\Lab03\{text}.txt";


                FileManager deleteFile = new FileManager();
                deleteFile.DeleteFile(filePath);
            }

          

          


        }
    }
}

/*
To DO

1) Make changes to the Author author input
2) Ask For Validations in the file reading  
3) Just Skip or return False?
4) How to validate Author Email and name since the parameter has changed
5) Should Book now need a constructor?
6) How is this book being called?
7) Will the attributes be already defined?

Q.1. Should we change the return for Author?

Q.2. Where would you like us to create the txt file?
 
*/

