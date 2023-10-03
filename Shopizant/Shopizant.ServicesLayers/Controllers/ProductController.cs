using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopizant.CodeFirst.DAL.Models;
using Shopizant.CodeFirst.DAL;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace Shopizant.ServicesLayers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private Repository repository;
        private ShopizantDBContext _dbContext;
        public ProductController()
        {
            repository = new Repository();
        }
        [HttpGet]

        //Get all products from the repository 
        //As a Json format
        public JsonResult GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                products = repository.ListProducts();
            }
            catch (Exception ex)
            {
                products = null;
            }
            return Json(products);
        }

        [HttpGet]
        [Route("{id}")]
        public Product GetById(int id)
        {
            bool status = false;
            var product = _dbContext.Products.Find(id);
            try
            {
                if (product != null)
                    status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return product;
        }

        [HttpPost]

        [Route("create")]
        // Using Post to populate the database with products
        public JsonResult Post(string ProductId, string ProductName, decimal Price, int QuantityAvailable)
        {

            bool status = false;
            //string productId = null;
            string message;
            try
            {
                status = repository.AddProduct(ProductId, ProductName, Price, QuantityAvailable);
                if (status != false)
                {
                    message = "Product has been added to database";
                }
                else
                {
                    message = "Error has occured trying to add product to database";
                }
            }
            catch (Exception ex)
            {
                message = "Invaild addition";

            }
            return Json(message);
        }


        [HttpPut]
        [Route("update")]
        public JsonResult Put(string ProductId, string ProductName, decimal Price, int QuantityAvailable)
        {

            bool status = false;
            //string productId = null;
            string message;
            try
            {
                status = repository.UpdateProducts(ProductId, ProductName, Price, QuantityAvailable);
                if (status != false)
                {
                    message = "Product has been added to database";
                }
                else
                {
                    message = "Error has occured trying to add product to database";
                }
            }
            catch (Exception ex)
            {
                message = "Invaild addition";

            }
            return Json(message);
        }

        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(string ProductId)
        {

            bool status = false;
            //string productId = null;
            string message;
            try
            {
                status = repository.DeleteProduct(ProductId);
                if (status != false)
                {
                    message = "Product has been added to database";
                }
                else
                {
                    message = "Error has occured trying to add product to database";
                }
            }
            catch (Exception ex)
            {
                message = "Invaild addition";

            }
            return Json(message);
        }

    }
}

