using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosedova.notebook
{
    class Manager : IComparable<Manager>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int yearOfBirth { get; set; }
        public string phoneNumber { get; set; }
        public string name_section { get; set; }
        public Manager (string LastName, string FirstName, int yearOfBirth, string phoneNumber, string name_section)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.yearOfBirth = yearOfBirth;
            this.phoneNumber = phoneNumber;
            this.name_section = name_section;
        }
        public Manager() { }

        public string GetInfo()
        {
            return LastName + " " + FirstName + " " 
                + yearOfBirth + " " + phoneNumber + " " + name_section;
        }
        public int CompareTo(Manager m)
        {
            if (String.Compare(this.LastName, m.LastName) >= 1)
                return 1;
            else if (String.Compare(this.LastName, m.LastName) <= 1)
                return -1;
            else
            {
                if (this.yearOfBirth > m.yearOfBirth)
                    return 1;
                else if (this.yearOfBirth < m.yearOfBirth)
                    return -1;
                else return 0;

            }
            
        }
    }
}
