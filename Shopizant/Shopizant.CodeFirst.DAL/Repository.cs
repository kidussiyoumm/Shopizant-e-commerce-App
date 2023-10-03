using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shopizant.CodeFirst.DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopizant.CodeFirst.DAL
{
    public class Repository
    {
        private ShopizantDBContext dbContext;

        public Repository()
        {
            dbContext = new ShopizantDBContext(); // dbcontext opens a connection with all the data in the database
        }

        /// <summary>
        /// CRUD operation for API 
        /// User Methods
        /// </summary>


        //Get all Categories using Linq
        public List<Category> GetAllCategories()
        {//query synatx 
            var CatList = (from c in dbContext.Categories
                           orderby c.CategoryId
                           select c).ToList();//storing the result in a tolist 
            return CatList;
        }


        //Get all products using a linq, list genereic and returns the values of Productist
        public List<Product> ListProducts()
        {
            var ProductList = (from p in dbContext.Products
                               orderby p.ProductId
                               select p).ToList();//storing the result in a tolist 
            return ProductList;
        }



        //Takes a categoryId as a parameter and displays all the products in that category
        public List<Product> GetProductsusingCategoryId(byte CategoryId)
        {

            List<Product> listProducts = null;
            try
            {
                listProducts = dbContext.Products.Where(p => p.CatrgoryId == CategoryId).ToList();
            }
            catch (Exception ex)
            {
                listProducts = null;
            }
            return listProducts;
        }


        /// <summary>
        /// For the Cart class
        /// </summary>



        //Validate user for fromd End Login page
        public string ValidateUserLogin(string EmailId, string Password)
        {
            string userName = "";
            try
            {
                var users = (from user in dbContext.User
                             where user.EmailId == EmailId && user.Password == Password //matching the passed parameteres 
                             select user.Role).FirstOrDefault<Roles>();
                if (users != null)
                {
                    userName = users.RoleName;
                }
                else
                {
                    userName = "Invalid Entry";
                }

            } catch (Exception ex)
            {
                userName = "Invalid Entry";
            }
            return userName;
        }


        //public int AddProductToCart(string productId, string productName, string emailId, string quantity)
        //{
        //    System.Nullable<int> value = -1;
        //    try
        //    { SqlParameter prmCategoryName = new SqlParameter("@Product", productId);
        //        SqlParameter prmCategoryId = new SqlParameter("@EmailId", emailId);
        //        SqlParameter prmProductName = new SqlParameter("@ProductName", productName);
        //        SqlParameter prmquantity = new SqlParameter("@Qunatity", quantity);
        //        var returnvalue = dbContext.Database.ExecuteSqlCommand("EXEC dbo.AddProductToCart @Product , @EmailId ,  @ProductName", new[] { prmCategoryName, prmCategoryId, prmProductName , prmquantity });
        //        value = Convert.ToInt32(returnvalue);
        //    }catch(Exception ex)
        //    {
        //        value = -1;
        //    }
        //    return Convert.ToInt32(value); 
        //}
        //This methods adds product to cart
        //Github Code
        public int AddProductToCart(string productId, string productName, string emailId, byte quantity)
        {
            int value = -1;
            Cart newCart = new Cart();

            newCart.ProductId = productId;
            newCart.ProductName = productName;
            newCart.EmailId = emailId;
            newCart.Quantity = quantity;

            try
            {

                dbContext.cart.Add(newCart);//Object will be addedin the dbset products using Add method
                //dbContext.SaveChanges();//this will save our object in the database not only in memory
                //  status = true;
                value = 1;
            }
            catch (Exception ex)
            {
                value = -1;
            }
            return value = 1;

        }

        //Delete products form cart using parameters
        //public bool DeleteCartItem(string productId, string emailId)
        //{
        //    bool status = false;
        //    try
        //    {
        //        var product = (from cart in dbContext.cart
        //                       where cart.ProductId == productId && cart.EmailId == emailId
        //                       select cart).FirstOrDefault();
        //        dbContext.cart.Remove(product);
        //        status = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        status = false;
        //    }
        //    return status;

        //}

        public bool DeleteCartItem(string productId, string emailId)
        {
            bool status = false;
            try
            {
                 Cart newCart = ((IQueryable<Cart>)dbContext.cart).Where((Cart cart) => cart.ProductId == productId && cart.EmailId == emailId).FirstOrDefault();
                dbContext.cart.Remove(newCart);
                ((DbContext)dbContext).SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;

        }


        //{
        //    SqlParameter EmailId = new SqlParameter("@Email", emailId);
        //    cartItem = dbContext.cartItems.FromSql("SELECT * FROM dbo.ufn_GetCartItems(@Email)", EmailId).ToList();

        //Fetch Cart product for user services in cart component
        public List<Cart> GetCartItems(string emailId)
        {
            List<Cart> cartItems = null;
            try { 
            SqlParameter EmailId = new SqlParameter("@Email", emailId);
            cartItems = dbContext.cart.FromSqlRaw("SELECT * FROM dbo.ufn_GetCartItems(@Email)", EmailId).ToList();
        }catch(Exception ex)
        {
            cartItems = null;
        }
            return cartItems;
        }



        /// <summary>
        /// This Methods will be used for Admin use
        /// </summary>
        /// 

        //Admin can AddProducts
        //Add products in to database
        public bool AddProduct(string ProductId, string ProductName, decimal Price, int QuantityAvailable)
        {
            bool status = false;
            Product newProduct = new Product();

            newProduct.ProductId = ProductId;
            newProduct.ProductName = ProductName;
            newProduct.Price = Price;
            newProduct.QuantityAvailable = QuantityAvailable;
            //newProduct.CatrgoryId = CategoryId;
            //newProduct.Category = Category;
            try
            {

                dbContext.Products.Add(newProduct);//Object will be addedin the dbset products using Add method
                //dbContext.SaveChanges();//this will save our object in the database not only in memory
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;

        }

        //To add one or more products passing an array of products and using addRange method
        public bool AddRangeOfProduct(params Product[] products)
        {
            bool status = false;
            try
            {
                dbContext.Products.AddRange(products);
                //dbContext.SaveChanges();
                status = true;

            } catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        //Add More category to the database
        public bool AddCategory(string CategoryName)
        {
            bool status = false;
            Category newCategory = new Category();  //Creating a new category obeject in memeory 
                                                    // newCategory.CategoryId = CategoryId;    
            newCategory.CategoryName = CategoryName;


            try
            {
                dbContext.Add<Category>(newCategory);
                //dbContext.Categories.Add(newCategory);//Object will be addedin the dbset categories using Add method
                // dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Customers ON"); // need to enable IDENTITY_INSERT before calling SaveChanges() manually.
                status = true;
                dbContext.SaveChanges();//this will save our object in the database not only in memory
                // dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Customers OFF");
            }



            catch (Exception ex)
            {
                status = false;
            }
            return status;

        }

        public bool AddCategory(int CategoryId, string CategoryName)
        {
            bool status = false;
            Category newCategory = new Category();  //Creating a new category obeject in memeory 
            newCategory.CategoryId = CategoryId;
            newCategory.CategoryName = CategoryName;

            dbContext.Database.OpenConnection();
            try
            {

                dbContext.Categories.Add(newCategory);//Object will be addedin the dbset categories using Add method
                // dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Customers ON"); // need to enable IDENTITY_INSERT before calling SaveChanges() manually.
                //  dbContext.SaveChanges();//this will save our object in the database not only in memory
                // dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Customers OFF");
            }



            catch (Exception ex)
            {
                status = false;
            }
            return status;

        }

        //Admin can change category name
        //Update acategory Name passing a new categories in to the database
        public bool UpdateCategory(int CategoryId, string UpdateCategoryName)
        {
            bool status = false;
            try
            {
                Category UpdateCategory = dbContext.Categories.Find(CategoryId); //Using the Find Method
                UpdateCategory.CategoryName = UpdateCategoryName; ;

                using (var newDBContext = new ShopizantDBContext()) //new null DBcontext object
                {
                    newDBContext.Categories.Update(UpdateCategory);//Using Update from DBContext method
                    dbContext.SaveChanges();
                    status = true;

                }


            }
            catch (Exception ex)
            {
                status = false;
            }
            return true;
        }




        //Update Products using a productId and required varaiables passed in the parameter 
        public bool UpdateProducts(string ProductId, string ProductName, decimal Price, int QuantityAvailable)
        {
            bool status = false;
            try
            {
                Product UpdateProduct = dbContext.Products.Find(ProductId); //Using the Find Method
                UpdateProduct.ProductId = ProductId;
                UpdateProduct.ProductName = ProductName;
                UpdateProduct.Price = Price;
                UpdateProduct.QuantityAvailable = QuantityAvailable;

                using (var newDBCOntext = new ShopizantDBContext()) //new DBcontext object
                {
                    newDBCOntext.Products.Update(UpdateProduct);
                    dbContext.SaveChanges();
                    status = true;

                }


            } catch (Exception ex)
            {
                status = false;
            }
            return true;
        }


        //Delete a Product using ProductId passed in the parameter 
        public bool DeleteProduct(string ProductId)//hold string passed as ProductId
        {
            bool status = false;
            Product Deleteproduct = null; //To hold our value passed
            try
            {
                Deleteproduct = dbContext.Products.Find(ProductId);//Checks the Database using find method from dbContext 
                if (Deleteproduct != null)
                {
                    dbContext.Products.Remove(Deleteproduct);
                    //dbContext.SaveChanges();
                    status = true;
                }

            }
            catch (Exception ex)
            {
                return status;
            }
            return status;
        }
        //This method will delete Categories from the database
        public bool DeleteCategory(int CategoryId)//hold string passed as ProductId
        {
            bool status = false;
            Category DeleteCategory = null; //To hold our value passed
            try
            {
                DeleteCategory = dbContext.Categories.Find(CategoryId);//Checks the Database using find method from dbContext 
                if (DeleteCategory != null)
                {
                    dbContext.Categories.Remove(DeleteCategory);
                    dbContext.SaveChanges();
                    status = true;
                }

            }
            catch (Exception ex)
            {
                return status;
            }
            return status;
        }


        //Method to view cart items user has chosen in cart view
        //public List<CartItems>



    }
      
}

