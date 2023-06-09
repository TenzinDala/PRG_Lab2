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



            #region Lab02 Main Program
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
            #endregion

            //############################### Lab 3 Assignment ################################

            //Initializing the Library before doing anything else
            Console.WriteLine("\tThe csv file is saved in the bin folder, inside the exe. The txts will also be created in that file using GetCurrentDirectory function\n");
            Console.ReadKey();
            Console.WriteLine("\tInitializing the books from csv\n");
            Library testLibrary = new Library();
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine($"The File Path is: {path}");
            string filePath = System.IO.Path.Combine(path, "BookData.csv");
            //string filePath = @"D:\PRG\Lab03\BookData.csv";
            testLibrary.Initialize(filePath);

            //######################## Test for History Class ############
            //Creating a history class and adding it to the Library
            Console.ReadKey();
            Console.WriteLine("\tCreating a history class and adding it to the Library\n");
            History history = new History();
            Book historyBook = history;
            Author authorHistory = new Author("Tenzin Dala", "tenzindala@email");
            historyBook.CreateBook("123", "Reverant", authorHistory , true, "Tenzin", 2000, 2000, 23300);
            Console.WriteLine($"\tisbn is :  {historyBook.GetISBN()}");
            Console.WriteLine($"\tYear is : {historyBook.GetYear()}");
            Console.WriteLine($"\tYear is : {historyBook.GetTitle()}");

            Console.WriteLine("\tGenre is :" + historyBook.GetGenre());
            Console.WriteLine($"\tAuthor is : {historyBook.GetAuthor().GetName()}");
            Console.WriteLine($"\tAvailableCopies are : {historyBook.GetAvailableCopies()}");
            Console.WriteLine($"\tAudio is :  {historyBook.GetisAudio()}\n");
            Console.WriteLine("\tAdding to the Library...............");
            testLibrary.AddBook(historyBook);

            //######################## Test for Fiction Class ############
            //Creating a Fiction class and adding it to the Library
            Console.ReadKey();
            Console.WriteLine("\tCreating a Book class and adding it to the Library\n");

            Fiction fiction = new Fiction();
            Book fictionBook = fiction;
            Author authorFiction = new Author("Smriti", "tenzindala@email");
            fictionBook.CreateBook("124", "Demon Slayer", authorFiction, true, "Tenzin", 20001, 20200, 23322200);
            testLibrary.AddBook(fictionBook);

            //######################## Test for Drama Class ############
            //Creating a Drama class and adding it to the Library
            Console.ReadKey();
            Console.WriteLine("\tCreating a Drama class and adding it to the Library\n");

            Drama drama = new Drama();
            Book dramaBook = drama;
            Author authorDrama = new Author("Tenzin Dala", "tenzindala@email");
            dramaBook.CreateBook("125", "Reverant", authorDrama, true, "Tenzin", 2000, 2000, 23300);
            testLibrary.AddBook(dramaBook);

            //Check for all the ISBNs stored in the List
            Console.ReadKey();
            Console.WriteLine("\tChecking for ISBN received from CSV and the newly created Books\n");
            foreach (var notebook in testLibrary.allBooks) { 
                Console.WriteLine(notebook.GetISBN());
            }
            Console.ReadKey();

            //Check for available books
            Console.WriteLine("\nChecking Available Books! \n");

            List<Book> test = testLibrary.GetAvailableBookCopies();
            foreach (var testbook in test)
            {
                Console.WriteLine(testbook.GetISBN());
            }

            //Check for Borrow Status
            Console.ReadKey();

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

            Console.ReadKey();

            Console.WriteLine("\nChecking for Borrwed Book\n");
            List<Book> borrowed = testLibrary.BorrowedBooks();
            foreach (var borrow in borrowed)
            {
                Console.WriteLine(borrow.GetISBN());
            }

            Console.ReadKey();

            Console.WriteLine("\nSearch Test with Title Name\n");
            Console.WriteLine("\nEntered keyword 'demon slayer' for testing\n");
            List<Book> titleSearch =  testLibrary.SearchBookByTitle("demon slayer");
            foreach (var bookSearch in titleSearch)
            {
                Console.WriteLine(bookSearch.GetTitle());
                Console.WriteLine(bookSearch.GetGenre());
            }


            Console.ReadKey();

            Console.WriteLine("\nSearch Test with Author Name\n");
            Console.WriteLine("\nEntered keyword 'smriti' for testing\n");

            List<Book> authorSearch = testLibrary.SearchBookByAuthorName("smriti");
            foreach (var authorNameSearch in authorSearch)
            {
                Console.WriteLine(authorNameSearch.GetAuthor().GetName());
                Console.WriteLine(authorNameSearch.GetGenre());
                Console.WriteLine(authorNameSearch.GetISBN());
            }


            Console.ReadKey();

            Console.WriteLine("\nGenre Search Test\n");

            List<Book> GenreSearch = testLibrary.SearchBooksByGenre(Book.GenreTypes.History);
            Console.WriteLine("\nSearching for history type Genre for testing\n");

            foreach (var GenreTypeSearch in GenreSearch)
            {
                Console.WriteLine(GenreTypeSearch.GetGenre());
                Console.WriteLine(GenreTypeSearch.GetISBN());
            }

            //####################### This line helps in executing the method before the program ends #########################
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit; // Register the event handler
        }

//############################## This Section will execute every time the Program Ends ##########################

        static void OnProcessExit(object sender, EventArgs e)
        {
            Console.ReadKey();

            Console.WriteLine("Enter a key to delete the txt created from borrowed files!!!");

            List<string> TEXT_NAME = new List<string>()
            {
                "123",
                "125"
            };
            //TEXT_NAME.Add("123");
            //TEXT_NAME.Add("125");
            foreach (string text in TEXT_NAME)
            {
                string path = Directory.GetCurrentDirectory();
                string filePath = System.IO.Path.Combine(path, $"{text}.txt");



                //FileManager deleteFile = new FileManager();
                FileManager.DeleteFile(filePath);
            }






        }
    }
}

/*
To DO

Q.1. How would you use static in File Manager?

Q.2. Where would you like us to create the txt file?

Q.3. How to use File Write Mode class?

To do  -

1) Use Append and Override Logic
2) Add Class instead of Static
3) txt file has to be in the executable
4) Add Genre.Unknown
5) Add Unknown for the Genre Logic

1) Logic for Append And OverWrite
2) Date and time only? in the txt file?
 
*/

