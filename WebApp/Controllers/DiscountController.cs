using AutoMapper;
using Core.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IItemService itemService, IMapper mapper)
        {
            _discountService = discountService;
            _itemService = itemService;
            _mapper = mapper;
        }

        public IActionResult Index(string errorMessage)
        {
            DiscountsDTO discountsDTO = new DiscountsDTO();

            if (!string.IsNullOrEmpty(errorMessage))
            {
                discountsDTO.ErrorMessage = errorMessage;
            }
            var t = _discountService.GetAll();
            discountsDTO.Discounts = _mapper.Map<List<Discount>, List<DiscountDTO>>(_discountService.GetAll().ToList());

            return View(discountsDTO);
        }

        [HttpGet]
        public IActionResult Add()
        {
            try
            {
                DiscountDTO discountDTO = new DiscountDTO();
                discountDTO.Items = _itemService.GetAll().ToDictionary(x => x.Id, y => y.Name);

                return View(discountDTO);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { errorMessage = $"{ex.Message}" });
            }
        }

        [HttpPost]
        public IActionResult Add(DiscountDTO inModel)
        {
            if (inModel == null)
            {
                return RedirectToAction("Index", new { errorMessage = "An error occured while adding discount. Model is null" });
            }

            if (inModel.ItemId == 0)
            {
                return RedirectToAction("Add");
            }

            try
            {
                Discount discount = _mapper.Map<DiscountDTO, Discount>(inModel);
                Item item = _itemService.GetById(inModel.ItemId);
                discount.ItemName = item.Name;
                _discountService.Add(discount);
                _discountService.Save();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { errorMessage = $"{ex.Message}" });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove()
        {
            return View("Index");
        }
    }
}
