using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor1.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //constructor
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty] //Bind the NewBook Object with submitted values to the OnPost handler
        public Book NewBook { get; set; }

        public void OnGet()
        {
            //NewBook obj automatically added to the Get handler
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(NewBook);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            } else
            {
                return Page();
            }
        }
    }
}
