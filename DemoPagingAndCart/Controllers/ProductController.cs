using DemoPagingAndCart.Logics;
using DemoPagingAndCart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPagingAndCart.Controllers
{
    public class ProductController : Controller
    {

        private readonly IConfiguration configuration;

        public ProductController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(int Id, int Page)
        {
            // title of page
            ViewData["title"] = "Products Page";

            // get all categories for menu bar
            ViewBag.Categories = (new CategoryManager()).GetCategories();
            
            // get all products in request page
            if(Page < 0) // if request WrongFormat or not exist
                Page = 1; // default first page
            int PageSize = Convert.ToInt32(configuration.GetValue<String>("AppSetting:PageSize"));
            ProductManager pm = new ProductManager();
            List<Product> products = pm.GetProducts(Id, (Page - 1) * PageSize + 1, PageSize);

            // get all products items to create pager
            int TotalProduct = (new ProductManager()).GetNumberOfProducts(Id);
            int TotalPage = TotalProduct / PageSize;
            if(TotalProduct % 2 == 0)
            {
                TotalPage++;
            }

            // set total page size in ViewData name = "TotalPage"
            ViewData["TotalPage"] = TotalPage;
            ViewData["CurrentPage"] = Page;
            ViewData["CurrentCategory"] = Id;

            return View(products);
        }
    }
}
