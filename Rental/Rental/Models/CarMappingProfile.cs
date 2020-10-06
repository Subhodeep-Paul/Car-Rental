using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental.DTO;

namespace Rental.Models
{
    
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            _ = CreateMap<CarForAddDto, Car>()
                .ForMember(dest => dest.A_DISTANCE_DRIVEN, opt => opt.MapFrom(src => src.Distance))
                .ForMember(dest => dest.A_FUEL_TYPE, opt => opt.MapFrom(src => src.Fuel))
                .ForMember(dest => dest.A_NUMBER_OF_SEATS, opt => opt.MapFrom(src => src.Seats))
                .ForMember(dest => dest.A_MODEL, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.A_IS_AVAILABLE, opt => opt.MapFrom(src => src.Available))
                .ForMember(dest => dest.A_COMPANY, opt => opt.MapFrom(src => src.Company))
                .ForMember(dest => dest.A_TRANSMISSION, opt => opt.MapFrom(src => src.Transmission))
                .ForMember(dest => dest.A_PRICE, opt => opt.MapFrom(src => src.price))
                .ReverseMap();
        }
    }
}
