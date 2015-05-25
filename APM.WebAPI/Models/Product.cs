using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace APM.WebAPI.Models
{
    public class Product
    {
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product code is required!")]
        [MinLength(6, ErrorMessage = "Product code must be at least 6 characters long!")]
        public string ProductCode { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required!", AllowEmptyStrings = false)]
        [MinLength(4, ErrorMessage = "Product name must be at least 4 characters long!")]
        [MaxLength(12, ErrorMessage = "Product name cannot be longer than 12 characters!")]
        public string ProductName { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}