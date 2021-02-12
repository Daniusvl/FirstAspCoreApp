using System;
using System.ComponentModel.DataAnnotations;

namespace Terabaitas.ViewModels
{
    public class ManagerProductViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        [StringLength(2000, MinimumLength = 5)]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 500)]
        public int Quantity { get; set; }
    }
}
