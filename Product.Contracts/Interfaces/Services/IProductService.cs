using Product.Contracts.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Contracts.Interfaces.Services
{
    public interface IProductService
    {
        public List<ItemResponse> GetItemsByName(string name);
        public void DeleteCategory(string name);
    }
}
