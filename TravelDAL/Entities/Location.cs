using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelDAL.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LocationFullName { get; set; }

        public string Hotel { get; set; } //can be include in location name

        public double? Rating { get; set; } 

        public string Description { get; set; } //about country, place, hotel

        public string MainImage { get; set; }
        public List<string> ImagesGallery { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
