using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosedova.notebook
{
    class Employee: IComparable<Employee>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int yearOfBirth { get; set; }
        public string phoneNumber { get; set; }
        public string manager { get; set; }
        public Employee(string LastName, string FirstName, int yearOfBirth, string phoneNumber, string manager)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.yearOfBirth = yearOfBirth;
            this.phoneNumber = phoneNumber;
            this.manager = manager;
        }
        public Employee() { }
        public string GetInfo()
        {
            return LastName + " " + FirstName + " "
                + yearOfBirth + " " + phoneNumber + " " + manager;
        }
        public int CompareTo(Employee e)
        {
            if (String.Compare(this.LastName, e.LastName) >= 1)
                return 1;
            else if (String.Compare(this.LastName, e.LastName) <= 1)
                return -1;
            else
            {
                if (this.yearOfBirth > e.yearOfBirth)
                    return 1;
                else if (this.yearOfBirth < e.yearOfBirth)
                    return -1;
                else return 0;

            }

        }
    }
}
