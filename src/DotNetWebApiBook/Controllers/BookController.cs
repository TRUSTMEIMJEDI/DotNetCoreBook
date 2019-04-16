using DotNetWebApiBook.Model;
using DotNetWebApiBook.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetWebApiBook.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository<Book> bookRepository;

        public BookController(IBookRepository<Book> bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var book = await this.bookRepository.GetAll();

            return Ok(book);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            var book = await this.bookRepository.Get(id);

            if(book == null)
            {
                return NotFound("The book could not be found!");
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            if (book == null)
            {
                return BadRequest("Book is null");
            }

            await this.bookRepository.Add(book);

            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Book book)
        {
            var bookToUpdate = await this.bookRepository.Get(id);

            if (bookToUpdate == null)
            {
                return NotFound("The book could not be found!");
            }

            await this.bookRepository.Update(bookToUpdate, book);

            return NoContent();
        }

        public async Task<IActionResult> Delete(long id, Book book)
        {
            var bookToDelete = await this.bookRepository.Get(id);

            if (bookToDelete == null)
            {
                return NotFound("The book record could not be found!");
            }

            await this.bookRepository.Delete(bookToDelete);

            return NoContent();
        }
    }
}
