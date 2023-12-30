﻿using Aiport_App_Structure.Models;
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

        public  async Task< bool> CheckIfExist(List<Passenger> passengers, int id)
        {
            List<Passenger> passengersAlreadyIn = await data
                .Passengers
                .Where(x=> x.FlightsPassengers.Any(x=>x.FlightId == id))
                .ToListAsync();

            foreach (var newOnes in passengers)
            {
                foreach (var alreadyIn in passengersAlreadyIn)
                {
                    if (alreadyIn.FirstName == newOnes.FirstName &&
                        alreadyIn.LastName == newOnes.LastName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public async Task ReturnNewPassengers(List<Passenger> passengers, int id)
        {
            List<FlightPassenger> listed = new List<FlightPassenger>();
            List<Passenger> oldPass = new List<Passenger>();
            List<Passenger> newPassengers = new List<Passenger>();
            int done = 0;

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
                        done++;
                        break;
                    }
                    
                }
                if (done > 0)
                {
                    continue;
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
