using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Model;

namespace BookStore.Pages.BookPages
{
    public class DeleteModel : PageModel
    {
        private readonly BookStore.Data.BookStoreContext _context;

        public DeleteModel(BookStore.Data.BookStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BooksModel BooksModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BooksModel = await _context.BooksModel.FirstOrDefaultAsync(m => m.Id == id);

            if (BooksModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BooksModel = await _context.BooksModel.FindAsync(id);

            if (BooksModel != null)
            {
                _context.BooksModel.Remove(BooksModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
