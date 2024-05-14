using System;

namespace Sprout.Exam.WebApp.Models
{
    public class RegularEmployee : BaseEmployee
    {
        public decimal MonthlySalary { get; set; }
        public decimal AbsentCount { get; set; }
        public decimal TaxRate { get; set; }

        public override decimal ComputeSalary()
        {
            decimal dailyRate = MonthlySalary / 22;
            decimal salary = MonthlySalary - (MonthlySalary * (TaxRate / 100));
            salary = salary - (AbsentCount * dailyRate);
            return Math.Round(salary, 2);
        }
    }
}
