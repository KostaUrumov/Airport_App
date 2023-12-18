using Aiport_App_Structure.Models.Enums;
using Airport_App_Core.Contracts;
using Airport_App_Structure.Data;

namespace Airport_App_Core.Services
{
    public class ContinentService : IContinentService
    {
        private readonly AirportDb data;

        public ContinentService(AirportDb _data)
        {
            data = _data;
        }
        
    }
}
