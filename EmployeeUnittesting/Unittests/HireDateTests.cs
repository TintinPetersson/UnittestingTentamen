using EmployeeInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeTesting
{
    [TestClass]
    public class HireDateTests
    {
        [TestMethod]
        [DataRow(1991, 03, 05)]
        [DataRow(2001, 09, 12)]
        [DataRow(1970, 01, 02)]
        [DataRow(1951, 11, 03)]
        [DataRow(1995, 09, 25)]
        public void HireDate_Valid(int year, int month, int day)
        {
            try
            {
                Employee employee = new Employee("Test", "Testing", new DateTime(year, month, day), 
                                    new DateTime(1960, 05, 01), 34000, 2, "0706793579", "employee@test.com");

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is AssertFailedException);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(1855, 03, 05)]
        [DataRow(1948, 09, 12)]
        [DataRow(1951, 01, 02)]
        public void HireDateTooEarly_Invalid(int year, int month, int day)
        {
            Employee employee = new Employee("Test", "Testing", new DateTime(year, month, day), 
                                new DateTime(1960, 05, 01), 34000, 2, "0706793579", "employee@test.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow (2021, 06, 25)]
        [DataRow(2022, 04, 05)]
        [DataRow(2025, 02, 01)]
        public void HireDateFuture_Invalid(int year, int month, int day)
        {
            Employee employee = new Employee("Test", "Testing", new DateTime(year, month, day), 
                                new DateTime(1960, 05, 01), 34000, 2, "0706793579", "employee@test.com");
        }
    }
}
