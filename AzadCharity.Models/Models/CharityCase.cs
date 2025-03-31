using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzadCharity.Models.Models
{
    public class CharityCase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Amount needed is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal AmountNeeded { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Amount collected must be zero or more.")]
        public decimal AmountCollected { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        // 🔹 Add Category Relationship
        [Required(ErrorMessage = "Category is required.")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
