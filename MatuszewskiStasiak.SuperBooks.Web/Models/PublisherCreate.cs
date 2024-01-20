using MatuszewskiStasiak.SuperBooks.Interfaces;

namespace MatuszewskiStasiak.SuperBooks.Web.Models
{
    public class PublisherCreate
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public int YearCreated { get; set; }
    }
}
