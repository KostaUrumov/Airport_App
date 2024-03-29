﻿using Aiport_App_Structure.Models;
using Airport_App_Core.Models.FlightModels;

namespace Airport_App_Core.Models.AirplaneModels
{
    public class SearchAirplaneModel
    {
        public int AircraftId { get; set; }
        public IEnumerable<Aircraft> Aircrafts { get; set; } = new List<Aircraft>();
    }
}
