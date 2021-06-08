using System.Collections.Generic;

namespace WebApp.Models
{
    public class ItemsDTO
    {
        public ItemsDTO()
        {
            Items = new List<ItemDTO>();
        }

        public ICollection<ItemDTO> Items { get; set; }
        
        public string ErrorMessage { get; set; }

    }
}
