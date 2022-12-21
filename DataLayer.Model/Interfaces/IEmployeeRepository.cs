using DataAccessLayer.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetByCode(string companyCode);
        Task<bool> Save(Employee company);
        Task<bool> Delete(int id);
    }
}
