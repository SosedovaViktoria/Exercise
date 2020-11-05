using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Sosedova.notebook
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>(); //creating a list for recording manager
            List<Manager> managers = new List<Manager>(); //creating a list for recording employee
            using (StreamReader read_manager = new StreamReader(@"../../Managers.txt")) //it reads the file "Managers"
            {
                using (StreamReader read_employee = new StreamReader(@"../../Employees.txt"))//it reads the file "Employees"
                {
                    string line1, line2;
                    while ((line1 = read_manager.ReadLine()) != null)//until the end of the file "Managers", write from the file
                    {
                        Console.WriteLine(line1);
                        string[] words = line1.Split(' ');
                        managers.Add(new Manager()
                        {
                            LastName = words[0],
                            FirstName = words[1],
                            yearOfBirth = int.Parse(words[2]),
                            phoneNumber = words[3],
                            name_section = words[4]
                        });
                    }
                    Console.WriteLine();
                    while ((line2 = read_employee.ReadLine()) != null)//until the end of the file "Employees", write from the file
                    {

                        Console.WriteLine(line2);
                        string[] words = line2.Split(' ');
                        employees.Add(new Employee()
                        {
                            LastName = words[0],
                            FirstName = words[1],
                            yearOfBirth = int.Parse(words[2]),
                            phoneNumber = words[3],
                            manager = words[4]
                        });
                    }
                }
            }


            bool exit_flag = false;
             while (exit_flag == false)
             {
                 Console.WriteLine("\n=================================================");
                 Console.WriteLine("Select the action - ");
                 Console.WriteLine("1 - Add an employee record");
                 Console.WriteLine("2 - Add an manager record");
                 Console.WriteLine("3 - Delete an employee record ");
                 Console.WriteLine("4 - Delete an manager record ");
                 Console.WriteLine("5 - Search by employee's last name");
                 Console.WriteLine("6 - Search by employee's first name ");
                 Console.WriteLine("7 - Search by employee's phone number");
                 Console.WriteLine("8 - Search by manager's last name");
                 Console.WriteLine("9 - Search by manager's first name");
                 Console.WriteLine("10 - Search by manager's phone number");
                 Console.WriteLine("11 - Sort by manager's last name and phone number");
                 Console.WriteLine("12 - Sort by employee's last name and phone number");
                 Console.WriteLine("0 - Program exit");
                 Console.WriteLine("=================================================");
                 switch (Console.ReadLine())
                 {
                     case "1": Add_employ(employees); break;
                     case "2": Add_manag(managers); break;
                     case "3": Delete_employ(employees); break;
                     case "4": Delete_manag(managers, employees); break;
                     case "5": Console.WriteLine(Search_employ_Ln(employees).GetInfo()); break;
                     case "6": Console.WriteLine(Search_employ_Fn(employees).GetInfo()); break;
                     case "7": Console.WriteLine(Search_employ_Pn(employees).GetInfo()); break;
                     case "8": Console.WriteLine(Search_manag_Ln(managers).GetInfo()); break;
                     case "9": Console.WriteLine(Search_manag_Fn(managers).GetInfo()); break;
                     case "10": Console.WriteLine(Search_manag_Pn(managers).GetInfo()); break;
                     case "11": managers.Sort();
                        foreach (var item in managers)
                        {
                            Console.WriteLine(item.GetInfo());
                        }
                        break;
                     case "12": employees.Sort();
                        foreach (var item in employees)
                        {
                            Console.WriteLine(item.GetInfo());
                        }
                        break;
                     case "0": exit_flag = true; break;
                     default:
                         break;
                 }

             }

            using (StreamWriter write_employee = new StreamWriter(@"../../Employees.txt"))//writing to a file "Employees"
            {
                using (StreamWriter write_manager = new StreamWriter(@"../../Managers.txt"))//writing to a file "Managers"
                {

                    for (int i = 0; i <= managers.Count - 1; i++)
                    {
                        write_manager.WriteLine(managers[i].GetInfo());
                    }
                    for (int i = 0; i <= employees.Count - 1; i++)
                    {
                        write_employee.WriteLine(employees[i].GetInfo());
                    }
                }
            }


            Console.ReadKey();
        }

        public static void Add_employ(List<Employee> employees)//Add an employee record
        {
            string[] words = Console.ReadLine().Split(' ');
            if (int.Parse(words[2]) > 1940 && (int.Parse(words[2]) < 2020))//Condition for the correct year of birth 
            {
                employees.Add(new Employee()
                {
                    LastName = words[0],
                    FirstName = words[1],
                    yearOfBirth = int.Parse(words[2]),
                    phoneNumber = words[3],
                    manager = words[4]
                });
            }
            else
            {
                Console.WriteLine("Year entered incorrectly");
            }
        }
        public static void Add_manag(List<Manager> managers)//Add an manager record
        {
            string[] words = Console.ReadLine().Split(' ');
            if (int.Parse(words[2]) > 1940 && (int.Parse(words[2]) < 2020))//Condition for the correct year of birth 
            {
                managers.Add(new Manager()
                {
                LastName = words[0],
                FirstName = words[1],
                yearOfBirth = int.Parse(words[2]),
                phoneNumber = words[3],
                name_section = words[4]
                 });
            }
            else
            {
               Console.WriteLine("Year entered incorrectly");
            }
        }
        public static void Delete_employ(List<Employee> employees)//Delete an employee record
        {
            string LastName = Console.ReadLine();
            employees.Remove(employees.Find(employee => employee.LastName == LastName));//Deleting using a linq query
        }
        public static void Delete_manag(List<Manager> managers, List<Employee> employees)
        {
            string LastName = Console.ReadLine();

            if(employees.FindAll(employee => employee.manager == LastName).Count == 0)//If the ьanager has no employees, then delete it
            {
                managers.Remove(managers.Find(manager => manager.LastName == LastName));//Deleting using a linq query
            }
            else
            {
                foreach (var item in managers)//output all existing managers
                {
                    Console.Write(item.LastName + " ");
                }
                Console.WriteLine("Manager found! Enter another Manager");
                string newManager = Console.ReadLine();//You need to enter an existing one

                if(managers.Find(manager => manager.LastName == newManager) == null)//Checks if it exists
                {
                    Console.WriteLine("The Manager doesn't exist!");
                    return ;
                }

                foreach(var employee_item in employees.FindAll(employee => employee.manager == newManager))//to determine the employee's new Manager
                {
                    employee_item.manager = newManager;
                }

                managers.Remove(managers.Find(manager => manager.LastName == LastName));////Deleting using a linq query
            }
        }
        public static Employee Search_employ_Ln(List<Employee> employees)//Search by employee's last name
        {
            string LastName = Console.ReadLine();
            Employee employee = employees.Find(e_Ln => e_Ln.LastName == LastName);
            if (employee == null)
            {
                Console.WriteLine("Mistake");
                return null;
            }
            return employee;
        }
        public static Employee Search_employ_Fn(List<Employee> employees)//Search by employee's first name
        {
            string FirstName = Console.ReadLine();
            Employee employee = employees.Find(e_Fn => e_Fn.FirstName == FirstName);
            if (employee == null)
            {
                Console.WriteLine("Mistake");
                return null;
            }
            return employee;
        }
        public static Employee Search_employ_Pn(List<Employee> employees)// Search by employee's phone number
        {
            string phoneNumber = Console.ReadLine();
            Employee employee = employees.Find(e_Pn => e_Pn.phoneNumber == phoneNumber);
            if(employee == null)
            {
                Console.WriteLine("Mistake");
                return null;
            }
            return employee;
        }

        public static Manager Search_manag_Ln(List<Manager> managers)// Search by manager's last name
        {
            string LastName = Console.ReadLine();
            Manager manager = managers.Find(m_Ln => m_Ln.LastName == LastName);
            if (manager == null)
            {
                Console.WriteLine("Mistake");
                return null;
            }
            return manager;
        }
        public static Manager Search_manag_Fn(List<Manager> managers)// Search by manager's first name
        {
            string FirstName = Console.ReadLine();
            Manager manager = managers.Find(m_Fn => m_Fn.FirstName == FirstName);
            if (manager == null)
            {
                Console.WriteLine("Mistake");
                return null;
            }
            return manager;
        }
        public static Manager Search_manag_Pn(List<Manager> managers)//Search by manager's phone number
        {
            string phoneNumber = Console.ReadLine();
            Manager manager = managers.Find(m_Pn => m_Pn.phoneNumber == phoneNumber);
            if (manager == null)
            {
                Console.WriteLine("Mistake");
                return null;
            }
            return manager;
        }

    }
}
