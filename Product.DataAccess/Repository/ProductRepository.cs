﻿using Microsoft.EntityFrameworkCore;
using Product.Contracts.Interfaces.Repositories;
using Product.Contracts.Models;
using Product.DataAccess.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace Product.DataAccess.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly ProductDBContext _context;
        public ProductRepository(ProductDBContext context)
        {
            this._context = context;

        }

        public IEnumerable<Item> GetProductItem(string name)
        {
            return _context.Item.Where(x=>x.Name == name).Include(x => x.SubCategory).Include(x => x.SubCategory.Category).ToList();
        }

        public IEnumerable<Item> GetProductItem()
        {
            return _context.Item.Include(x=>x.SubCategory).Include(x=>x.SubCategory.Category).ToList();
        }

        public void DeleteCategory(string name)
        {
            Category _itemToDelete = _context.Category.FirstOrDefault(x => x.Name == name);
            if (_itemToDelete != null) {
                _context.Category.Remove(_itemToDelete);
                _context.SaveChanges();
            }
            return;
        }
    }
}
