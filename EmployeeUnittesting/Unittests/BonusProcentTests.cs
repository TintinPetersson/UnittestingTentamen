using EmployeeInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeTesting
{
    [TestClass]
    public class BonusProcentTests
    {
        [DataTestMethod]
        [DataRow(8, 1876)]
        [DataRow(45, 10555)]
        [DataRow(62, 14543)]
        public void BonusProcent_Valid(double bonusProcent, double expected)
        {
            //Arrange + Act
            Employee employee = new Employee("Test", "Testing", new DateTime(2019, 04, 05), 
                                new DateTime(1995, 09, 12), 23456, bonusProcent, "0706793579", "employee@test.com");

            double actual = employee.Bonus;

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [DataTestMethod]
        [DataRow(25, 2501)]
        [DataRow(50, 4999)]
        [DataRow(3, 301)]
        public void BonusProcent_Invalid(double bonusProcent, double expected)
        {
            //Arrange + Act
            Employee employee = new Employee("Test", "Testing", new DateTime(2019, 04, 05), 
                                new DateTime(1995, 09, 12), 10000, bonusProcent, "0706793579", "employee@test.com");

            double actual = employee.Bonus;

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(101)]
        [DataRow(-50.3)]
        [DataRow(-1)]
        [DataRow(150.25)]
        public void BonusProcentAbove100OrBelow0_Invalid(double bonusProcent)
        {
            Employee employee = new Employee("Test", "Testing", new DateTime(2019, 04, 05), 
                                new DateTime(1995, 09, 12), 10000, bonusProcent, "0706793579", "employee@test.com");
        }
    }
}
