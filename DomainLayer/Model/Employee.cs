using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        
        public ICollection<SalaryRecord> SalaryRecords { get; set; }
    }
}
