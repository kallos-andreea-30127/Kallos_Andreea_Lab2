using System.Security.Policy;
using Publisher = Kallos_Andreea_Lab2.Models.Publisher;

namespace Kallos_Andreea_Lab2.Models
{
    public class PublishedBook
    {
        public int PublisherID { get; set; }
        public int BookID { get; set; }
        public Publisher Publisher { get; set; }
        public Book Book { get; set; }
    }
}
