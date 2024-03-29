﻿using Aiport_App_Structure.Models;
using Airport_App_Core.Models.AirplaneModels;

namespace Airport_App_Core.Contracts
{
    public interface IAirplaneService
    {
        Task<IEnumerable<Aircraft>> AddAllAircrafts();
        Task<List<DisplayAirplaneFlightsModel>> GetFlightsPerPlane(int id);
        Task AddAircraft(AddNewPlane plane);
        Task<List<DisplayAirplaneModel>> GetAllPLanes();
        Task<AddNewPlane> FindJet(int id);
        Task SaveChangesAsync(AddNewPlane plane);
        Task DeleteAsync(int id);
        Task <List<string>>AddPlanes();

    }
}
