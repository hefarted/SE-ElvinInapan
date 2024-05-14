using Sprout.Exam.Infrastructure.Models;
using System.Threading.Tasks;

namespace Sprout.Exam.Core.Interface
{
    public interface IEmployeeTypeService
    {
        Task<EmployeeType> Get(int id);
    }
}
