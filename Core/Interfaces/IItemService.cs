using Data.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IItemService
    {
        void Remove(Item item);

        ICollection<Item> GetAll();

        Item GetById(int id);

        void Add(Item item);

        void Save();
    }
}
