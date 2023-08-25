using EMS.Controllers;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace TestEMS
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var model = new SalaryCalculatorDTO { BasicSalary = 50000 };
            var controller = new SalaryCalculationController();

            // Act
            var result = controller.CalculateGrossSalary(model);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(55000, result); // Assuming allowance = 0.2 * BasicSalary and deductions = 0.1 * BasicSalary
        }

        [Theory]
        [InlineData(1000, 1200)] // For a basic salary of $1000, the gross salary should be $1200
        [InlineData(2000, 2400)] // For a basic salary of $2000, the gross salary should be $2400
        public void CalculateGrossSalary_ShouldCalculateCorrectly(decimal basicSalary, decimal expectedGrossSalary)
        {
            // Arrange
            var controller = new SalaryCalculationController();

            // Act
            var result = controller.CalculateGrossSalaryCorrect(basicSalary);
            
            // Assert
            Assert.Equal(expectedGrossSalary, result);
        }
    }
}