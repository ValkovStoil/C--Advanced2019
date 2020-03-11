using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            /*lidl, juice, 2.30
            fantastico, apple, 1.20
            kaufland, banana, 1.10
            fantastico, grape, 2.20
            Revision
            */

            var shops = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var productsInShop = new SortedDictionary<string, List<products>>();

            while (shops[0] != "Revision")
            {
                var shopName = shops[0];
                var product = shops[1];
                var price = double.Parse(shops[2]);

                var productAndPrice = new products(product, price);

                if (!productsInShop.ContainsKey(shopName))
                {
                    productsInShop[shopName]= new List<products>();
                }
                productsInShop[shopName].Add(productAndPrice);

                shops = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var keyValuePair in productsInShop)
            {
                Console.WriteLine($"{keyValuePair.Key}->");

                foreach (var product in keyValuePair.Value)
                {
                    Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
                }
            }
        }
    }

    class products
    {
        public string Name { get; set; }
        public  double Price { get; set; }

        public products()
        {

        }
        public products(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
