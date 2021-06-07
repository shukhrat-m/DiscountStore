using Data.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Discount> Discounts { get; }

        IRepository<Item> Items { get; }

        int SaveChanges();
    }
}
