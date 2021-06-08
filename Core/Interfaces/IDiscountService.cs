using Data.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IDiscountService
    {
        void Remove(Discount discount);

        ICollection<Discount> GetAll();

        Discount GetById(int id);

        void Add(Discount item);

        void Save();
    }
}
