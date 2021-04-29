using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeInformation;

namespace EmployeeUnittesting.Unittests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        [DataRow("Test", "Testing", "2005-05-11","1985-03-12", 34530.30, 12.5, "0706793579", "test_testing@employee.com")]
        [DataRow("T", "Testsson", "1980-03-11", "1960-04-12", 90000.22, 27.3, "0706 - 79 35 79", "test.testing_@employee.com")]
        public void Constructor_Valid(string firstName, string lastName, string hireDate, string birthDate, 
                                        double salary, double bonus, string phoneNr, string email)
        {
            try
            {
                Employee employee = new Employee(firstName, lastName, DateTime.Parse(hireDate), DateTime.Parse(birthDate), 
                                                    salary, bonus, phoneNr, email);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is AssertFailedException);
            }
        }

        //[TestMethod]
        //[DataRow("", "Testing", "2005-05-11", "1985-03-12", 34530.30, 12.5, "0706793579", "test_testing@employee.com")] //FirstName
        //[DataRow("Test", "TestingLastNameTooLongForTest", "2005-05-11", "1985-03-12", 34530.30, 12.5, "0706793579", "test_testing@employee.com")]//LastName
        //[DataRow("Test", "Testing", "1940-05-11", "1920-03-12", 34530.30, 12.5, "0706793579", "test_testing@employee.com")]//Hiredate
        //[DataRow("Test", "Testing", "2005-05-11", "2022-03-12", 34530.30, 12.5, "0706793579", "test_testing@employee.com")]//BirthDate
        //[DataRow("Test", "Testing", "2005-05-11", "1985-03-12", -12000, 12.5, "0706793579", "test_testing@employee.com")]//Salary
        //[DataRow("Test", "Testing", "2005-05-11", "1985-03-12", 34530.30, 105, "0706793579", "test_testing@employee.com")]//Bonus
        //[DataRow("Test", "Testing", "2005-05-11", "1985-03-12", 34530.30, 105, "0706_793579", "test_testing@employee.com")]//PhoneNumber
        //[DataRow("Test", "Testing", "2005-05-11", "1985-03-12", 34530.30, 12.5, "0706793579", "test@testing@employee.com")]//Email
        //public void ConstructorPerProperty_Invalid(string firstName, string lastName, string hireDate, string birthDate,
        //                                double salary, double bonus, string phoneNr, string email)
        //{
        //        Employee employee = new Employee(firstName, lastName, DateTime.Parse(hireDate), DateTime.Parse(birthDate),
        //                                             salary, bonus, phoneNr, email);
        //}
    }
}
