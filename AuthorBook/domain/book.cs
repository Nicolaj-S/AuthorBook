using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.domain
{
    public class book : super
    {
        [Required]
        [StringLength(32, ErrorMessage = "Title length can't be more than 32 chararcters")]
        public string title { get; set; }
        [Required]
        public int pages { get; set; }
        public DateTime published { get; set; }
        [ForeignKey("Author.Id")]
        public int authorid { get; set;}
    }
}
