using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.DTO
{
    public class BookDTO
    {
        public string title { get; set; }
        public int pages { get; set; }
        public DateTime published { get; set; }
    }
}
