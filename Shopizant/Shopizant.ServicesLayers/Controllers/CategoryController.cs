using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Shopizant.CodeFirst.DAL;
using Shopizant.CodeFirst.DAL.Models;

namespace Shopizant.ServicesLayers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private Repository repository;

        public CategoryController()
        {
            repository = new Repository();
    }

    [HttpGet]
    public JsonResult GetCategories()
    {

        List<Category> categories = new List<Category>();
        try
        {
            categories = repository.GetAllCategories();

        }
        catch (Exception ex)
        {
            categories = null;
        }
        return Json(categories);
    }




    [HttpPost]
    [Route("create")]
    public JsonResult Post(string CategoryName)
    {

        bool status = false;
        //string productId = null;
        string message;
        try
        {
            status = repository.AddCategory(CategoryName);
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
    public JsonResult Put(int CategoryId, string CategoryName)
    {

        bool status = false;
        //string productId = null;
        string message;
        try
        {
            status = repository.UpdateCategory(CategoryId, CategoryName);
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
    public JsonResult Delete(int CategoryId)
    {

        bool status = false;
        //string productId = null;
        string message;
        try
        {
            status = repository.DeleteCategory(CategoryId);
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
