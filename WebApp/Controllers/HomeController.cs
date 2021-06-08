using AutoMapper;
using Core.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebApp.Helpers;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IItemService _itemService;
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public HomeController(ICartService cartService, IItemService itemService, IDiscountService discountService, IMapper mapper)
        {
            _cartService = cartService;
            _itemService = itemService;
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(string errorMessage)
        {
            CartItemsDTO cartItemsDTO = new CartItemsDTO();

            if (!string.IsNullOrEmpty(errorMessage))
            {
                cartItemsDTO.ErrorMessage = errorMessage;
            }

            cartItemsDTO.CartItems = _mapper.Map<List<CartItem>, List<CartItemDTO>>(_cartService.GetAll().ToList());
            cartItemsDTO.TotalPrice = _cartService.GetTotal();
            CartItemHelper.IncludeItemNameAndDiscount(cartItemsDTO, _itemService, _discountService);
            return View(cartItemsDTO);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CartItemDTO cartItemDTO = new CartItemDTO();
            cartItemDTO.Items = _itemService.GetAll().ToList().ToDictionary(x => x.Id, y => y.Name);
            
            return View(cartItemDTO);
        }

        [HttpPost]
        public IActionResult Add(CartItemDTO inModel)
        {
            if (inModel == null)
            {
                return RedirectToAction("Index", new { errorMessage = "An error occured while adding item to cart. Model is null" });
            }

            if (inModel.ItemId == 0)
            {
                return RedirectToAction("Add");
            }

            Item item = _itemService.GetById(inModel.ItemId);
            Discount discount = _discountService.GetAll().Where(x => x.ItemId == item.Id).LastOrDefault();
            var cartItem = _mapper.Map<CartItemDTO, CartItem>(inModel);
            cartItem.TotalPrice = CartItemHelper.GetTotalPrice(inModel, item, discount);
            cartItem.DiscountId = discount?.Id;
            _cartService.Add(cartItem);
            _cartService.Save();

            return RedirectToAction("Add");
        }
    }
}
