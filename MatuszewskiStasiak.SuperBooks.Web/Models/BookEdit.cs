using MatuszewskiStasiak.SuperBooks.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MatuszewskiStasiak.SuperBooks.Web.Models
{
    public class BookEdit
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid Publisher { get; set; }
        public int YearPublished { get; set; }
        public BookType Type { get; set; }
        public List<SelectListItem> Publishers { get; set; } = new List<SelectListItem>();
    }
}
