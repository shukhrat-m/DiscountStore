using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddItemToCart(ItemsDTO inModel)
        //{
        //    if (inModel == null)
        //    {
        //        return RedirectToAction("Index", new { errorMessage = "Items is null during adding items to cart" });
        //    }


        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public IActionResult RemoveItemToCart(ItemsDTO inModel)
        //{
        //    return RedirectToAction("Index");
        //}
    }
}
