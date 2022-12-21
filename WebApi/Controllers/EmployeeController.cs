using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: Employee
        public async Task<IHttpActionResult> GetAll()
        {
            var items = await _employeeService.GetAll();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(items));
        }
    }
}