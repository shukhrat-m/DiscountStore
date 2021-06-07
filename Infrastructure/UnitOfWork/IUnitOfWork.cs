using Data.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Item> ItemRepository { get; }

        IRepository<Discount> DiscountRepository { get; }

        IRepository<CartItem> CartItemRepository { get; }

        void SaveChanges();
    }
}
