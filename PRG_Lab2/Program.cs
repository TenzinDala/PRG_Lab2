/*
Programmer : Tenzin Dala
Student ID : 134244219
Course     : PRG455NAB
College    : Seneca College Newnham Campus
*/

using Seneca;

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
 
*/

