using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models.Models
{
    public class Category
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(50, ErrorMessage = "Name can not exceed 50 characters")]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,1000)]
        public int DisplayOrder { get; set; }
    }
}
