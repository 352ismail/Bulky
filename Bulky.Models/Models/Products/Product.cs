using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BulkyBook.Models.Models.Products
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string? ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        public string? Description { get; set; }
        [DisplayName("List Price")]
        [Range(1, 100000000)]
        public double ListPrice { get; set; }

        [DisplayName("Price for 1 to 50")]
        [Range(1, 100000000)]
        public double Price { get; set; }

        [DisplayName("Price for more than 50")]
        [Range(1, 100000000)]
        public double Price50 { get; set; }

        [DisplayName("Price for more than 100")]
        [Range(1, 100000000)]
        public double Price100 { get; set; }
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        public string? ImageUrl { get; set; }

    }
}
