using Moq;
using Sprout.Exam.Core.Interface;
using Sprout.Exam.WebApp.Controllers;


namespace Sprout.Exam.UnitTest
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IEmployeeService> _mockService;
        private readonly EmployeeController _controller;

        public EmployeeControllerTests()
        {
            _mockService = new Mock<IEmployeeService>();
         //   _controller = new EmployeeController(_mockService.Object);
        }
    }
}
