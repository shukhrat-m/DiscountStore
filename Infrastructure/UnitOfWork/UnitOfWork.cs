using Data.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
            ItemRepository = new Repository<Item>(_context);
            DiscountRepository = new Repository<Discount>(_context);
            CartItemRepository = new Repository<CartItem>(_context);
        }

        public IRepository<Item> ItemRepository { get; private set; }

        public IRepository<Discount> DiscountRepository { get; private set; }

        public IRepository<CartItem> CartItemRepository { get; private set; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
