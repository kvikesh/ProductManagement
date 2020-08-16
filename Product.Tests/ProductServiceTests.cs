using Moq;
using Product.BusinessLogic.Services;
using Product.BusinessLogic.Services.CustomExceptions;
using Product.Contracts.Interfaces.Repositories;
using Product.Contracts.Interfaces.Services;
using Product.Contracts.Models;
using System.Collections.Generic;
using Xunit;

namespace Product.Tests
{
    public class ProductServiceTests
    {
        private readonly IProductService _productService;
        private readonly Mock<IProductRepository> _productRepMock = new Mock<IProductRepository>();
        public ProductServiceTests()
        {
            _productService = new ProductService(_productRepMock.Object);
        }

        [Theory]
        [InlineData("Apple",1,10)]
        public void GetItemsByName_WhenNameIsPassed(string name,int page, int recordSize)
        {
            //arrange
            var items = this.getItems();
             _productRepMock.Setup(x => x.GetProductItem(name, page, recordSize)).Returns(items);

            //Act
            var sut = _productService.GetItemsByName(name, page, recordSize);

            //Assert
            Assert.Equal(name, sut[0].ItemName);
        }

        [Theory]
        [InlineData("", 1, 10)]
        public void GetItemsByName_WhenNameIsNotPassed(string name, int page, int recordSize)
        {
            //arrange
            var items = this.getItems();
            _productRepMock.Setup(x => x.GetProductItem(name, page, recordSize)).Returns(items);

            //Act
            var sut = _productService.GetItemsByName(name, page, recordSize);

            //Assert
            //first param is 2 as total items added thorugh moq is 2
            Assert.Equal(2, sut.Count);
        }

        [Theory]
        [InlineData("1")]
        public void DeleteCetgory(string category)
        {
            //arrange
            _productRepMock.Setup(x => x.DeleteCategory("Watch"));

            //Act
            var sut = _productService.DeleteCategory(category);

            //Assert
            Assert.Equal("ItemRemoved", sut);
        }

        [Theory]
        [InlineData("2")]
        public void DeleteCetgory_WrongCatgory(string category)
        {
            //arrange
            _productRepMock.Setup(x => x.DeleteCategory(category)).Throws(new ItemNotFoundException());

            //Act
            var sut = _productService.DeleteCategory(category);

            //Assert
            Assert.Equal("ItemNotFound", sut);
        }

        private List<Item> getItems() {
            var category = new Category
            {
                Id = 1,
                Name = "Watch",
            };

            var subCategory = new SubCategory
            {
                Id = 1,
                Name = "Smart watch",
                CategoryId = 1,
                Category = category

            };

            var item1 = new Item
            {
                Id = 1,
                Name = "Apple",
                Description = "this is a smart watch",
                SubCategoryId = 1,
                SubCategory = subCategory
            };

            var item2 = new Item
            {
                Id = 1,
                Name = "Fossil",
                Description = "this is a smart watch",
                SubCategoryId = 1,
                SubCategory = subCategory
            };

            var items = new List<Item>();
            items.Add(item1);
            items.Add(item2);

            return items;
        }
    }
}


