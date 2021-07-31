using BooksAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly Repo.IBookRepo _bookRepo;
        public BooksController(Repo.IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepo.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepo.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>>PostBooks ([FromBody] Book book)
        {
            var newBook = await _bookRepo.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook }, newBook);
        }

        [HttpPost]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            if (id != book.Id) 
            {
                return BadRequest();
            }
            await _bookRepo.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var bookToDelete = await _bookRepo.Get(id);
            if (bookToDelete == null)
                return NotFound();

            await _bookRepo.Delete(bookToDelete.Id);
            return NoContent();
        }
        
    }
}
