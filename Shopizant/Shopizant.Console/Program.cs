using Shopizant.CFA.DAL;
using Shopizant.CFA.DAL.Models;
using System;
using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
         Repository repository = new Repository();



        ////Get all Categories
        //var categories = repository.GetAllCategories();
        //foreach (var category in categories)
        //{
        //    Console.WriteLine("{0}, {1}", category.CategoryId, category.CategoryName);
        //}



        ////Fetch list of products
        //var Product = repository.ListProducts();
        //foreach (var products in Product)
        //{
        //    Console.WriteLine("ProductId\tProductName\tProductPrice\tProductQuantityAvaialble\tCategoryId");
        //    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4} ", products.ProductId, products.ProductName, products.Price, products.QuantityAvailable, products.CatrgoryId);
        //}



        ////Add products to repository 
        //bool productaddition = repository.AddProduct( "6", "Yezzy", 299, 20, 4);
        //if (productaddition != null)
        //{
        //    Console.WriteLine(productaddition);
        //}
        //else
        //{

        //    Console.WriteLine(productaddition + "Inavild Entry please try again");
        //}


        Product ftProduct = new Product();
        ftProduct.ProductId = "6";
        ftProduct.ProductName = "Yezzy";
        ftProduct.Price = 299;
        ftProduct.QuantityAvailable = 200;
        ftProduct.CatrgoryId = 4;
        bool status = repository.AddRangeOfProduct(ftProduct);
        if (status != false)
        {
            Console.WriteLine("Product Has been added to database");
        }
        else
        {
            Console.WriteLine("Invaild addition try again!");
        }



        ////Add categories  to repository 
        //bool categoryAddition = repository.AddCategory("Shoes");
        //if (categoryAddition != false)
        //{
        //    Console.WriteLine("New Addition of a category is: " + categoryAddition);
        //}
        //else
        //{

        //    Console.WriteLine(categoryAddition + "Inavild Entry please try again");
        //}

        ////Returns a List product using the categoryId passed in the parameter
        //byte categoryId = 1;
        //List<Product> listProducts = repository.GetProductsusingCategoryId(categoryId);
        //if (listProducts == null)
        //{
        //    Console.WriteLine("no products available");
        //}
        //else
        //{
        //    foreach (var product in listProducts)
        //    {
        //        Console.WriteLine("{0},{1},{2},{3},{4}", product.ProductId, product.ProductName, product.Price, product.QuantityAvailable, product.CatrgoryId);
        //    }
        //}



        //Update Products using the parameters passed to the repoistory UpdateProducts method
        //bool updateproduct = repository.UpdateProducts("1", "Iphone 14", 1500, 20);
        //if (updateproduct != null)
        //{
        //    Console.WriteLine(updateproduct);
        //}
        //else
        //{

        //    Console.WriteLine(updateproduct + "Inavild Entry please try again");
        //}

        //UpdateCategories passing a new category to the repoistory updatecategories method
        //bool UpdateCategories = repository.UpdateCategory(2, "Phones");
        //if (UpdateCategories != null)
        //{
        //    Console.WriteLine(UpdateCategories);
        //}
        //else
        //{

        //    Console.WriteLine(UpdateCategories + "Inavild Entry please try again");
        //}


        //Delete by Passing a parameter, Delete product from DbContext.Products
        //bool status = repository.DeleteProduct("5");
        //if(status!= false)
        //{
        //    Console.WriteLine("Product has been deleted");
        //}
        //else
        //{
        //    Console.WriteLine("Inavaild Entry please try again");
        //}

    }

}
