using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetWebApiBook.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebApiBook.DbContexts
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }


    }
}
