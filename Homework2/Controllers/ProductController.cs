using Homework2.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework2.Controllers
{
    public class ProductController : Controller
    {

        public static List<Product> products { get; set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Description = "High-performance laptop for professionals", ImageUrl = "https://kontakt.az/media/catalog/product/cache/ec3348cd707f11bd7a951e83328510dc/t/m/tm-dg-kot-1114-nb-2359-839ff1ce.webp" },
            new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone with advanced features", ImageUrl = "https://kontakt.az/media/catalog/product/cache/a252e3db3d11365dd1457895056a5f34/t/m/tm-dg-sbp-1105-sm-2508-110.png" },
            new Product { Id = 3, Name = "Headphones", Description = "Noise-cancelling over-ear headphones", ImageUrl = "https://kontakt.az/media/catalog/product/cache/a252e3db3d11365dd1457895056a5f34/t/m/tm-dg-acs-1109-hg-0156.png" },
            new Product { Id = 4, Name = "Smartwatch", Description = "Water-resistant smartwatch with multiple functions", ImageUrl = "https://kontakt.az/media/catalog/product/cache/a252e3db3d11365dd1457895056a5f34/n/e/new_project_-_2023-01-13t225336.030.png" },
            new Product { Id = 5, Name = "Camera", Description = "High-resolution digital camera", ImageUrl = "https://kontakt.az/media/catalog/product/cache/a252e3db3d11365dd1457895056a5f34/t/m/tm-dg-acs-1109-wc-0036_1.png" },
            new Product { Id = 6, Name = "Tablet", Description = "Lightweight tablet with long battery life", ImageUrl = "https://kontakt.az/media/catalog/product/cache/a252e3db3d11365dd1457895056a5f34/l/d/ld0005936259_1.jpg" },
            new Product { Id = 7, Name = "Monitor", Description = "4K Ultra HD monitor", ImageUrl = "https://kontakt.az/media/catalog/product/cache/a404967cc40694dc557cd869288440a4/t/m/tm-dg-kot-1114-mr-0240-1.png" },
            new Product { Id = 8, Name = "Keyboard", Description = "Mechanical keyboard with backlit keys", ImageUrl = "https://kontakt.az/media/catalog/product/cache/a252e3db3d11365dd1457895056a5f34/t/m/tm-dg-acs-1109-kb-0281_1.png" },
            new Product { Id = 9, Name = "Mouse", Description = "Wireless ergonomic mouse", ImageUrl = "https://kontakt.az/media/catalog/product/cache/a252e3db3d11365dd1457895056a5f34/n/e/new_project_-_2022-12-27t120849.601.png" },
            new Product { Id = 10, Name = "Printer", Description = "All-in-one wireless printer", ImageUrl = "https://kontakt.az/media/catalog/product/cache/a252e3db3d11365dd1457895056a5f34/_/d/_d0_9d_d0_be_d0_b2_d1_8b_d0_b9-_d0_bf_d1_80_d0_be_d0_b5_d0_ba_d1_82-5-47_png.png" }
        };



        // GET: ProductController
        public ActionResult Index()
        {
            var vm = new ProductViewModel
            {
                Products = products,
            };
            return View(vm);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create ()
        {
            var vm = new AddProductViewModel
            {
                product = new()
            };
            return View(vm);
        }

        // GET: ProductController/Create
        [HttpPost]
        public ActionResult Create(AddProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                
                vm.product.Id = (new Random()).Next(100, 1000);
                products.Add(vm.product);
                return RedirectToAction("Index");
            }
            else
            {
                return View();

            }
        }

       

    

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = products.SingleOrDefault(e => e.Id == id);
            if (item != null)
            {
                products.Remove(item);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return Ok("error");
            }

            var viewModel = new AddProductViewModel { product = product };
            return View(viewModel);
        }

        

        [HttpPost]
        public ActionResult Edit(AddProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var product = products.FirstOrDefault(p => p.Id == vm.product.Id);
                if (product != null)
                {
                    product.Name = vm.product.Name;
                    product.Description = vm.product.Description;
                    product.ImageUrl = vm.product.ImageUrl;
                    return RedirectToAction("Index");
                }
                else
                {
                    return Ok("error");
                }
            }
            else
            {
                return View(vm);
            }
        }
    }
}
