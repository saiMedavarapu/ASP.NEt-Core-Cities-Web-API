using CityDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityDetails
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities {get; set;}

        public CitiesDataStore() {
            Cities = new List<CityDto>() {
            new CityDto()
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

            new CityDto()
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

            new CityDto()
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

        }
    }

}
