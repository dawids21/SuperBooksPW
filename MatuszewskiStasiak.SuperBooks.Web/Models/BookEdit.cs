using MatuszewskiStasiak.SuperBooks.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MatuszewskiStasiak.SuperBooks.Web.Models
{
    public class BookEdit
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid Publisher { get; set; }
        [Display(Name = "Year published")]
        [Range(0, 2024)]
        public int YearPublished { get; set; }
        public BookType Type { get; set; }
        public List<SelectListItem> Publishers { get; set; } = new List<SelectListItem>();
    }
}
