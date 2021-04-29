using EmployeeInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeTesting
{
    [TestClass]
    public class SalaryTests
    {
        [TestMethod]
        [DataRow(34100.20)]
        [DataRow(27060.12)]
        [DataRow(15325.29)]
        public void Salary_Valid(double salary)
        {
            try
            {
                Employee employee = new Employee("Test", "Testing", new DateTime(2019, 04, 05), 
                                    new DateTime(1995, 09, 12), salary, 2, "0706793579", "employee@test.com");

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is AssertFailedException);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(-12.22)]
        [DataRow(-1.2)]
        [DataRow(-12000.25)]
        public void SalaryTooSmall_Invalid(double salary)
        {
            Employee employee = new Employee("Test", "Testing", new DateTime(2019, 04, 05), 
                                new DateTime(1995, 09, 12), salary, 2, "0706793579", "employee@test.com");
        }
    }
}
