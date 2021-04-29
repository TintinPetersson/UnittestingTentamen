using EmployeeInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeTesting
{
    [TestClass]
    public class EmailAddressTests
    {
        [DataTestMethod]
        [DataRow("tpsson_95@gmail.com")]
        [DataRow("tpsson.95@gmail.com")]
        [DataRow(" tpss/on95@gmail.com")]
        [DataRow(".tpsson.95@gmail.com ")]
        public void EmailAddress_Valid(string emailAddress)
        {
            try
            {
                Employee employee = new Employee("Test", "Testing", new DateTime(1991, 03, 05), 
                                    new DateTime(1960, 05, 01), 34000, 2, "0706793579", emailAddress);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is AssertFailedException);
            }
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("tpsson95gmail.com")]
        [DataRow("tpsson95@gmailcom")]
        [DataRow("tpsson95gmailcom")]
        public void EmailAddressWithNoDotOrAtSign_Invalid(string emailAddress)
        {
            Employee employee = new Employee("Test", "Testing", new DateTime(1991, 03, 05), 
                                new DateTime(1960, 05, 01), 34000, 2, "0706793579", emailAddress);
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("@tpsson95@gmail.com")]
        [DataRow("tpsson95 @gmail.com")]
        [DataRow("tpsson95 gmailcom")]
        public void EmailAddressWithWhitespaceOrMultipleAtSigns_Invalid(string emailAddress)
        {
            Employee employee = new Employee("Test", "Testing", new DateTime(1991, 03, 05), 
                                new DateTime(1960, 05, 01), 34000, 2, "0706793579", emailAddress);
        }
    }
}
