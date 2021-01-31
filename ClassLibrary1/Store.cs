using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public class Store
    {
        public string Title { get; set; }
        public IEnumerable<SectionId> MainOptions { get; set; } = new List<SectionId>
        {
            SectionId.Produce,
            SectionId.Deli,
            SectionId.Frozen,
            SectionId.Bakery, 
            SectionId.Miscellaneous
        };
    }

    public enum SectionId
    {
        Produce = 1, 
        Deli = 2, 
        Frozen = 3, 
        Bakery = 4, 
        Miscellaneous = 5
    }

    public class Product
    {
        public char Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"{Id}. {Name}: {Price}";
        }
        public override bool Equals(Object obj)
        {
            var product = (Product)obj;
            return product.Id == Id && product.Name == Name && product.Price == Price;
        }

        public static Product operator +(Product a, Product b)
        => new Product { Name = $"{a.Name} squashed together with {b.Name}", Price = a.Price + b.Price };
    }

    public class BakerySection : StoreSection
    {
        public BakerySection()
        {
            Products = new List<Product>
            {
                new Product { Id = 'A', Name = "Rye Bread", Price = 3},
                new Product { Id = 'B', Name = "Loaf of Sourdough Bread", Price=15},
            };
        }
    }

    public class FrozenSection : StoreSection
    {
        public FrozenSection()
        {
            Products = new List<Product>
            {
                new Product { Id = 'A', Name = "Frozen Pizza"},
                new Product { Id = 'B', Name = "Ice Cream"},
            };
        }
    }
    public class ProduceSection : StoreSection
    {
        public ProduceSection()
        {
            Products = new List<Product>
            {
                new Product { Id = 'A', Name = "Broccoli"},
                new Product { Id = 'B', Name = "Apple"},
            };
        }
    }
    public class MiscellaneousSection : StoreSection
    {
        public MiscellaneousSection()
        {
            Products = new List<Product>
            {
                new Product { Id = 'A', Name = "Toy at checkout"},
                new Product { Id = 'B', Name = "Greeting Cards"},
            };
        }
    }
    public class DeliSection : StoreSection
    {
        public DeliSection()
        {
            Products = new List<Product>
            {
                new Product { Id = 'A', Name = "Ham"},
                new Product { Id = 'B', Name = "Turkey"},

            };
        }
    }

    public class StoreSection
    {
        public SectionId Section { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public IEnumerable<StoreSection> SubSections { get; set; } = new List<StoreSection>();
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        public StoreSection()
        {

        }

        public StoreSection(IEnumerable<Product> products)
        {
            Products = products;
        }

        public StoreSection(IEnumerable<StoreSection> subSections)
        {
            SubSections = subSections;
        }
        public StoreSection(IEnumerable<Product> products, IEnumerable<StoreSection> subSections)
        {
            Products = products;
            SubSections = subSections;
        }

        public void ShowMenu()
        {
            var isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to the best store ever!");
                foreach (var section in SubSections)
                {
                    Console.WriteLine($"{section.Section.ToString("d")}. {section.Title}");
                }
                foreach (var product in Products)
                {
                    Console.WriteLine($"{product.Id}. {product.Name}");
                }
                Console.WriteLine("0. Exit");

                var userInput = Console.ReadLine();
                int intUserInput;
                var isSuccessful = int.TryParse(userInput, out intUserInput);
                if (!isSuccessful)
                {
                    Console.WriteLine($"Please enter a number between 1 and {SubSections.Count()}");
                }
                else
                {
                    if (intUserInput == 0)
                    {
                        isRunning = false;
                    }
                }
                var enumUserInput = (SectionId)intUserInput;
                Console.WriteLine($"You chose {userInput}: {enumUserInput}");
                var subsection = SubSections.FirstOrDefault(s => s.Section == enumUserInput);
                subsection.ShowMenu();
            }
        }
    }
}
