using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelDAL.Entities
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int? ResortNights { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public int? AmountPeople { get; set; }

        [Required]
        public string Type { get; set; } // all inclusive or other

        [Required]
        public virtual Location Location { get; set; }

        [Required]
        public virtual Flight Flight { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string Image { get; set; }

    }
}
