using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Models.TicketModels;
using Airport_App_Structure.Data;
using Microsoft.EntityFrameworkCore;

namespace Airport_App_Core.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly AirportDb data;

        public PassengerService(AirportDb _data)
        {
            data = _data;
        }

        public async Task AddToFlight(Passenger passenger, int flightId)
        {
            Flight fli = await data
                .Flights
                .FirstAsync(f => f.Id == flightId);
            fli.TotalTickets -= 1;

            Passenger findPassenger = await data
                .Passengers
                .FirstAsync(
                x => x.FirstName == passenger.FirstName
                && x.LastName == passenger.LastName
                && x.Age == passenger.Age);

            findPassenger.FlightsPassengers.Add(new FlightPassenger()
            {
                FlightId = flightId
            });

            await data.SaveChangesAsync();

        }

        public bool CheckIfPassengerIsInThisFlight(Passenger passenger, int flightId)
        {
            var passen = data
                .Passengers
                .First(
                x => x.FirstName == passenger.FirstName
                && x.LastName == passenger.LastName
                && x.Age == passenger.Age);

            var flightIsThere = data
                .FlightsPassengers
                .FirstOrDefault(x => x.FlightId == flightId && x.PassengerId == passen.Id);

            if (flightIsThere != null)
            {
                return true;
            }
            return false;
        }

        public async Task CreateAndSaveNewPassengers(Passenger passenger, int flightId)
        {
            Flight fli = await data
                .Flights
                .FirstAsync(f => f.Id == flightId);
            fli.TotalTickets -= 1;

            passenger.FlightsPassengers.Add(new FlightPassenger()
            {
                FlightId = flightId
            });

            data.AddRange(passenger);
            await data.SaveChangesAsync();

        }

        public List<Passenger> CreatePassengers(List<BuyTicketsModel> passengers)
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
                newPassengers.Add(one);
            }

            return newPassengers;
        }

        public bool IsPassengerAlreadyIn(Passenger passenger)
        {
            var found = data
                .Passengers
                .FirstOrDefault(
                x => x.FirstName == passenger.FirstName
                && x.LastName == passenger.LastName
                && x.Age == passenger.Age);
            if (found != null)
            {
                return true;
            }

            return false;
        }
    }
}
