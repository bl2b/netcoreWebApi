using System.Collections.Generic;
using XYC.Models.Sample;

namespace XYC.Domain.Fakes
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
                    Description = "The one with the big park"
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Caloocan City",
                    Description = "The place wher so many kind people"
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "New Born City",
                    Description = "Lorem ipsum"
                }
            };
        }
    }
}