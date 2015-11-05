using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearch;
using BookClasses;

namespace BinarySearchConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchCollection<int> c = new BinarySearchCollection<int>();
            BinarySearchCollection<Book> bookBinarySearch = new BinarySearchCollection<Book>();
            Random random = new Random(2);
            for (int i = 0; i<1000; i++)
            {
                c.Add(random.Next(1000));
                Book book = new Book();
                book.Author = random.Next().ToString();
                book.Title = random.Next().ToString();
                book.EditionNumber = random.Next();
                book.YearOfPublishing = random.Next();
                book.Length = random.Next();
                bookBinarySearch.Add(book);
            }

        }
    }
}
