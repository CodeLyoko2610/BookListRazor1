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

        public Book NewBook { get; set; }

        public void OnGet()
        {
            //NewBook obj automatically added to the Getter
        }
    }
}
