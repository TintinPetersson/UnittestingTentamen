using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeInformation;

namespace EmployeeTesting
{
    [TestClass]
    public class FirstNameTests
    {
        [TestMethod]
        [DataRow ("Tintin")]
        [DataRow("Jonathan")]
        [DataRow("Oscar")]
        public void FirstName_ValidTest(string firstName, string expected)
        {
            //Arrange + Act
            var employee = new Employee(firstName, "Petersson", );
            //Assert
            Assert.AreEqual(firstName, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstNameNullOrEmpty_InvalidTest()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FirstNameTooShort_InvalidTest()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FirstNameTooLong_InvalidTest()
        {

        }
    }
}
