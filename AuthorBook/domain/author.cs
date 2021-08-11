using System.Collections.Generic;

namespace AuthorBook.domain
{
    public class author : super
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<book> Books { get; set; }

    }
}
