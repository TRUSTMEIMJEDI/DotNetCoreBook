using DotNetWebApiBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetWebApiBook.Repository
{
    public class BookRepository : IBookRepository<Book>
    {
        public Task Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Book book, Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
