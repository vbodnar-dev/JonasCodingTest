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
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async Task<IHttpActionResult> GetAll()
        {
            var items = await _companyService.GetAllCompanies();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CompanyDto>>(items));
        }

        // GET api/<controller>/5
        public async Task<IHttpActionResult> Get(string companyCode)
        {
            var item = await _companyService.GetCompanyByCode(companyCode);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CompanyDto>(item));
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody]string value)
        {
            var result = await _companyService.UpdateOrInsert(value);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        // PUT api/<controller>/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]string value)
        {
            var result = await _companyService.UpdateOrInsert(value, id);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        // DELETE api/<controller>/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await _companyService.Delete(id);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}