using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XHomes.Data;
using XHomes.Dtos;
using XHomes.Models;

namespace XHomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customers : ControllerBase
    {
        private readonly ICustomerRepo repository;
        private readonly IMapper mapper;

        public Customers(ICustomerRepo repository, IMapper mapper )
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers() {

            var customers = repository.GetCustomers();

            return Ok(customers);
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(CustomerCreateDto customerCreateDto) {

            var customerModel = mapper.Map<Customer>(customerCreateDto);
            repository.CreateCustomer(customerModel);
            repository.SaveChanges();

            return Ok();

        }
    }
}
