using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.domain
{
    public class author : super
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public List<book> books { get; set; }

    }
}
