using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using XHomes.Dtos;
using XHomes.Models;

namespace XHomes.Profiles
{
    public class EstimatesProfile : Profile
    {
        public EstimatesProfile()
        {
            CreateMap<Estimate, EstimateReadDto>();
        }
        
    }
}
