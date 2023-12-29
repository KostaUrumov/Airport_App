using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Models.TicketModels;
using Airport_App_Structure.Data;

namespace Airport_App_Core.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly AirportDb data;

        public PassengerService(AirportDb _data)
        {
            data = _data; 
        }

        public List<Passenger> AddPassengersToFlight(List<BuyTicketsModel> passengers)
        {
            List<Passenger> newPassengers = new List<Passenger>();
            for (int i = 0; i < passengers.Count; i++)
            {
                string[] names = passengers[i].Name
                    .Split(" ")
                    .ToArray();
                Passenger one = new Passenger();
                one.Age = passengers[i].Age;
                one.FirstName = names[0];
                one.LastName = names[1];

                one.FlightsPassengers.Add(new FlightPassenger()
                {
                    FlightId = passengers[i].FlightId
                });
                newPassengers.Add(one);
            }

            return newPassengers;
        }

        public List<Passenger> ReturnNewPassengers(List<Passenger> passengers, int id)
        {
            
            List<FlightPassenger> fpToAdd = new List<FlightPassenger>();
            foreach (var item in passengers)
            {
                foreach (var currentPassengers in data.Passengers)
                {
                    if (item.FirstName == currentPassengers.FirstName
                        && item.LastName == currentPassengers.LastName)
                    {
                        FlightPassenger newFP = new FlightPassenger()
                        {
                            FlightId = id,
                            PassengerId = currentPassengers.Id
                        };

                        fpToAdd.Add(newFP);
                        passengers.Remove(item);
                    }
                      
                }
                
            }

            data.AddRange(fpToAdd);
            data.SaveChanges();

            return passengers;

        }
    }
}
