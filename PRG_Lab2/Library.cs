﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Seneca
{
    public class Library : ILibrary
    {
        public List<string> columnLines { get; set; }

        public List<Book> allBooks { get; set; }
        public static List<string> ISBNList = new List<string>();
        List<Book> availableBooks = new List<Book>();
        List<Book> borrowedBooks = new List<Book>();

        public bool AddBook(Book book)
        {
            try
            {
                string isbn = book.GetISBN();
                if (!ISBNList.Contains(isbn))
                {
                    allBooks.Add(book);
                    ISBNList.Add(isbn);
                    return true;
                }
                else
                {
                    Console.WriteLine("Book with ISBN already exists!", isbn);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool BorrowBook(Book book)
        {
            string path = @"D:\PRG\Lab03\testingBorrowedBooks.txt";
            FileManager textFile = new FileManager();
            FileWriteModes fileWriteModes = new FileWriteModes();
            try
            {
                if (!book.borrowStatus)
                {
                    book.borrowStatus = true;
                    textFile.WriteFile(path, fileWriteModes);
                    Console.WriteLine("Book successfully borrowed.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Book is already borrowed.");
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<Book> BorrowedBooks()
        {
            borrowedBooks = new List<Book>();
            foreach (Book book in allBooks)
            {
                if (book.borrowStatus)
                {
                    borrowedBooks.Add(book);
                }
            }
            return borrowedBooks;

        }

        public List<Book> GetAvailableBookCopies()
        {
            foreach (Book book in allBooks)
            {
                if (!book.borrowStatus) // Replace IsBorrowed() with the actual method or property to check the borrowing status
                {
                    availableBooks.Add(book);
                }
            }
            return availableBooks;
        }

        #region Intialize_Original
        //public bool Initialize(string bookDataFilePath)
        //{
        //    try
        //    {
        //        using (StreamReader reader = new StreamReader(bookDataFilePath))
        //        {
        //            bool isFirstRow = true;
        //            string Line;
        //            allBooks = new List<Book>(); // Initialize the allBooks list
        //            ISBNList.Clear();

        //            while ((Line = reader.ReadLine()) != null)
        //            {
        //                if (isFirstRow)
        //                { 
        //                    isFirstRow = false;
        //                    continue;
        //                }
        //                //string[] columns = Line.Split(',');
        //                string[] columns = SplitCSVLine(Line);
        //                //Console.WriteLine(columns[1]);
        //                // Access the ISBN value (first column)
        //                if (columns.Length > 0)
        //                {
        //                    string isbn = columns[0];
        //                    string Title = columns[1];
        //                    string authorName = columns[2];
        //                    string authorEmail = columns[3];

        //                    bool isAudio = Convert.ToBoolean(columns[4].ToLower());
        //                    string publisherName = columns[5];
        //                    string publishingDate = columns[6];
        //                    DateTime Date = DateTime.Parse(publishingDate);
        //                    int year = Date.Year;
        //                    int numberOfPages = Int32.Parse(columns[7]);
        //                    int availableCopies = Int32.Parse(columns[8]);
        //                    string Genre = columns[9];
        //                    string FictionalCharacters = columns[10];
        //                    Author author = new Author(authorName, authorEmail);
        //                    if (ISBNList.Contains(isbn))
        //                    {
        //                        continue;
        //                    }
                            

        //                    Book book = new Book();
        //                    book.CreateBook(isbn, Title, author, isAudio, publisherName, year, numberOfPages, availableCopies);
        //                    allBooks.Add(book);
        //                    ISBNList.Add(isbn);

        //                }
        //            }
        //            //Console.WriteLine("This is the Old ISBN");
        //            //foreach (var isbnOld in isbnCheckList)
        //            //{
        //            //    Console.WriteLine(isbnOld.ToString());
        //            //}
        //            //List<string> finalISBNCheck = isbnCheckList.Distinct().ToList();
        //            Console.WriteLine("This is the New ISBN");

        //            foreach (var isbnNew in ISBNList)
        //            {
        //                Console.WriteLine(isbnNew.ToString());
        //            }
        //            Console.WriteLine("\nAll Books Check !!!\n");
        //            foreach (var bookTest in allBooks)
        //            {
        //                Console.WriteLine("isbn is : "+ bookTest.GetISBN());
        //                Console.WriteLine("Year is : " + bookTest.GetYear());
        //                Console.WriteLine("Genre is :" + bookTest.GetGenre());
        //                Console.WriteLine("Author is : " + bookTest.GetAuthor().GetName());
        //                Console.WriteLine("AvailableCopies are : " +bookTest.GetAvailableCopies());
        //                Console.WriteLine("Audio is : " + bookTest.GetisAudio());
        //            }


        //        }
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return false;
        //    }
        //}
        #endregion

        public bool Initialize(string bookDataFilePath)
        {
            try
            {
                    columnLines = new List<string>();

                    allBooks = new List<Book>(); // Initialize the allBooks list
                    FileManager fileManager = new FileManager();
                    columnLines = fileManager.ReadFile(bookDataFilePath);



                //Console.WriteLine(columns[1]);
                // Access the ISBN value (first column)

                foreach (string line in columnLines)
                {

                    List<string> columns = SplitCSVLine(line);
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
                        Console.WriteLine("isbn is : " + bookTest.GetISBN());
                        Console.WriteLine("Year is : " + bookTest.GetYear());
                        Console.WriteLine("Genre is :" + bookTest.GetGenre());
                        Console.WriteLine("Author is : " + bookTest.GetAuthor().GetName());
                        Console.WriteLine("AvailableCopies are : " + bookTest.GetAvailableCopies());
                        Console.WriteLine("Audio is : " + bookTest.GetisAudio());
                    }
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        private List<string> SplitCSVLine(string line)
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
            return columns;

            //// Merge columns that belong to the same cell enclosed in quotes
            //List<string> mergedColumns = new List<string>();
            //StringBuilder mergedColumnBuilder = new StringBuilder();
            //bool mergeInProgress = false;

            //foreach (string column in columns)
            //{
            //    if (!mergeInProgress && column.StartsWith("\""))
            //    {
            //        if (column.EndsWith("\""))
            //        {
            //            mergedColumns.Add(column.Trim('\"'));
            //        }
            //        else
            //        {
            //            mergedColumnBuilder.Clear();
            //            mergedColumnBuilder.Append(column.Trim('\"'));
            //            mergeInProgress = true;
            //        }
            //    }
            //    else if (mergeInProgress)
            //    {
            //        mergedColumnBuilder.Append("," + column);
            //        if (column.EndsWith("\""))
            //        {
            //            mergedColumns.Add(mergedColumnBuilder.ToString());
            //            mergeInProgress = false;
            //        }
            //    }
            //    else
            //    {
            //        mergedColumns.Add(column);
            //    }
            //}

            //return mergedColumns;
        }

        public bool ReturnBook(Book book)
        {
            if (book != null)
            {
                if (book.borrowStatus)
                {
                    book.borrowStatus = false;
                    Console.WriteLine("Book successfully returned.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Book was never borrowed.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid book.");
                return false;
            }
        }

        public List<Book> SearchBookByAuthorName(string authorName)
        {
            List<Book> authorSearchResults = new List<Book>();
            string keyWord = authorName.ToLower();
            foreach (Book book in allBooks)
            {
                Author author = book.GetAuthor();
                string name = author.GetName().ToLower();
                if (name.Contains(keyWord))
                {
                    authorSearchResults.Add(book);
                }
            }

            return authorSearchResults;
        }

        public List<Book> SearchBookByTitle(string searchKeyword)
        {
            List<Book> searchResults = new List<Book>();
            string keyWord = searchKeyword.ToLower();
            foreach (Book book in allBooks)
            {
                string title = book.GetTitle().ToLower();
                if (title.Contains(keyWord))
                {
                    searchResults.Add(book);
                }
            }

            return searchResults;
        }

        public List<Book> SearchBooksByGenre(Book.GenreTypes genreTypes)
        {
            List<Book> genreSearchResults = new List<Book>();
            foreach (Book book in allBooks)
            {
                if (book.GetGenre() == genreTypes)
                {
                    genreSearchResults.Add(book);
                }
            }

            return genreSearchResults;
        }
    }
    }
