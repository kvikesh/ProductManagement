using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Contracts.Models
{
    public partial class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name length should be between 3 to 12")]
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
