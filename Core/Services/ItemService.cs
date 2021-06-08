using Core.Interfaces;
using Data.Models;
using Infrastructure.UnitOfWork;
using System.Collections.Generic;

namespace Core.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Item item)
        {
            _unitOfWork.ItemRepository.Add(item);
        }

        public ICollection<Item> GetAll()
        {
            return _unitOfWork.ItemRepository.GetAll();
        }

        public Item GetById(int id)
        {
            return _unitOfWork.ItemRepository.Get(id);
        }

        public void Remove(Item item)
        {
            _unitOfWork.ItemRepository.Remove(item);
        }

        public void Save()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
