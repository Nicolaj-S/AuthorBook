using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorBook.domain
{
    public class book : super
    {
        [Required]
        [StringLength(32, ErrorMessage = "Title length can't be more than 32 chararcters")]
        public string Title { get; set; }
        [Required]
        public int Pages { get; set; }
        public DateTime Published { get; set; }
        [ForeignKey("Author.Id")]
        public int Authorid { get; set; }
    }
}
