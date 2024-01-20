using MatuszewskiStasiak.SuperBooks.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MatuszewskiStasiak.SuperBooks.Web.Models
{
    public class BookDetails
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int YearPublished { get; set; }
        public BookType Type { get; set; }
    }
}
