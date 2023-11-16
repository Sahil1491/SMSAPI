using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class SalaryRecord : IEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string SalaryMonth { get; set; }
        public int Salary { get; set; }
        public int Leaves { get; set; }
        public int Deductions { get; set; }
        public int NetPay { get; set; }
        public Employee Employee { get; set; }
    }
}
