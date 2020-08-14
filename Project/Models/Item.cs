using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.WebAPI.Models
{
    public partial class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int SubCategoryId { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [ForeignKey(nameof(SubCategoryId))]
        [InverseProperty("Item")]
        public virtual SubCategory SubCategory { get; set; }
    }
}
