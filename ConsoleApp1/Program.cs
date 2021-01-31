using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var storeSections = BuildOpeningSections();
            //var openingSection = new StoreSection(storeSections);

            var a = new Product { Id = 'A', Name = "Rye Bread", Price = 3 };
            var b = new Product { Id = 'B', Name = "Sourdough Bread", Price = 4 };

            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Console.WriteLine(a.Equals(b));
            var products = a + b;
            Console.WriteLine(products);

            var animals = new List<Animal>
            {
                new Mouse(),
                new Alligator()
            };

            foreach (var animal in animals)
            {
                animal.Walk();
            }

            //openingSection.ShowMenu();
        }


        private static IEnumerable<StoreSection> BuildOpeningSections()
        {
            var sectionList = new List<StoreSection>();
            sectionList.Add(new MiscellaneousSection { Section = SectionId.Miscellaneous, Title = "Miscellaneous", Description = "Random trinkets across store" });
            sectionList.Add(new BakerySection { Section = SectionId.Bakery, Title = "Bakery", Description = "Fresh bread" });
            sectionList.Add(new ProduceSection { Section = SectionId.Produce, Title="Produce", Description="Fresh fruits, vegetables, etc." });
            sectionList.Add(new FrozenSection { Section = SectionId.Frozen, Title = "Frozen", Description = "Frozen stuff goes here. " });
            sectionList.Add(new DeliSection { Section = SectionId.Deli, Title = "Deli", Description = "Fresh meat. " });
            return sectionList
                .OrderBy(sec => sec.Section);
        }
    }
}
