using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Sprout.Exam.WebApp.Controllers;
using Sprout.Exam.Core.Interface;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using System.Threading.Tasks;

public class PayrollControllerTests
{
    private readonly Mock<IEmployeeService> _mockEmployeeService;
    private readonly PayrollController _controller;

    public PayrollControllerTests()
    {
        _mockEmployeeService = new Mock<IEmployeeService>();
        _controller = new PayrollController(_mockEmployeeService.Object);
    }

    [Fact]
    public async Task Calculate_ReturnsNotFound_WhenEmployeeDoesNotExist()
    {
        var computeSalaryDto = new ComputeSalaryDto { Id = 1 };
        _mockEmployeeService.Setup(x => x.GetById(1)).ReturnsAsync((EmployeeDto)null);

        var result = await _controller.Calculate(computeSalaryDto);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Calculate_ReturnsCorrectSalaryForRegularEmployee()
    {
        var computeSalaryDto = new ComputeSalaryDto { Id = 1, NoOfDays = 2 };
        var employeeDto = new EmployeeDto { Id = 1, TypeId = (int)EmployeeType.Regular };

        _mockEmployeeService.Setup(x => x.GetById(1)).ReturnsAsync(employeeDto);

        var result = await _controller.Calculate(computeSalaryDto);

        var okResult = Assert.IsType<OkObjectResult>(result);
        // Assuming RegularEmployee's ComputeSalary method calculates correctly; here we use a sample expected value.
        Assert.Equal(17600, okResult.Value); // Assuming the salary calculation is correct and implemented.
    }

    [Fact]
    public async Task Calculate_ReturnsCorrectSalaryForContractualEmployee()
    {
        var computeSalaryDto = new ComputeSalaryDto { Id = 2, NoOfDays = 15 };
        var employeeDto = new EmployeeDto { Id = 2, TypeId = (int)EmployeeType.Contractual };

        _mockEmployeeService.Setup(x => x.GetById(2)).ReturnsAsync(employeeDto);

        var result = await _controller.Calculate(computeSalaryDto);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(7500, okResult.Value); // Assuming the salary for 15 days at a daily rate of 500.
    }

}
