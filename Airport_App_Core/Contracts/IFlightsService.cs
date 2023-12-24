﻿using Aiport_App_Structure.Models;
using Airport_App_Core.Models.FlightModels;

namespace Airport_App_Core.Contracts
{
    public interface IFlightsService
    {
        Task<List<DisplayFlightModel>> TakeLastFive();
        Task<List<DisplayFlightModel>> SearchFlight(SearchFlightModel model);
        Task<List<DisplayFlightModel>> AllByCountryDeparture(int countryId);
        Task<List<DisplayFlightModel>> FilterByDepartureAirport(int airportId);
        Task<List<DisplayFlightModel>> AllFlights();
    }
}
