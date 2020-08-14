using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Contracts.Models.Response
{
    public class ItemResponse
    {
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
    }
}
