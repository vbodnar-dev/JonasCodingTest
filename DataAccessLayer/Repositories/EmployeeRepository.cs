using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbWrapper<Employee> _employeeDbWrapper;
        public EmployeeRepository(IDbWrapper<Employee> employeeDbWrapper)
        {
            _employeeDbWrapper = employeeDbWrapper;
        }

        public async Task<bool> Delete(int id)
        {
            return await _employeeDbWrapper.DeleteAsync(x => x.SiteId == id.ToString());
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeDbWrapper.FindAllAsync();
        }

        public async Task<Employee> GetByCode(string companyCode)
        {
            var item = await _employeeDbWrapper.FindAsync(t => t.CompanyCode.Equals(companyCode));
            return item.FirstOrDefault();
        }

        public async Task<bool> Save(Employee employee)
        {
            var item = await _employeeDbWrapper.FindAsync(t =>
                t.SiteId.Equals(employee.SiteId) && t.CompanyCode.Equals(employee.CompanyCode));
            var itemRepo = item?.FirstOrDefault();
            if (itemRepo != null)
            {
                itemRepo.EmployeeCode = employee.EmployeeCode;
                itemRepo.EmployeeName = employee.EmployeeName;
                itemRepo.Occupation = employee.Occupation;
                itemRepo.EmployeeStatus = employee.EmployeeStatus;
                itemRepo.EmailAddress = employee.EmailAddress;
                itemRepo.Phone = employee.Phone;
                itemRepo.LastModified = employee.LastModified;
                return await _employeeDbWrapper.UpdateAsync(itemRepo);
            }

            return await _employeeDbWrapper.InsertAsync(employee);
        }
    }
}
