using Product.BusinessLogic.Services.CustomExceptions;
using Product.Contracts.Interfaces.Repositories;
using Product.Contracts.Interfaces.Services;
using Product.Contracts.Models;
using Product.Contracts.Models.Response;
using System;
using System.Collections.Generic;

namespace Product.BusinessLogic.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            if (productRepository != null) {
                this._productRepository = productRepository;
            }
        }

        public List<ItemResponse> GetItemsByName(string name, int page, int recordSize)
        {
            try
            {
                IEnumerable<Item> items;
                items = this._productRepository.GetProductItem(name, page, recordSize);
                var listOfItemResponses =  ItemMapper(items);
                return listOfItemResponses;
            }
            catch(Exception ex) {
                //log exception
                return null;
            }
        }

        public string DeleteCategory(string name)
        {
            try
            {
                this._productRepository.DeleteCategory(name);
                return "ItemRemoved";
            }
            catch (ItemNotFoundException ex)
            {
                //log exception
                return "ItemNotFound";
            }
            catch (Exception ex)
            {
                //log exception
                return "Exception";
            }
        }

        private List<ItemResponse> ItemMapper(IEnumerable<Item> items)
        {
            List<ItemResponse> listItemResponse = new List<ItemResponse>();
            foreach (Item _item in items) {
                var itemResponse = new ItemResponse();
                itemResponse.CategoryName = _item.SubCategory.Category.Name;
                itemResponse.ItemDescription = _item.Description;
                itemResponse.ItemName = _item.Name;
                itemResponse.SubCategoryName = _item.SubCategory.Name;

                listItemResponse.Add(itemResponse);
            }

            return listItemResponse;
        }
    }
}
