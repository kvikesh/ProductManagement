using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Contracts.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Item = new HashSet<Item>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("SubCategory")]
        public virtual Category Category { get; set; }
        [InverseProperty("SubCategory")]
        public virtual ICollection<Item> Item { get; set; }
    }
}
