using Seneca;

namespace Seneca
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create Book of your Choice!!!");
            //Testing Author Class
            History history = new History();
            Fiction fiction = new Fiction();
            Book bookFiction = (Book)fiction;
            Book book = (Book)history;
            Book new_book = book.CreateBook("1232", "Reverant", "Tenzin Dala", true, "Tenzin", 2000, 2000, 23300);
            //Book book = history.CreateBook("1232", "Reverant", "Tenzin Dala", true, "Tenzin", 2000, 2000, 23300);
            //Book book = history.CreateBook("1232", "Tenzin Dala", true, "Tenzin", 2000, 2000, 23300);
            Console.WriteLine(book.GetNumberOfPages());
            Console.WriteLine(fiction.StoreFictionalCharacter("Daniel"));
        }
    }
}

//q.1. What is the difference between author and name in author file???
//q.2. Close the program and start? or keep it in a loop so the ISBN has to be unique every time

//q.3. NameSpace

//Try and Catch Necessary?

//q.5. Do I need to create a constructor for BOOK?

//
