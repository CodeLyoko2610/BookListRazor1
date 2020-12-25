using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor1.Models
{
    public class Book
    {
        [Key] //primary key, created automatically
        public int Id { get; set; }
               
        [Required] //cannot be null
        public string Name { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

    }
}
