using MatuszewskiStasiak.SuperBooks.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MatuszewskiStasiak.SuperBooks.Web.Models
{
    public class PublisherDetails
    {
        public Guid ID { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        [Display(Name = "Year created")]
        public int YearCreated { get; set; }
    }
}
