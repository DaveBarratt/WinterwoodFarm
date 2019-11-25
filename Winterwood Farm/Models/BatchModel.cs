using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Winterwood_Farm.Models
{
    public class BatchModel
    {
        [Display(Name = "Batch Id")]
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Fruit { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Variety { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
