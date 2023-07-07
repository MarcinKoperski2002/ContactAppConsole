using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppConsole
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string email;

        private readonly int id;
        private DateTime dateOfBirth;
        private string phoneNumber;

        public Person(string FirstName, string LastName, string Email, int ID, DateTime DateOfBirth, string PhoneNumber)
        {
            firstName = FirstName;
            lastName = LastName;
            email = Email;
            id = ID;
            dateOfBirth = DateOfBirth;
            phoneNumber = PhoneNumber;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int ID
        {
            get { return id; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
    }
}