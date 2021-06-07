using Data.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ICartService
    {
        void Add(CartItem item);

        void Remove(CartItem item);
        
        double GetTotal();

        ICollection<CartItem> GetAll();

        CartItem GetById(int id);
    }

}
