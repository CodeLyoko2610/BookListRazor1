using BookListRazor1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor1.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        //constructor
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Book.ToList() });
        }
    }
}
