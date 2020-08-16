using Product.Contracts.Models.Response;
using System.Collections.Generic;

namespace Product.Contracts.Interfaces.Services
{
    public interface IProductService
    {
        public List<ItemResponse> GetItemsByName(string name, int page, int recordSize);
        public string DeleteCategory(string name);
    }
}
