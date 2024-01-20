using MatuszewskiStasiak.SuperBooks.Interfaces;

namespace MatuszewskiStasiak.SuperBooks.Web.Models
{
    public class PublisherEdit
    {
        public Guid ID { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public int YearCreated { get; set; }
    }
}
