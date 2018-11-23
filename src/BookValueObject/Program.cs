using BookValueObject.Models;
using BookValueObject.ValueObjects;
using System;
using System.Collections.Generic;

namespace BookValueObject
{
    static class Program
    {
        public static List<Book> _bookCollection = new List<Book>();
        public static List<BookV2> _bookV2Collection = new List<BookV2>();
        public static List<BookV3> _bookV3Collection = new List<BookV3>();

        private static void Main()
        {
            Console.WriteLine("-- Starting dumb books.");
            AddBook(new Book { Title = "IT", Author = "Stephen King", PublishYear = -3, PageCount = -5000 });
            AddBook(new Book { Title = "The Winds of Winter", Author = "George R. R. Martin", PublishYear = 9999, PageCount = 1200085410 });
            _bookCollection.ForEach(b => Console.WriteLine($"{b.Title} ({b.PublishYear})...{b.PageCount}"));
            Console.WriteLine();

            // Update with business logic in PageCount and error handling
            Console.WriteLine("-- Starting smarter books.");
            AddBookV2(new Book { Title = "IT", Author = "Stephen King", PublishYear = -3, PageCount = -5000 });
            AddBookV2(new Book { Title = "IT", Author = "Stephen King", PublishYear = 1986, PageCount = 1138 });
            AddBookV2(new Book { Title = "The Winds of Winter", Author = "George R. R. Martin", PublishYear = 9999, PageCount = 1200085410 });
            _bookV2Collection.ForEach(b => Console.WriteLine($"{b.Title} ({b.PublishYear})...{b.PageCount}"));
            Console.WriteLine();

            // Update with business logic in PageCount and error handling
            Console.WriteLine("-- Starting smarter-er books.");
            AddBookV3(new Book { Title = "Oedipus Rex", Author = "Sophocles", PublishYear = -450, PageCount = 75 });
            AddBookV3(new Book { Title = "IT", Author = "Stephen King", PublishYear = 1986, PageCount = 1138 });
            AddBookV3(new Book { Title = "The Winds of Winter", Author = "George R. R. Martin", PublishYear = 9999, PageCount = 1200085410 });
            _bookV3Collection.ForEach(b => Console.WriteLine($"{b.Title} ({b.PublishYear})...{b.PageCount}"));
            Console.WriteLine();

            Console.ReadKey();
        }

        public static void AddBook(Book book)
        {
            try
            {
                _bookCollection.Add(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddBookV2(Book book)
        {
            try
            {
                _bookV2Collection.Add(new BookV2 { Title = book.Title, Author = book.Author, PageCount = book.PageCount, PublishYear = book.PublishYear });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddBookV3(Book book)
        {
            try
            {
                _bookV3Collection.Add(new BookV3 { Title = book.Title, Author = book.Author, PageCount = book.PageCount, PublishYear = (PublishYear)book.PublishYear });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
