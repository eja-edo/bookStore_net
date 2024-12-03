using BookStore.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.ModelViews
{
    public class BookViewModel
    {
        public string? ISBN { get; set; }
        public int? PublishingYear { get; set; }
        public string? Publisher { get; set; }
        public int? PageCount { get; set; }
        public List<BookAuthor> Authors { get; set; }
    }

}
