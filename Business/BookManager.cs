using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using DataAccess;

namespace Business
{
    public class BookManager
    {
        private readonly string _filePath = "books.json";
        private List<Book> _books;

        public BookManager()
        {
            _books = FileHelper<Book>.LoadFromFile(_filePath);
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public Book GetById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title) ||
                string.IsNullOrWhiteSpace(book.Author) ||
                string.IsNullOrWhiteSpace(book.ISBN))
            {
                throw new Exception("Kitap Adı, Yazar ve ISBN boş olamaz.");
            }

            if (_books.Any(b => b.ISBN == book.ISBN))
            {
                throw new Exception("Bu ISBN numarası zaten kayıtlı.");
            }

            _books.Add(book);
            Save();
        }

        public void Remove(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
                Save();
            }
        }

        public void Update(Book updatedBook)
        {
            var index = _books.FindIndex(b => b.Id == updatedBook.Id);
            if (index != -1)
            {
                _books[index] = updatedBook;
                Save();
            }
        }

        public int GetNextId()
        {
            if (_books.Count == 0)
                return 1;
            return _books.Max(b => b.Id) + 1;
        }

        private void Save()
        {
            FileHelper<Book>.SaveToFile(_books, _filePath);
        }
    }
}
