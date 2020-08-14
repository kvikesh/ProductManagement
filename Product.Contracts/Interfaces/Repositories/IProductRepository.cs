using Product.Contracts.Models;
using System.Collections.Generic;

namespace Product.Contracts.Interfaces.Repositories
{
    public interface IProductRepository
    {
        void DeleteCategory(string name);
        IEnumerable<Item> GetProductItem();
    }
}
