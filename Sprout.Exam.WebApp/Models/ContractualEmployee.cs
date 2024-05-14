using System;

namespace Sprout.Exam.WebApp.Models
{
    public class ContractualEmployee : BaseEmployee
    {
        public decimal DailyRate { get; set; }
        public decimal WorkDayCount { get; set; }
        public override decimal ComputeSalary()
        {
            decimal salary = DailyRate * WorkDayCount;
            return Math.Round(salary, 2);
        }
    }
}
