using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using System.Threading.Tasks;
using DataAccessLayer.Model.Models;
using Newtonsoft.Json;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyInfo>> GetAllCompanies()
        {
            var res = await _companyRepository.GetAll();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public async Task<CompanyInfo> GetCompanyByCode(string companyCode)
        {
            var result = await _companyRepository.GetByCode(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }

        public async Task<bool> UpdateOrInsert(string jsonString, int? id = null)
        {
            var companyInfo = JsonConvert.DeserializeObject<CompanyInfo>(jsonString);
            var company = _mapper.Map<Company>(companyInfo);
            if (id.HasValue)
            {
                company.SiteId = id.ToString();
            }
            return await _companyRepository.SaveCompany(company);
        }

        public async Task<bool> Delete(int id)
        {
            return await _companyRepository.Delete(id);
        }
    }
}
