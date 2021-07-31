using BooksAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Repo
{
    public class BookRepo : IBookRepo
    {
        private readonly BookContext _context;
        public BookRepo(BookContext context)
        {
            _context = context;
        }

        public async Task<Book> Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }


        public async Task Delete(int id)
        {
            var bookToDelete = await _context.Books.FindAsync(id);
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.Books.ToListAsync();
        }


        public async Task<Book> Get(int id)
        {
            return await _context.Books.FindAsync(id);
        }


        public async Task Update(Book book)
        {
            await _context.SaveChangesAsync();
        }
    }
}
