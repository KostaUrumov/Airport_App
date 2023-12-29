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

        public async Task ReturnNewPassengers(List<Passenger> passengers, int id)
        {
            List<FlightPassenger> listed = new List<FlightPassenger>();
            List<Passenger> oldPass = new List<Passenger>();
            List<Passenger> newPassengers = new List<Passenger>();

            foreach (var item in passengers)
            {
                foreach (var pass in data.Passengers)
                {
                    if (pass.FirstName == item.FirstName &&
                        pass.LastName == item.LastName)
                    {
                        FlightPassenger newFP = new FlightPassenger();
                        newFP.FlightId = id;
                        newFP.PassengerId = pass.Id;
                        listed.Add(newFP);
                        oldPass.Add(pass);
                        break;
                    }
                    
                }
                Passenger jj = new Passenger()
                {
                    Age = item.Age,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    
                };
                jj.FlightsPassengers.Add(new FlightPassenger()
                {
                    FlightId = id
                });

                newPassengers.Add(jj);
            }

            

            data.AddRange(listed);
            data.AddRange(newPassengers);
            await data.SaveChangesAsync();
        }
    }
}
