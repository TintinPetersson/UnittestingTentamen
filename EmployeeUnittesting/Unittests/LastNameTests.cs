using EmployeeInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeTesting
{
    [TestClass]
    public class LastNameTests
    {
        [TestMethod]
        [DataRow("Hult")]
        [DataRow("Petersson")]
        [DataRow("Långtefternamn")]
        public void LastName_Valid(string lastName)
        {
            try
            {
                Employee employee = new Employee("Test", lastName, new DateTime(1991, 03, 05), 
                                    new DateTime(1960, 05, 01), 34000, 2, "0706793579", "employee@test.com");

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is AssertFailedException);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow("")]
        public void LastNameNullOrEmpty_Invalid(string lastName)
        {
            Employee employee = new Employee("Test", lastName, new DateTime(1991, 03, 05), 
                                new DateTime(1960, 05, 01), 34000, 2, "0706793579", "employee@test.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("JättelångtEfternamnSomSkaFaila")]
        public void LastNameTooLong_Invalid(string lastName)
        {
            Employee employee = new Employee("Test", lastName, new DateTime(1991, 03, 05), 
                                new DateTime(1960, 05, 01), 34000, 2, "0706793579", "employee@test.com");
        }
    }
}
