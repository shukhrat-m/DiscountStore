using AutoMapper;
using Core.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        public IActionResult Index(string errorMessage)
        {
            ItemsDTO itemsDTO = new ItemsDTO();

            if (!string.IsNullOrEmpty(errorMessage))
            {
                itemsDTO.ErrorMessage = errorMessage;
            }

            itemsDTO.Items = _mapper.Map<List<Item>, List<ItemDTO>>(_itemService.GetAll().ToList());

            return View(itemsDTO);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ItemDTO());
        }

        [HttpPost]
        public IActionResult Add(ItemDTO inModel)
        {
            if (inModel == null)
            {
                return RedirectToAction("Index", new { errorMessage = "An error occured while adding item. Model is null" });
            }

            try
            {
                _itemService.Add(_mapper.Map<ItemDTO, Item>(inModel));
                _itemService.Save();
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
            //Make a KeyValue pair id->itemName for making dropdownlist
            //Put it to View
            return View("Index");
        }

        //[HttpPost]
        //public IActionResult Remove(ItemsDTO inModel)
        //{
        //    try
        //    {
        //        //Find an element
        //        //Remove an element
        //    }
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction("Index", new { errorMessage = $"{ex.Message}" });
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}
