using EmployeeInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeTesting
{
    [TestClass]
    public class PhoneNumberTests
    {
        [TestMethod]
        [DataRow("0706 - 79 35 79")]
        [DataRow("0706793579")]
        [DataRow("0706-793579")]
        [DataRow("0706 79 35 79")]
        public void PhoneNumber_Valid(string phoneNumber)
        {
            try
            {
                Employee employee = new Employee("Test", "Testing", new DateTime(1991, 03, 05), 
                                    new DateTime(1960, 05, 01), 34000, 2, phoneNumber, "employee@test.com");

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is AssertFailedException);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("abc103")]
        [DataRow("#¤=?_*:;&/()}{!")] //All special characters except '-' and whitespace will fail.
        [DataRow("0706-793579*")]
        [DataRow("HEJSAN")]
        [DataRow("0706+793579")]
        public void PhoneNumberLettersOrSpecialCharacters_Invalid(string phoneNumber)
        {
            Employee employee = new Employee("Test", "Testing", new DateTime(1991, 03, 05), 
                                new DateTime(1960, 05, 01), 34000, 2, phoneNumber, "employee@test.com");
        }
    }
}
