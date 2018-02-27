using System.Collections.Generic;
using XYC.Common.Models.Sample;

namespace XYC.Services.Fakes.Sample
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with the big park",
                    PointOfInterest =  new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto(){
                            Id = 1,
                            Name = "Central Park",
                            Description = "df12312dsf"
                        },
                        new PointOfInterestDto(){
                            Id = 2,
                            Name = "Central Park2",
                            Description = "df12312dsf34"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Caloocan City",
                    Description = "The place wher so many kind people",
                    PointOfInterest =  new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto(){
                            Id = 1,
                            Name = "Central Park2",
                            Description = "df12312dsf"
                        },
                        new PointOfInterestDto(){
                            Id = 2,
                            Name = "Central Park22",
                            Description = "df12312dsf34"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "New Born City",
                    Description = "Lorem ipsum",
                    PointOfInterest =  new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto(){
                            Id = 1,
                            Name = "Central Park3",
                            Description = "df12312dsf"
                        },
                        new PointOfInterestDto(){
                            Id = 2,
                            Name = "Central Park33",
                            Description = "df12312dsf34"
                        }
                    }
                }
            };
        }
    }
}