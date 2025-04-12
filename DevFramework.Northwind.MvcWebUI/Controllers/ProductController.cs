using DevFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFramework.Northwind.Entities;
using DevFramework.Northwind.MvcWebUI.Models;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public ActionResult Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "Test",
                QuantityPerUnit = "1",
                UnitPrice = 22,
            });

            return Content("Added");
        }
    }
}