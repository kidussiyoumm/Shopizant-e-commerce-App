using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Shopizant.CodeFirst.DAL;
using Shopizant.CodeFirst.DAL.Models;
using System;
using System.Collections.Generic;

namespace Shopizant.ServicesLayers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private Repository repository;
        private ShopizantDBContext _dbContext;

        //User Controller
        [HttpPost]
        [Route("Validate")]
        public JsonResult UserCredentials(string EmailId, string Password)

        {
            string userName ="";
            try
            {
                var temp = new Repository();//new local memeory in repository
                userName = temp.ValidateUserLogin(EmailId, Password);
            }
            catch (Exception ex)
            {
                userName = ex.Message;
            }
            return Json(userName);

        }
        //Cart Controller


        [HttpGet]
        [Route("GetCartItems")]
        public JsonResult FetchCartItems(string emailId)
        {

            try
            {
                var temp = new Repository();
                var cartList = temp.GetCartItems(emailId);
                CartItems item;
                var product = new List<CartItems>();
                if (cartList.Any())
                {
                    foreach (var pro in cartList)
                    {
                        item = new CartItems();
                        item.ProductId = pro.ProductId;
                        item.ProductName = pro.ProductName;
                        item.Qunatity = pro.Quantity;
                        item.QuantityAvailable = pro.Quantity;
                        // item.price = pro.price; 

                        product.Add(item);
                    }
                }
                return Json(product);
            }catch (Exception ex)
            {
                return null;
            }
        }


        [HttpPost]
        [Route("AddToCart")]
        public JsonResult AddToCart(string ProductId, string ProductName, string EmailId, byte quantity)
        {

            int value = -1;
            try
            {
                var temp = new Repository();
                value = temp.AddProductToCart(ProductId, ProductName, EmailId , quantity);
               // value = repository.AddProductToCart(ProductId, cart.ProductName, cart.EmailId);

            }catch(Exception ex)
            {
                value = -1;
            }
            return Json(value);
        }


     

        ///To fetch products in cart for cart component to view
        [HttpDelete]
        [Route("DeleteCart")]
        public JsonResult DeleteCartItems(string ProductId, string ProductName)
        {
            var status = false;
            try
            {
                var temp = new Repository();
                status = temp.DeleteCartItem(ProductId, ProductName);
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);

        }

       
        
    }
}
