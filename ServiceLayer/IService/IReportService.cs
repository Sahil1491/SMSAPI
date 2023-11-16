using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IService
{
    public interface IReportService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<IEnumerable<SalaryRecord>> GetEmployeeDetailsAsync(int employeeId);
        Task<IEnumerable<SalaryRecord>> GetSalaryRecordsByMonthAsync(string month);
        Task<bool> AddSalaryRecordAsync(SalaryRecord salaryRecord);

        Task<IEnumerable<string>> GetAllMonthsAsync();

        Task<IEnumerable<SalaryRecord>> GetSalaryRecordsByMonthAndEmployeeAsync(string month, int employeeId);
    }
}
