using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeInformation;

namespace EmployeeTesting
{
    [TestClass]
    public class FirstNameTests
    {
        Employee emp1 = new Employee("Sven", "TheGray", new DateTime(1995, 11, 22), new DateTime(1970, 5, 02), 32000.22, 12.3, "0700123456", "ganfalf.grå@middleEarth.com");
        Employee emp2 = new Employee("Steve", "Hult", new DateTime(2011, 03, 06), new DateTime(1999, 07, 01), 24030.33, 5.1, "031-22 55 99", "kallegurra_cool@employee.com");
        Employee emp3 = new Employee("Sten", "Hultsson", new DateTime(2020, 03, 09), new DateTime(2009, 03, 02), 24030.33, 5.1, "031-22 55 98", "kallegurra_2nd@employee.com");

        [TestMethod]
        //Försöker i dessa metoder att använda 3 instanser av employees istället för en med flera datarows. Föredrar dock 1 instance m. datarows.
        #region
        public void FirstNameThreeInstancesOfEmployees_Valid()
        {
            try
            {
                emp1.FirstName = "Hejsvejs";
                emp2.FirstName = "Tintin2nd";
                emp3.FirstName = "Femtonbokstäver";

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is AssertFailedException);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FirstNameThreeInstancesOutOfRange_Invalid()
        {
            emp1.FirstName = "FörmångaBokstäverFörTestet";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstNameThreeInstancesEmpty_Invalid()
        {
            emp2.FirstName = "";
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void FirstNameThreeInstancesNull_Invalid()
        {
            emp3.FirstName = null;
        }
        #endregion


        //Tillbaka till datarows och 1 instance
        [TestMethod]
        [DataRow("Kallegurra")]
        [DataRow("Nisse")]
        [DataRow("Dumbledore")]
        public void FirstName_Valid(string firstName)
        {
            try
            {
                Employee employee = new Employee(firstName, "Testing", new DateTime(1991, 03, 05), 
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
        public void FirstNameNullOrEmpty_Invalid(string firstName)
        {
            Employee employee = new Employee(firstName, "Testing", new DateTime(1991, 03, 05), 
                                new DateTime(1960, 05, 01), 34000, 2, "0706793579", "employee@test.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("KallegurraNissehult")]
        [DataRow("GandalfVSDumbledore")]
        public void FirstNameTooLong_Invalid(string firstName)
        {
            Employee employee = new Employee(firstName, "Testing", new DateTime(1991, 03, 05),
                                new DateTime(1960, 05, 01), 34000, 2, "0706793579", "employee@test.com");
        }
    }
}
