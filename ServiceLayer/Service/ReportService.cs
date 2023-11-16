using DomainLayer.Model;
using RepositoryLayer.IRepo;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepo<Employee> _employeeRepository;
        private readonly IReportRepo<SalaryRecord> _salaryRecordRepository;

        public ReportService(IReportRepo<Employee> employeeRepository, IReportRepo<SalaryRecord> salaryRecordRepository)
        {
            _employeeRepository = employeeRepository;
            _salaryRecordRepository = salaryRecordRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<IEnumerable<SalaryRecord>> GetEmployeeDetailsAsync(int employeeId)
        {
            return await _salaryRecordRepository.GetByEmployeeIdAsync(employeeId);
        }

        public async Task<IEnumerable<SalaryRecord>> GetSalaryRecordsByMonthAsync(string month)
        {
            return await _salaryRecordRepository.GetByMonthAsync(month);
        }

        public async Task<bool> AddSalaryRecordAsync(SalaryRecord salaryRecord)
        {
            try
            {
                await _salaryRecordRepository.AddAsync(salaryRecord);
                await _salaryRecordRepository.SaveChangesAsync();
                return true;
            }
            catch
            {
                // Handle exceptions
                return false;
            }
        }
        public async Task<IEnumerable<string>> GetAllMonthsAsync()
        {
            return await _salaryRecordRepository.GetAllMonthsAsync();
        }


        public async Task<IEnumerable<SalaryRecord>> GetSalaryRecordsByMonthAndEmployeeAsync(string month, int employeeId)
        {
            return await _salaryRecordRepository.GetByMonthAndEmployeeAsync(month, employeeId);
        }
    }
}
