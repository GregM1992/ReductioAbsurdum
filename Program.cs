﻿
List<ProductType> productTypes = new()
{
    new ProductType()
    {
        Id = 1,
        Name = "Apparel"
    },
    new ProductType()
    {
        Id = 2,
        Name = "Potions"
    },
    new ProductType()
    {
        Id = 3,
        Name = "Enchanted Objects"
    },
    new ProductType()
    {
        Id = 4,
        Name = "Wands"
    }
};

List<Product> products = new()
{
    new Product()
    {
        Id = 1,
        Name = "Wand of Lightning",
        Price = 75.00m,
        InStock = true,
        PublicTypeId = 4,
        DateStocked = new DateTime(2023, 1, 10)
    },
    new Product()
    {
        Id = 2,
        Name = "Cloak of Slyness",
        Price = 150.00m,
        InStock = true,
        PublicTypeId = 1,
        DateStocked = new DateTime(2022, 7, 12)
    },
    new Product()
    {
        Id = 3,
        Name = "Feather of Forgiveness",
        Price = 500.00m,
        InStock = true,
        PublicTypeId = 3,
        DateStocked = new DateTime(2023, 3, 21)
    },
    new Product()
    {
        Id = 4,
        Name = "Ring of Small Fingers",
        Price = 100.00m,
        InStock = true,
        PublicTypeId =1,
        DateStocked = new DateTime(2020, 8, 13)
    },
    new Product()
    {
        Id = 5,
        Name = "Potion of Distress",
        Price = 300.00m,
        InStock = false,
        PublicTypeId = 2,
        DateStocked = new DateTime(2021, 9, 22)
    },
    new Product()
    {
        Id = 6,
        Name = "Potion of Speed",
        Price = 220.00m,
        InStock = true,
        PublicTypeId = 2,
        DateStocked = new DateTime(2000, 1, 1)
    },
    new Product()
    {
        Id = 7,
        Name = "Wand of FIreball",
        Price = 110.00m,
        InStock = true,
        PublicTypeId = 4,
        DateStocked = new DateTime(2017, 4, 28)
    },
    new Product()
    {
        Id = 8,
        Name = "Tauks of Treach",
        Price = 500.00m,
        InStock = false,
        PublicTypeId = 1,
        DateStocked = new DateTime(2014, 6, 25)
    },
    new Product()
    {
        Id = 9,
        Name = "Effervescent Tablet",
        Price = 65.00m,
        InStock = true,
        PublicTypeId = 1,
        DateStocked = new DateTime(1992, 9, 22)
    }

};

void ListProducts()
{
    decimal totalValue = 0.0m;
    foreach (Product product in products)
    {
        if (product.InStock)
        {
            totalValue += product.Price;
        }
    }

    Console.WriteLine("\t\t Products:\n");

    foreach (Product product in products)
    {
        Console.WriteLine($"\t{product.Id}. {product.Name}   Price: ${product.Price}   In Stock: {product.InStock}   Type ID: {product.PublicTypeId}   DaysOnShelf: {product.DaysOnShelf}\n");
    }
    Console.WriteLine($"\n\t~Total Inventory Value: ${totalValue}~\n");
    Console.Write("Press Enter to continue...");
    Console.ReadLine();
}

void AddProduct()
{
    Console.Write("\n\tEnter the name of the product: ");
    string name = Console.ReadLine();

    Console.Write("\n\tEnter the product's price: ");
    decimal price = Convert.ToDecimal(Console.ReadLine());

    Console.Write("\n\tIs the product in stock? (true/false)");
    bool inStock = Convert.ToBoolean(Console.ReadLine().ToLower().Trim());

    Console.WriteLine("\n\tProduct Types\n");
    foreach (var productType in productTypes)
    {
        Console.WriteLine($"\n\t{productType.Id}. {productType.Name}");
    }

    Console.Write("\n\tEnter product type number\n");
    int productTypeId = Convert.ToInt32(Console.ReadLine());

    Product newProduct = new()
    {
        Id = products.Count + 1,
        Name = name,
        Price = price,
        InStock = inStock,
        PublicTypeId = productTypeId
    };

    products.Add(newProduct);
    Console.WriteLine("\n\tProduct Addition Successful!\n");
}

