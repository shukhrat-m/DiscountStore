using Data.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ICartService
    {
        void Add(CartItem item);

        void Remove(CartItem item);
        
        decimal GetTotal();

        ICollection<CartItem> GetAll();

        CartItem GetById(int id);

        void Save();
    }

}
