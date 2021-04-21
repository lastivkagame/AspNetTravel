using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgenncyUI.Models
{
    public class FlightViewModel
    {
        public int Id { get; set; }

        //public string LocationFirstFlight { get; set; } //country, city from we start tour

        //public string LocationResortPlace { get; set; } //country, city where we resort/relax

        public string FlightTimeToBegan { get; set; } //Date when we flight to country where we relax

        public string FlightTimeBackBegan { get; set; } //Date when we flight back to home(country)

        public string StartTimeBackHours { get; set; } //Date(HOURS) when we flight to country where we relax

        public string Type { get; set; } //such as bussnes class, standart ...

    }
}