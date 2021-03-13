using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelAgenncyUI.Models
{
    public class TourViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name can't be null")]
        [StringLength(200, ErrorMessage = "Max count of symbols are 200")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int? ResortNights { get; set; }
        public string Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int? AmountPeople { get; set; }
        public string Type { get; set; } // all inclusive or other
        public string Location { get; set; }
        public string Flight { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}