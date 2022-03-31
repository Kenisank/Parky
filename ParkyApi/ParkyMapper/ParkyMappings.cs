using AutoMapper;
using ParkyApi.Models;
using ParkyApi.Models.DTOs;

namespace ParkyApi.ParkyMapper
{
    public class ParkyMappings:Profile
    {

        public ParkyMappings()
        {
            CreateMap<NationalParks, NationalParkDto>().ReverseMap();
        }

    }
}
