using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelDAL.Entities
{
    public class Flight
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string FlightName { get; set; }

        [Required]
        public string StartCityTo { get; set; }

        public string StartCityBack { get; set; }

        [Required]
        public string StartTimeTo { get; set; }

        public string EndTimeTo { get; set; }

        [Required]
        public string StartTimeBack { get; set; }
        public string EndTimeBack { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
