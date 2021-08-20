
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BookStore.Pages.BookPages
{
    public class AddBooksModel : PageModel
    {

        [BindProperty]
        public Book AddBook { get; set; }
        public object Author { get; set; }
        public object Title { get; set; }
        public object Description { get; set; }
        public object Category { get; set; }


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
