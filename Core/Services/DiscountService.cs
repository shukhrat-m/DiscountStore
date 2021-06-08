using Core.Interfaces;
using Data.Models;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiscountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Discount item)
        {
            _unitOfWork.DiscountRepository.Add(item);
        }

        public ICollection<Discount> GetAll()
        {
            return _unitOfWork.DiscountRepository.GetAll();
        }

        public Discount GetById(int id)
        {
            return _unitOfWork.DiscountRepository.Get(id);
        }

        public void Remove(Discount discount)
        {
            _unitOfWork.DiscountRepository.Remove(discount);
        }

        public void Save()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
