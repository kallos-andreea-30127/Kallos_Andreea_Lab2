using Kallos_Andreea_Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kallos_Andreea_Lab2.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if (context.Authors.Any())
                {
                    return;
                }

                context.Authors.AddRange(
                    new Author
                    {
                        FirstName = "Mihail",
                        LastName = "Sadoveanu"
                    },
                    new Author
                    {
                        FirstName = "George",
                        LastName = "Calinescu"
                    },
                    new Author
                    {
                        FirstName = "Mircea",
                        LastName = "Eliade"
                    });

              
                context.Books.AddRange(
                new Book
                {
                    Title = "Baltagul",
                    Price=Decimal.Parse("22"),
                    AuthorID=7},
               
                new Book
                {
                    Title = "Enigma Otiliei",
                    Price=Decimal.Parse("18"),
                    AuthorID=8},
               
                new Book
                {
                    Title = "Maytrei",
                    Price=Decimal.Parse("27"),
                    AuthorID=9}
               
                );

               

                context.Customers.AddRange(
                new Customer
                {
                    Name = "Popescu Marcela",
                    Adress = "Str. Plopilor, nr. 24",
                    BirthDate = DateTime.Parse("1979-09-01")
                },
                new Customer
                {
                    Name = "Mihailescu Cornel",
                    Adress = "Str. Bucuresti, nr.45, ap. 2",
                    BirthDate=DateTime.Parse("1969 - 07 - 08")}
               
                );

                context.SaveChanges();
            }
        }
    }
}
