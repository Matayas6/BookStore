using BooksAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BookStore.Pages.BookPages
{
    public class AddBooksModel : PageModel
    {

        [BindProperty]
        public Book AddBook { get; set; }
        public object Author { get; private set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            return RedirectToPage("/Index", new {AddBook.Author});
        }
    }
}
