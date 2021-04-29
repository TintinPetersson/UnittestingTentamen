using EmployeeInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeTesting
{
    [TestClass]
    public class ConstructorTests
    {
        [DataTestMethod]
        [DataRow(1991, 03, 05)]
        [DataRow(2001, 09, 12)]
        [DataRow(1970, 01, 02)]
        [DataRow(1951, 11, 03)]
        [DataRow(1995, 09, 25)]
        public void BirthDate_Valid(int year, int month, int day)
        {
            try
            {
                Employee employee = new Employee("Test", "Testing", new DateTime(2019, 04, 05), 
                                    new DateTime(year, month, day), 34000, 2, "0706793579", "employee@test.com");

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is AssertFailedException);
            }
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(2021, 06, 25)]
        [DataRow(2022, 04, 05)]
        [DataRow(2025, 02, 01)]
        public void BirthDateFuture_Invalid(int year, int month, int day)
        {
            Employee employee = new Employee("Test", "Testing", new DateTime(2019, 04, 05), 
                                new DateTime(year, month, day), 34000, 2, "0706793579", "employee@test.com");
        }
    }
}