void UpdateProduct()
{
    foreach (Product product in products)
    {
        Console.WriteLine($"\n\t{product.Id}. {product.Name}");
    }
    Console.Write("\n\tEnter ID # of the product you wish to update: ");
    int productId = Convert.ToInt32(Console.ReadLine());

    Product productBeingUpdated = products.Find(p => p.Id == productId);

    if (productBeingUpdated != null)
    {
        Console.Write("\n\tEnter a new product name, or press Enter to keep current name: ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName))
        {
            productBeingUpdated.Name = newName;
        }

        Console.Write("\n\tEnter new price for product, or press Enter to keep current price: ");
        string newPrice = Console.ReadLine();
        if (!string.IsNullOrEmpty(newPrice))
        {
            productBeingUpdated.Price = Convert.ToDecimal(newPrice);
        }

        Console.Write("\n\tIs the product still availaible? (true/false): ");
        string newAvailability = Console.ReadLine();
        if (!string.IsNullOrEmpty(newAvailability))
        {
            productBeingUpdated.InStock = Convert.ToBoolean(newAvailability.ToLower().Trim());
        }

        foreach (ProductType productType in productTypes)
        {
            Console.WriteLine($"\n\t{productType.Id}. {productType.Name}");
        }
        Console.Write("\n\tChoose a product type ID#: ");
        int newId = Convert.ToInt32(Console.ReadLine());
        if (newId != null)
        {
            productBeingUpdated.PublicTypeId = newId;
        }

        Console.WriteLine("\n\tProduct update successful!\n");

    }
    else
    {
        Console.WriteLine("\n\tProduct not found!\n");
    }
}

void DeleteProduct()
{
    foreach (Product product in products)
    {
        Console.WriteLine($"\n\t{product.Id}. {product.Name}");
    }

    Console.Write("\n\tEnter ID # of the product you wish to delete: ");
    int productId = Convert.ToInt32(Console.ReadLine());

    Product productBeingDeleted = products.Find(p => p.Id == productId);
    if (productBeingDeleted != null)
    {
        products.Remove(productBeingDeleted);
        Console.WriteLine("\n\tProduct deletion successful!\n");
    }
    else
    {
        Console.WriteLine("\n\tProduct not found!\n");
    }
}

string GetProductTypeName(int publicTypeId, List<ProductType> productTypes)
{
    ProductType productType = productTypes.Find(pt => pt.Id == publicTypeId);
    return productType != null ? productType.Name : "Unknown";
}

void ViewByType()
{
    Console.WriteLine("\n\t\t~View Products by Type~\n");
    Console.WriteLine("\tProduct Types:\n");

    foreach (ProductType productType in productTypes)
    {
        Console.WriteLine($"\t{productType.Id}. {productType.Name}\n");
    }

    Console.Write("\n\tEnter product type ID# to view products: ");
    int productId = Convert.ToInt32(Console.ReadLine());

    var filteredProducts = products.Where(p => p.PublicTypeId == productId);

    if (filteredProducts.Any())
    {
        Console.WriteLine($"\n\t\t~~ {GetProductTypeName(productId, productTypes)} Products ~~\n");

        foreach (Product product in filteredProducts)
        {
            Console.WriteLine($"\tID: {product.Id}, Name: {product.Name}, Price: ${product.Price}, In Stock: {product.InStock}\n");
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("\n\tNo products found for selected product type.");
    }
}

void InStockProducts()
{
    List<Product> inStockProducts = products.Where(p => p.InStock).ToList();

    Console.WriteLine("\n\t\t~~ In Stock Products ~~\n");

    for (int i = 0; i < inStockProducts.Count; i++)
    {
        Console.WriteLine($"\n\t{inStockProducts[i].Id}   {inStockProducts[i].Name}   Price: ${inStockProducts[i].Price}   In Stock: {products[i].InStock}   Type ID: {products[i].PublicTypeId}   DaysOnShelf: {products[i].DaysOnShelf}\n");
    }
}

string greeting = "\t\t~~~ R & A Magical Supplies Inventory~~~\n\n";
string choice = null;


Console.WriteLine(greeting);


while (choice != "0")
{
    Console.WriteLine(@"                   Choose An Option:

    0. Exit

    1. View All Products

    2. Add A Product

    3. Update A Product

    4. Delete A Product

    5. View Products by Type

    6. View All In-Stock Products
");
    Console.Write("\t\t Enter Your Selection: ");

    choice = Console.ReadLine();

    switch (choice)
    {
        case "0":
            Environment.Exit(0);
            break;

        case "1":
            ListProducts();
            break;

        case "2":
            AddProduct();
            break;

        case "3":
            UpdateProduct();
            break;

        case "4":
            DeleteProduct();
            break;

        case "5":
            ViewByType();
            break;

        case "6":
            InStockProducts();
            break;

    }

}