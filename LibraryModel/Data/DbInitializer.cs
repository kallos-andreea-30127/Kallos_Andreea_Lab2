﻿using LibraryModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Policy;
using Publisher = LibraryModel.Models.Publisher;

namespace LibraryModel.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if (context.Books.Any())
                {
                    return; // BD a fost creata anterior
                }

                var orders = new Order[]
                 {
                     new Order{BookID=9,CustomerID=2,OrderDate=DateTime.Parse("2021-02-25")},
                     new Order{BookID=2,CustomerID=1,OrderDate=DateTime.Parse("2021-09-28")},
                     new Order{BookID=8,CustomerID=1,OrderDate=DateTime.Parse("2021-10-28")},
                     new Order{BookID=3,CustomerID=2,OrderDate=DateTime.Parse("2021-09-28")},
                     new Order{BookID=9,CustomerID=2,OrderDate=DateTime.Parse("2021-09-28")},
                     new Order{BookID=10,CustomerID=2,OrderDate=DateTime.Parse("2021-10-28")},
                 };
                foreach (Order e in orders)
                {
                    context.Orders.Add(e);
                }
                context.SaveChanges();

                var publishers = new Publisher[]
                {
                     new Publisher{PublisherName="Humanitas",Adress="Str. Aviatorilor, nr. 40, Bucuresti"},
                     new Publisher{PublisherName="Nemira",Adress="Str. Plopilor, nr. 35, Ploiesti"},
                     new Publisher{PublisherName="Paralela45",Adress="Str. Cascadelor, nr.22, Cluj-Napoca"},
                };

                foreach (Publisher p in publishers)
                {
                    context.Publishers.Add(p);
                }
                context.SaveChanges();

                var books = context.Books;

                var publishedbooks = new PublishedBook[]
                {
                    new PublishedBook {
                    BookID = books.Single(c => c.Title == "Maytrei").ID, PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
                },
                new PublishedBook
                {
                    BookID = books.Single(c => c.Title == "Enigma Otiliei").ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
                },
                new PublishedBook
                {
                    BookID = books.Single(c => c.Title == "Baltagul").ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Nemira").ID
                },
                new PublishedBook
                {
                    BookID = books.Single(c => c.Title == "Fata de hartie").ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Paralela45").ID
                },
                new PublishedBook
                {
                    BookID = books.Single(c => c.Title == "Panza de paianjen").ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Paralela45").ID
                },
                new PublishedBook
                {
                    BookID = books.Single(c => c.Title == "De veghe in lanul desecara").ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Paralela45").ID
                },
                };
            
                foreach (PublishedBook pb in publishedbooks)
                {
                    context.PublishedBooks.Add(pb);
                }
                context.SaveChanges();
            }
        }
    }
}