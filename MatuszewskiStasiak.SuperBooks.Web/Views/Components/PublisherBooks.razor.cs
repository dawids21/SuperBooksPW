using MatuszewskiStasiak.SuperBooks.Web.Models;
using Microsoft.AspNetCore.Components;

namespace MatuszewskiStasiak.SuperBooks.Web.Views.Components
{
    public partial class PublisherBooks
    {
        [Parameter]
        public PublisherDetails Publisher { get; set; }
    }
}
