using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor1.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book EditBook { get; set; }

        public async Task OnGet(int id)
        {
            EditBook = await _db.Book.FindAsync(id);
        }       
        
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(EditBook.Id);

                //Update
                BookFromDb.Name = EditBook.Name;
                BookFromDb.Author = EditBook.Author;
                BookFromDb.ISBN = EditBook.ISBN;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            } else
            {
                return RedirectToPage();
            }
        }
    }
}
