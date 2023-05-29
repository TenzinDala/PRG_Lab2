using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Seneca
{
    public class Library : ILibrary
    {
        public List<Book> allBooks { get; set; }
        public static List<string> ISBNList = new List<string>();

        public bool AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public bool BorrowBook(Book book)
        {
            throw new NotImplementedException();
        }

        public List<Book> BorrowedBooks()
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAvailableBookCopies()
        {
            throw new NotImplementedException();
        }

        public bool Initialize(string bookDataFilePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(bookDataFilePath))
                {
                    bool isFirstRow = true;
                    string Line;
                    List<string> isbnCheckList = new List<string>();
                    allBooks = new List<Book>(); // Initialize the allBooks list
                    ISBNList.Clear();

                    while ((Line = reader.ReadLine()) != null)
                    {
                        if (isFirstRow)
                        { 
                            isFirstRow = false;
                            continue;
                        }
                        //string[] columns = Line.Split(',');
                        string[] columns = SplitCSVLine(Line);
                        //Console.WriteLine(columns[1]);
                        // Access the ISBN value (first column)
                        if (columns.Length > 0)
                        {
                            string isbn = columns[0];
                            string Title = columns[1];
                            string authorName = columns[2];
                            string authorEmail = columns[3];

                            bool isAudio = Convert.ToBoolean(columns[4].ToLower());
                            string publisherName = columns[5];
                            string publishingDate = columns[6];
                            DateTime Date = DateTime.Parse(publishingDate);
                            int year = Date.Year;
                            int numberOfPages = Int32.Parse(columns[7]);
                            int availableCopies = Int32.Parse(columns[8]);
                            string Genre = columns[9];
                            string FictionalCharacters = columns[10];
                            Author author = new Author(authorName, authorEmail);
                            if (ISBNList.Contains(isbn))
                            {
                                continue;
                            }
                            

                            Book book = new Book();
                            book.CreateBook(isbn, Title, author, isAudio, publisherName, year, numberOfPages, availableCopies);
                            allBooks.Add(book);
                            ISBNList.Add(isbn);

                        }
                    }
                    //Console.WriteLine("This is the Old ISBN");
                    //foreach (var isbnOld in isbnCheckList)
                    //{
                    //    Console.WriteLine(isbnOld.ToString());
                    //}
                    //List<string> finalISBNCheck = isbnCheckList.Distinct().ToList();
                    Console.WriteLine("This is the New ISBN");

                    foreach (var isbnNew in ISBNList)
                    {
                        Console.WriteLine(isbnNew.ToString());
                    }
                    Console.WriteLine("\nAll Books Check !!!\n");
                    foreach (var bookTest in allBooks)
                    {
                        Console.WriteLine("isbn is : "+ bookTest.GetISBN());
                        Console.WriteLine("Year is : " + bookTest.GetYear());
                        Console.WriteLine("Genre is :" + bookTest.GetGenre());
                        Console.WriteLine("Author is : " + bookTest.GetAuthor());
                        Console.WriteLine("AvailableCopies are : " +bookTest.GetAvailableCopies());
                        Console.WriteLine("Audio is : " + bookTest.GetisAudio());
                    }


                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        private string[] SplitCSVLine(string line)
        {
            List<string> columns = new List<string>();
            StringBuilder columnBuilder = new StringBuilder();
            bool inQuotes = false;

            foreach (char c in line)
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (c == ',' && !inQuotes)
                {
                    columns.Add(columnBuilder.ToString().Trim());
                    columnBuilder.Clear();
                }
                else
                {
                    columnBuilder.Append(c);
                }
            }

            columns.Add(columnBuilder.ToString().Trim());

            // Combine the columns that belong to the same cell enclosed in quotes
            if (inQuotes)
            {
                int startIndex = columns.Count - 2;
                int endIndex = columns.Count - 1;

                if (startIndex >= 0 && endIndex >= 0)
                {
                    string combinedValue = string.Join(",", columns.GetRange(startIndex, endIndex - startIndex + 1));
                    columns.RemoveRange(startIndex, endIndex - startIndex + 1);
                    columns.Add(combinedValue);
                }
            }

            return columns.ToArray();
        }
        //public bool Initialize(string bookDataFilePath)
        //{
        //    try
        //    {
        //        using (StreamReader reader = new StreamReader(bookDataFilePath))
        //        {
        //            string line;
        //            while ((line = reader.ReadLine()) != null)
        //            {
        //                string[] columns = line.Split(',');

        //                if (columns.Length >= 3)
        //                {
        //                    string isbn = columns[0];
        //                    ISBNList.Add(isbn);
        //                    Console.WriteLine(ISBNList.ToString());

        //                    if (ISBNList.Contains(isbn))
        //                    {
        //                        continue;
        //                    }


        //                    // Check if a book with the same ISBN already exists in the list
        //                    //bool isDuplicate = allBooks.Any(b => b.ISBN == isbn);
        //                    //if (isDuplicate)
        //                    //{
        //                    //    // Skip this book with the same ISBN
        //                    //    continue;
        //                    //}
        //                    //Book book = new Book
        //                    //{
        //                    //    ISBN = isbn,
        //                    //    Author = authorName,
        //                    //    Publisher = publisherName
        //                    //};

        //                    //// Add the book to the list
        //                    //books.Add(book);

        //                    // Add the book to the list
        //                    // Create a new Book object


        //                }
        //            }


        //        }
        //        return true;
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return false;

        //    }

        //}

        public bool ReturnBook(Book book)
        {
            throw new NotImplementedException();
        }

        public List<Book> SearchBookByAuthorName(string authorName)
        {
            throw new NotImplementedException();
        }

        public List<Book> SearchBookByTitle(string searchKeyword)
        {
            throw new NotImplementedException();
        }

        public List<Book> SearchBooksByGenre(Book.GenreTypes genreTypes)
        {
            throw new NotImplementedException();
        }
    }
    }
