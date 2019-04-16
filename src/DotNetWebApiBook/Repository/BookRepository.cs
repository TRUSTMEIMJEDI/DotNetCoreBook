using DotNetWebApiBook.DbContexts;
using DotNetWebApiBook.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetWebApiBook.Repository
{
    public class BookRepository : IBookRepository<Book>
    {
        private readonly BookContext dbcontext;

        public BookRepository(BookContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await dbcontext.Books.ToListAsync();
        }

        public async Task<Book> Get(long id)
        {
            return await dbcontext.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task Add(Book entity)
        {
            await dbcontext.Books.AddAsync(entity);
            await dbcontext.SaveChangesAsync();
        }

        public async Task Delete(Book book)
        {
            dbcontext.Books.Remove(book);
            await dbcontext.SaveChangesAsync();
        }

        public async Task Update(Book book, Book entity)
        {
            book.Title = entity.Title;
            book.Author = entity.Author;
            book.ISBN = entity.ISBN;
            book.Year = entity.Year;

            await dbcontext.SaveChangesAsync();
        }

        //public Task Add(Book entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Delete(Book book)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Book> Get(long id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Book>> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Update(Book book, Book entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
