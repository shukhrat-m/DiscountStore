using AutoMapper;
using Core.Interfaces;
using Data.Models;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public HomeController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
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
            return View(cartItemsDTO);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
