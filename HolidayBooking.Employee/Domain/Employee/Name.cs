using System;
using System.Collections.Generic;
namespace HolidayBooking.Employee.Domain.Employee
{
    public class Name
    {
        public string ChristianName { get; private set; }
        public IEnumerable<String> MiddleNames { get; private set; }
        public string Surname { get; private set; }

        protected Name()
        {

        }

        public Name(String christianName, String surname)
        {
            ChristianName = christianName;
            Surname = surname;
        }

        public Name(string christianName, String surname, params String[] middlenames)
        {
            ChristianName = christianName;
            Surname = surname;
            MiddleNames = middlenames;
        }
    }
}