using CityDetails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
//using CityDetails.Models;
using System.Threading.Tasks;

namespace CityDetails
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }
            
            //Seeding the data
            var cities = new List<City>() {
            new City()
            {
                Id = 1,
                Name = "NewYork",
            Description = "What ever newyork does",

            PointsOfInterest = new List<PointOfInterest>()
            {
                new PointOfInterest() {
                    Id =1,
                    Name = "Central Park",
                    Description = "Central park desc"
                },

                new PointOfInterest() {
                    Id =2,
                    Name = "Empire State Buildinf",
                    Description = "Empire State desc"
                },
            }

            },

            new City()
            {
                Id = 2,
                Name = "Corpus",
            Description = "What ever Corpus does",

            PointsOfInterest = new List<PointOfInterest>()
            {
                new PointOfInterest() {
                    Id =3,
                    Name = "TAMUCC",
                    Description = "Tamucc desc"
                },

                new PointOfInterest() {
                    Id =4,
                    Name = "Dave and busters",
                    Description = "Dave and busters desc"
                },
            }
            },

            new City()
            {
                Id = 3,
                Name = "Hyd",
            Description = "What ever Hyd does",

            PointsOfInterest = new List<PointOfInterest>()
            {
                new PointOfInterest() {
                    Id =5,
                    Name = "tank bund",
                    Description = "Tank bund desc"
                },

                new PointOfInterest() {
                    Id =6,
                    Name = "Gokul Chat",
                    Description = "Gokul Chat desc"
                },
            }
            }
            };


            context.Cities.AddRange(cities);
            context.SaveChanges();
    }
    }
}
