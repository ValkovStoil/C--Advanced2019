using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library: IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }

        public List<Book> Books { get; private set; }

        public void AddBook(Book book)
        {
            this.Books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryEnumerator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class LibraryEnumerator : IEnumerator<Book>
    {
        private int currentIndex = -1;

        private readonly List<Book> books;

        public LibraryEnumerator(List<Book> books)
        {
            this.books = books;
        }

        public Book Current => this.books[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            currentIndex++;
            if(this.currentIndex >= this.books.Count)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
