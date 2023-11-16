using DomainLayer.Data;
using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repo
{
    public class ReportRepo<T> : IReportRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public ReportRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByMonthAsync(string month)
        {
            return await _context.Set<T>().Where(x => EF.Property<string>(x, "SalaryMonth") == month).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.Set<T>().Where(x => EF.Property<int>(x, "EmployeeId") == employeeId).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> GetAllMonthsAsync()
        {
            // Assuming you have a property "SalaryMonth" in your T entity
            return await _context.Set<T>().Select(x => EF.Property<string>(x, "SalaryMonth")).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByMonthAndEmployeeAsync(string month, int employeeId)
        {
            return await _context.Set<T>().Where(x => EF.Property<string>(x, "SalaryMonth") == month && EF.Property<int>(x, "EmployeeId") == employeeId).ToListAsync();
        }
    }
}
