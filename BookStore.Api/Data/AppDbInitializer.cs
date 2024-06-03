using BookStore.Api.Models;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

namespace BookStore.Api.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                //Authors
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(

                    new Author
                    {
                        FirstName = "William",
                        LastName = "Shakespeare",
                        Bio = "William Shakespeare was an English playwright and poet who wrote plays and poetry, such as Romeo and Juliet, Macbeth, and Hamlet"
                    },
                    new Author
                    {
                        FirstName = "Agatha",
                        LastName = "Christie",
                        Bio = "Agatha Christie was an English writer known for her whodunits, including the Miss Marple and Hercule Poirot series"
                    },
                    new Author
                    {
                        FirstName = "Barbara",
                        LastName = "Cartland",
                        Bio = "Barbara Cartland was an English author known for her romance novels"
                    },
                    new Author
                    {
                        FirstName = "Danielle",
                        LastName = "Steel",
                        Bio = "Danielle Steel is an American author known for her general fiction and romance novels"
                    },
                    new Author
                    {
                        FirstName = "Harold",
                        LastName = "Robbins",
                        Bio = "Harold Robbins was an American author known for his adventure novels"
                    });
                    context.SaveChanges();
                }
                //Books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(

                    new Book
                    {
                        Title = "Romeo and Juliet",
                        Year = 1957,
                        Isbn = "9780174434719",
                        Summary = "Romeo and Juliet is a tragedy written by William Shakespeare. The play follows the story of two young lovers from feuding families who fall in love and ultimately meet a tragic end.",
                        Image = null,
                        Price = Convert.ToDecimal(4.80)
                    },
                    new Book
                    {
                        Title = "Hamlet",
                        Year = 1980,
                        Isbn = "0140707344",
                        Summary = "Hamlet is, arguably, Shakespeare's most well-known play, with its compelling lead character, stunning language, and philosophical underpinnings. This drama of the procrastinating Danish prince who ponders whether or not to revenge his father's death",
                        Image = null,
                        Price = Convert.ToDecimal(8.00)
                    },
                    new Book
                    {
                        Title = "Macbeth",
                        Year = 1981,
                        Isbn = "9780140620795",
                        Summary = "Promised a golden future as ruler of Scotland by three sinister witches, Macbeth murders the king to ensure his ambitions come true. But he soon learns the meaning of terror - killing once, he must kill again and again",
                        Image = null,
                        Price = Convert.ToDecimal(7.85)
                    },
                    new Book
                    {
                        Title = "And Then There Were None",
                        Year = 2015,
                        Isbn = "9780008123208",
                        Summary = "The 10 strangers include a reckless playboy, a troubled Harley Street doctor, a formidable judge, an uncouth detective, an unscrupulous mercenary, a God-fearing spinster, two restless servants, a highly decorated general and an anxious secretary.",
                        Image = null,
                        Price = Convert.ToDecimal(11.18)
                    },
                    new Book
                    {
                        Title = "A Hazard of Hearts",
                        Year = 2018,
                        Isbn = "9781788670470",
                        Summary = "After her mother died when Serena Staverley was just nine, her father, Sir Giles, indulged his deep passion for gambling, leaving his only child in charge of an impoverished household.",
                        Image = null,
                        Price = Convert.ToDecimal(13.21)
                    },
                    new Book
                    {
                        Title = "Sweet Enchantress",
                        Year = 1958,
                        Isbn = "1618403038SLE",
                        Summary = "Bewitching Countess Dominique de Bar has devoted her life to making her lands a place of peace and harmony, and now her efforts are threatened by a stranger disguised in beggar's garb.",
                        Image = null,
                        Price = Convert.ToDecimal(5.80)
                    },
                    new Book
                    {
                        Title = "The Blue Eyed Witch",
                        Year = 2013,
                        Isbn = "178213204X",
                        Summary = "Bored with the Social world of London and the constant demands of the lovelorn Prince of Wales, the Marquis of Aldridge takes refuge at his remote country estate, Ridge Castle, deep in the 'Witch Country' of Essex.",
                        Image = null,
                        Price = Convert.ToDecimal(12.01)
                    },
                    new Book
                    {
                        Title = "Pure and Untouched",
                        Year = 1999,
                        Isbn = "9780750514200",
                        Summary = "“Pure and Untouched” is a romance novel written by Barbara Cartland. The book follows the story of the Duke of Ravenstock",
                        Image = null,
                        Price = Convert.ToDecimal(8.00)
                    },
                    new Book
                    {
                        Title = "The Mysterious Maid-Servant",
                        Year = 1977,
                        Isbn = "0553103423",
                        Summary = "the story of Giselda, a young woman who finds herself in a desperate situation with no money for an operation her younger brother needs to save his life",
                        Image = null,
                        Price = Convert.ToDecimal(2.55)
                    },
                    new Book
                    {
                        Title = "Safe Harbour",
                        Year = 2003,
                        Isbn = "0593066006",
                        Summary = "The book follows the story of Ophelie and her 11-year-old daughter Pip, who are both grieving after the loss of Ophelie’s husband and son. ",
                        Image = null,
                        Price = Convert.ToDecimal(14.50)
                    },
                    new Book
                    {
                        Title = "All That Glitters",
                        Year = 2021,
                        Isbn = "9781509878291",
                        Summary = "is the story of a young woman finding her place in the world and learning the hardest lesson of all - who to trust. Coco Martin, the adored only child of wealthy parents, has lived a charmed existence",
                        Image = null,
                        Price = Convert.ToDecimal(2.51)
                    },
                    new Book
                    {
                        Title = "Finding Ashley",
                        Year = 2022,
                        Isbn = "9781529021608",
                        Summary = "The novel encompasses themes of long-held secrets, faith, love and reconnection",
                        Image = null,
                        Price = Convert.ToDecimal(8.90)
                    },
                    new Book
                    {
                        Title = "His Bright Light",
                        Year = 1998,
                        Isbn = "9780385333467",
                        Summary = "This is the story of an extraordinary boy with a brilliant mind, a heart of gold, and a tortured soul. It is the story of an illness, a fight to live, and a race against death.",
                        Image = null,
                        Price = Convert.ToDecimal(12.02)
                    },
                    new Book
                    {
                        Title = "The Carpetbaggers",
                        Year = 1961,
                        Isbn = "9780340952849",
                        Summary = "The theme it is around that only by the most Herculean efforts can an individual overcome the circumstances of his upbringing and lift the dead weight of the past from his shoulders",
                        Image = null,
                        Price = Convert.ToDecimal(14.06)
                    },
                    new Book
                    {
                        Title = "Never Love a Stranger",
                        Year = 1948,
                        Isbn = "9780450000768",
                        Summary = "the gritty and passionate tale of Francis “Frankie” Kane, from his meager beginnings as an orphan in New York’s Hell’s Kitchen",
                        Image = null,
                        Price = Convert.ToDecimal(12.45)
                    },
                    new Book
                    {
                        Title = "Where Love Has Gone",
                        Year = 1962,
                        Isbn = "9780450000454",
                        Summary = "The novel is inspired by the real-life murder of Johnny Stompanato, Lana Turner's lover, who was allegedly stabbed by the actress' daughter",
                        Image = null,
                        Price = Convert.ToDecimal(8.62)
                    },
                    new Book
                    {
                        Title = "The Adventurers",
                        Year = 1966,
                        Isbn = "0450000834",
                        Summary = "The novel is a story of revolution and danger in the sultry jungles of South America",
                        Image = null,
                        Price = Convert.ToDecimal(9.85)
                    },
                    new Book
                    {
                        Title = "The Betsy",
                        Year = 1971,
                        Isbn = "0450038084",
                        Summary = "The novel explores the shocking world of the automobile industry - of savage ambition, searing passion, and breathtaking fortunes won or lost in a desperate struggle for power",
                        Image = null,
                        Price = Convert.ToDecimal(16.92)
                    }
                    );
                    context.SaveChanges();
                }
                //AuthorBooks
                if (!context.AuthorBooks.Any())
                {
                    context.AuthorBooks.AddRange(
                        new AuthorBook
                        {
                            AuthorId = 1,
                            BookId = 1
                        },
                        new AuthorBook
                        {
                            AuthorId = 1,
                            BookId = 2
                        },
                        new AuthorBook
                        {
                            AuthorId = 1,
                            BookId = 3
                        },
                        new AuthorBook
                        {
                            AuthorId = 2,
                            BookId = 4
                        },
                        new AuthorBook
                        {
                            AuthorId = 3,
                            BookId = 5
                        },
                        new AuthorBook
                        {
                            AuthorId = 3,
                            BookId = 6
                        },
                        new AuthorBook
                        {
                            AuthorId = 3,
                            BookId = 7
                        },
                        new AuthorBook
                        {
                            AuthorId = 3,
                            BookId = 8
                        },
                        new AuthorBook
                        {
                            AuthorId = 3,
                            BookId = 9
                        },
                        new AuthorBook
                        {
                            AuthorId = 4,
                            BookId = 10
                        },
                        new AuthorBook
                        {
                            AuthorId = 4,
                            BookId = 11
                        },
                        new AuthorBook
                        {
                            AuthorId = 4,
                            BookId = 12
                        },
                        new AuthorBook
                        {
                            AuthorId = 4,
                            BookId = 13
                        },
                        new AuthorBook
                        {
                            AuthorId = 5,
                            BookId = 14
                        },
                        new AuthorBook
                        {
                            AuthorId = 5,
                            BookId = 15
                        },
                        new AuthorBook
                        {
                            AuthorId = 5,
                            BookId = 16
                        },
                        new AuthorBook
                        {
                            AuthorId = 5,
                            BookId = 17
                        },
                        new AuthorBook
                        {
                            AuthorId = 5,
                            BookId = 18
                        }
                    );
                    context.SaveChanges();
                }
                //Publisher
                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(
                        new Publisher
                        {
                            Name = "Penguin Random House"
                        },
                        new Publisher
                        {
                            Name = "Harper Collins"
                        },
                        new Publisher
                        {
                            Name = "Simon & Schuster"
                        },
                        new Publisher
                        {
                            Name = "Hachette Livre"
                        },
                        new Publisher
                        {
                            Name = "Macmillan Publishers"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
