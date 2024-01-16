//using System.Security.Policy;
//using Publisher = LibraryModel.Models.Publisher;
//using Kallos_Andreea_Lab2.Models;

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
