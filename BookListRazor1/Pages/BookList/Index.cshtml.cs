using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor1.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db; //Injecting the DbContext db from the dependency container, put it in _db.
        }

        public IEnumerable<Book> Books { get; set; }
        
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }

         public async Task<IActionResult> OnPostDelete(int id)
        {
            var BookFromDB = await _db.Book.FindAsync(id);

            if (BookFromDB == null)
            {
                return NotFound();
            }

            _db.Book.Remove(BookFromDB);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
