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
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book BookToWork { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            BookToWork = new Book();

            //Create
            if(id == null)
            {
                return Page();
            }

            //Update
            BookToWork = await _db.Book.FirstOrDefaultAsync(item => item.Id == id);
            if(BookToWork == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //Create
                if(BookToWork.Id == 0)
                {
                    _db.Book.Add(BookToWork);
                } 
                //Update
                else
                {
                    _db.Book.Update(BookToWork);
                }

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            } 
            return RedirectToPage();
            
                
        }
    }
}
