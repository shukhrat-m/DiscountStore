using Core.Interfaces;
using Data.Models;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;

namespace Core.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(CartItem item)
        {
            _unitOfWork.CartItemRepository.Add(item);
        }

        public ICollection<CartItem> GetAll()
        {
            return _unitOfWork.CartItemRepository.GetAll();
        }

        public CartItem GetById(int id)
        {
            return _unitOfWork.CartItemRepository.Get(id);
        }

        public double GetTotal()
        {
            //TODO:
            throw new NotImplementedException();
        }

        public void Remove(CartItem item)
        {
            _unitOfWork.CartItemRepository.Remove(item);
        }
    }
}
