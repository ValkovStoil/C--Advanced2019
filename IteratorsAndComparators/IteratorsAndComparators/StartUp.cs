using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //var library = new Library();

            //library.AddBook(new Book("1984", 1980, new List<string> { "Jorge Orwell" }));
            //library.AddBook(new Book("The Godfather", 1981, new List<string> { "Mario Puzo" }));
            //library.AddBook(new Book("The lord of the rings", 1954, new List<string> { "J. Tolkin" }));


            //foreach (var book in library)
            //{
            //    Console.WriteLine($"{string.Join(",",book.Authors)} - {book.Title} - ({book.Year})");
            //}


            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book.Title);
            }

        }
    }
}
