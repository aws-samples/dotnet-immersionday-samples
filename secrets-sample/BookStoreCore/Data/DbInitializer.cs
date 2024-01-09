using BookStoreCore.Models;

namespace BookStoreCore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if(context.Books.Any())
            {
                return;  //DB has been Seeded
            }

            var categories = new Category[]
            {
                new Category{CategoryName="Fantasty"},
                new Category{CategoryName="Children"},
                new Category{CategoryName="Poems"}
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var publishers = new Publisher[]
{
                new Publisher{PublisherName="HarperCollins"},
                new Publisher{PublisherName="Scholastic"},
};

            context.Publishers.AddRange(publishers);
            context.SaveChanges();


            var books = new Book[]
            {
                new Book{Title="The Giving Tree", Author="Shell Silverstein", CategoryId=2, PublisherId=1 },
                new Book{Title="Where the Sidewalk Ends",Author="Shell Silverstein", CategoryId=3, PublisherId=1},
                new Book{Title="A Light in the Attic",Author="Shell Silverstein", CategoryId=3, PublisherId=1},
                new Book{Title="Harry Potter and the Socerers Stone", Author="JK Rowling", CategoryId=1, PublisherId=2},
                new Book{Title="Harry Potter and the Chamber of Secrets", Author="JK Rowling", CategoryId=1, PublisherId=2},
                new Book{Title="Harry Potter and the Prisoner of Azkaban", Author="JK Rowling", CategoryId=1, PublisherId=2},
                new Book{Title="Harry Potter and the Goblet of Fire", Author="JK Rowling", CategoryId=1, PublisherId=2},
                new Book{Title="Harry Potter and the Order of the Phoenix", Author="JK Rowling", CategoryId=1, PublisherId=2},
                new Book{Title="Harry Potter and the Half Blood Prince", Author="JK Rowling", CategoryId = 1, PublisherId=2},
                new Book{Title="Harry Potter and the Deathly Hallows", Author="JK Rowling", CategoryId = 1, PublisherId=2}
            };

            context.Books.AddRange(books);
            context.SaveChanges();


        }
    }
}
