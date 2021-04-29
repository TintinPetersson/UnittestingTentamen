using System;
using System.Text.RegularExpressions;

namespace EmployeeInformation
{
    public class Employee
    {
        private string firstName;
        private string lastName;
        private DateTime hireDate;
        private DateTime birthDate;
        private double salary;
        private double bonus;
        private string phoneNr;
        private string email;

        public string FirstName {get => firstName; 
            set
            {
                if (value.Length <= 15 && !String.IsNullOrEmpty(value)) firstName = value;
                else if (String.IsNullOrEmpty(value)) throw new ArgumentNullException("Name cannot be empty");
                else throw new ArgumentOutOfRangeException("Name cannot be more than 15 letters");
            }
        } //Max 15 tecken
        public string LastName { get => lastName;
            set
            {
                if (value.Length <= 20 && !String.IsNullOrEmpty(value)) lastName = value;
                else if (String.IsNullOrEmpty(value)) throw new ArgumentNullException("Name cannot be null or empty");
                else throw new ArgumentOutOfRangeException("Name cannot be longer than 20 letters");
            }
        } //Max 20 tecken
        public DateTime HireDate { get => hireDate;
            set 
            {
                if (value <= DateTime.Now && value >= DateTime.Now.AddYears(-70)) hireDate = value; 
                else throw new ArgumentOutOfRangeException("Date of employment can't be in the future or more than 70 years back."); 
                
            }
        } //Inte framtiden, max 70 år tbx
        public DateTime BirthDate { get => birthDate;
            set
            {
                if (value <= DateTime.Now) birthDate = value;
                else throw new ArgumentOutOfRangeException("Birthdate cannot be in the future");
            }
        } //Inte framtiden
        public double Salary{ get => salary;
            set
            {
                if (value >= 0) salary = value;
                else throw new ArgumentOutOfRangeException("Salary cannot be less than 0");
            }
        } //Deciamltal, inte negativt
        public double Bonus{ get => bonus;
            set
            {
                if (value <= 100 && value >= 0) { bonus = (value / 100) * Salary; bonus = Math.Round(bonus); }
                else throw new ArgumentOutOfRangeException("Bonus procent cannot be smaller than 0% nor larger than 100%");
            }
        } //Heltal, procent på lönen
        public string PhoneNr{ get => phoneNr;
            set
            {
                if (Regex.IsMatch(value, @"^[0-9\s-]*$")) phoneNr = value;
                else throw new ArgumentException("Can only be numbers, whitespace and '-'");
            }
        } //Endast siffror, streck och mellanslag
        public string Email{ get => email;
            set
            {
                int counter = 0;
                value = value.Trim();

                if (!value.Contains(' ') && value.Contains('.'))
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] == '@')
                        {
                            counter+= 1;
                        }
                    }
                    if (counter == 1) email = value;
                    else throw new ArgumentException("Can only have one @");
                }
                else throw new ArgumentException("Email must have at least one '.' and no whitespace");
            }
        } //Ingen whitespace. Innehåller @ och minst 1 punkt.


        public Employee(string firstName, string lastName, DateTime hireDate, DateTime birthDate,
                        double salary, double bonus, string phoneNr, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            HireDate = hireDate;
            BirthDate = birthDate;
            Salary = salary;
            Bonus = bonus;
            PhoneNr = phoneNr;
            Email = email;
        }
    }
}
