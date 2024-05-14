using Microsoft.AspNetCore.Mvc;
using Moq;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Core.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.UnitTestControllers
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IEmployeeService> _mockService;
        private readonly EmployeeController _controller;

        public EmployeeControllerTests()
        {
            _mockService = new Mock<IEmployeeService>();
            _controller = new EmployeeController(_mockService.Object);
        }

        [Fact]
        public async Task Get_ReturnsAllEmployees()
        {
            var mockEmployees = new List<EmployeeDto> {
                    new EmployeeDto { Id = 1, FullName = "Test Employee" }
                };

            _mockService.Setup(x => x.GetAll()).ReturnsAsync(mockEmployees);

            var result = await _controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<EmployeeDto>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetById_ReturnsEmployee_WhenEmployeeExists()
        {
            var employee = new EmployeeDto { Id = 1, FullName = "Existing Employee" };
            _mockService.Setup(x => x.GetById(1)).ReturnsAsync(employee);

            var result = await _controller.GetById(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(employee, okResult.Value);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenEmployeeDoesNotExist()
        {
            _mockService.Setup(x => x.GetById(1)).ReturnsAsync((EmployeeDto)null);

            var result = await _controller.GetById(1);

            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public async Task Put_ReturnsUpdatedEmployee_WhenDataIsValid()
        {
            var editDto = new EditEmployeeDto { Id = 1, FullName = "Updated Employee" };
            Moq.Language.Flow.IReturnsResult<IEmployeeService> returnsResult = _mockService.Setup(x => x.Update(editDto)).ReturnsAsync(new EmployeeDto(editDto));

            var result = await _controller.Put(editDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(returnsResult, okResult.Value);
        }

        [Fact]
        public async Task Put_ReturnsBadRequest_WhenDataIsInvalid()
        {
            _controller.ModelState.AddModelError("Name", "Required");

            var result = await _controller.Put(new EditEmployeeDto());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_CreatesEmployee_WhenDataIsValid()
        {
            var createDto = new CreateEmployeeDto { FullName = "New Employee" };
            _mockService.Setup(x => x.Create(createDto)).ReturnsAsync(1); // Assuming 1 is the returned ID

            var result = await _controller.Post(createDto);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal($"/api/employee/1", createdResult.ActionName);
        }

        [Fact]
        public async Task Post_ReturnsBadRequest_WhenDataIsInvalid()
        {
            _controller.ModelState.AddModelError("Name", "Required");

            var result = await _controller.Post(new CreateEmployeeDto());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DeletesEmployee()
        {
            _mockService.Setup(x => x.Delete(1)).ReturnsAsync(1);

            var result = await _controller.Delete(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(1, okResult.Value);
        }


    }
}
