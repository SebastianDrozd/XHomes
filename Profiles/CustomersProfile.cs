using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using XHomes.Dtos;
using XHomes.Models;

namespace XHomes.Profiles
{
    public class CustomersProfile : Profile {

        public CustomersProfile()
        {
            //source --> destination
            CreateMap<CustomerCreateDto, Customer>();
        }
    
    
    }
    
}
