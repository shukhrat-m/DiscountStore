using Data.Models;

namespace Core.Interfaces
{
    public interface ICartService
    {
        void Add(Item item);
        void Remove(Item item);
        double GetTotal();
    }

}
