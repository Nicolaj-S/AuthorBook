using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthorBook.domain
{
    public class author : super
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public List<book> Books { get; set; }

    }
}
