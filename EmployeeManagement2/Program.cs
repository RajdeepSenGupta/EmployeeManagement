using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            string id, name, email, skype;
            List<Employee> list = new List<Employee>();                                     //Creating list
            Employee employee = new Employee();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("0.Exit\n1.Register employee\n2.Register HR\n3.Register Developer\n4.Display List\n5.Find Employee\n6.Update Employee");
                Console.Write("\nEnter option:\t");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:                                                       //Employee Registration
                        Console.WriteLine();
                        Console.Write("Employee Id (Start with 'E/e'):\t");
                        id = Console.ReadLine();
                        Console.Write("Name:\t");
                        name = Console.ReadLine();
                        list.Add(new Employee(id, name));                        //Employee() Constructor overloading 1
                        Console.WriteLine("Employee Registered");
                        Console.ReadKey();
                        break;
                    case 2:                                                      //HR Registration
                        Console.WriteLine();
                        Console.Write("HR Id (Start with 'H/h'):\t");
                        id = Console.ReadLine();
                        Console.Write("Name:\t");
                        name = Console.ReadLine();
                        Console.Write("Email:\t");
                        email = Console.ReadLine();
                        list.Add(new HR(id, name, email));                        //HR() Constructor overloading 1
                        Console.WriteLine("HR Registered");
                        Console.ReadKey();
                        break;
                    case 3:                                                       //Developer Registration
                        Console.WriteLine();
                        Console.Write(" DeveloperId (Start with 'D/d'):\t");
                        id = Console.ReadLine();
                        Console.Write("Name:\t");
                        name = Console.ReadLine();
                        Console.Write("Skype Id:\t");
                        skype = Console.ReadLine();
                        list.Add(new Developer(id, name, skype));                  //Developer() Constructor overloading 1
                        Console.WriteLine("Developer Registered");
                        Console.ReadKey();
                        break;
                    case 4:                                                         //Displaying whole list
                        foreach (Employee displayEmployee in list)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Id\t{0}", displayEmployee.Id);
                            Console.WriteLine("Name\t{0}", displayEmployee.Name);
                            Console.WriteLine("Email\t{0}", displayEmployee.Email);
                            Console.WriteLine("Skype Id\t{0}", displayEmployee.SkypeId);
                        }
                        Console.ReadKey();
                        break;
                    case 5:                                                         //Finding an employee with his/her Id
                        Employee findEmployee = new Employee();
                        Console.Write("Id of the employee to be found:\t");
                        string findId = Console.ReadLine();
                        findEmployee = findEmployee.Find(list, findId);
                        if (findEmployee == null)
                        {
                            Console.WriteLine("Employee not registered");
                        }
                        else
                        {
                            Console.WriteLine("Id\t{0}", findEmployee.Id);
                            Console.WriteLine("Name\t{0}", findEmployee.Name);
                            Console.WriteLine("Email\t{0}", findEmployee.Email);
                            Console.WriteLine("Skype Id\t{0}", findEmployee.SkypeId);
                        }
                        Console.ReadKey();
                        break;
                    case 6:                                                                 //Updating an employee
                        Employee updateEmployee = new Employee();
                        Console.Write("Id of the employee to be updated:\t");
                        string updateId = Console.ReadLine();
                        updateEmployee = updateEmployee.Find(list, updateId);
                        if (updateEmployee == null)
                        {
                            Console.WriteLine("Employee not registered");
                        }
                        else
                        {
                            if (updateEmployee.Email.Equals("N.A.") && updateEmployee.SkypeId.Equals("N.A."))                          //Updating normal employee
                            {
                                Console.WriteLine("Id can not be changed\nEmployee Id:\t{0}", updateEmployee.Id);
                                Console.Write("Name:\t");
                                updateEmployee.Name = Console.ReadLine();
                                Console.WriteLine("Employee Updated!");
                            }
                            else if (updateEmployee.Email.Equals("N.A.") == false && updateEmployee.SkypeId.Equals("N.A."))                      //Updating HR
                            {
                                Console.WriteLine("Id can not be changed\nHR Id:\t{0}", updateEmployee.Id);
                                Console.Write("Name:\t");
                                updateEmployee.Name = Console.ReadLine();
                                Console.Write("Email:\t");
                                updateEmployee.Email = Console.ReadLine();
                                Console.WriteLine("HR Updated");
                            }
                            else if (updateEmployee.Email.Equals("N.A.") && updateEmployee.SkypeId.Equals("N.A") == false)                         //Updating Developer
                            {
                                Console.WriteLine("Id can not be changed\nDeveloper Id:\t{0}", updateEmployee.Id);
                                Console.Write("Name:\t");
                                updateEmployee.Name = Console.ReadLine();
                                Console.Write("Skype Id:\t");
                                updateEmployee.SkypeId = Console.ReadLine();
                                Console.WriteLine("Developer Updated");
                            }

                            Console.ReadKey();
                        }
                        break;
                }
            }

            Console.ReadKey();
        }
    }
    class Employee : Variables, IMethods                                                               //Employee inheriting interface, 
    {
        String id, name, email = "N.A.", skypeId = "N.A.";

        public override string Id
        {
            get { return id; }

            set { id = value; }
        }
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        public override string Email
        {
            get { return email; }
            set { email = value; }
        }
        public override string SkypeId
        {
            get { return skypeId; }
            set { skypeId = value; }
        }

        public Employee() { }
        public Employee(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public Employee Find(List<Employee> list, String id)
        {
            foreach (Employee employee in list)
            {
                if (id.Equals(employee.Id))
                {
                    return employee;
                }
            }
            return null;
        }
        ~Employee()                                                                             //Employee Destructor
        {
            Console.WriteLine("Employee Destructor");
        }
    }

    class HR : Employee                                                                         //HR inheriting class Employee
    {
        public HR(string id, string name, string email)
            : base(id, name)
        {
            Email = email;
        }
        ~HR()                                                                                   //HR Destructor
        {
            Console.WriteLine("HR Destructor");
        }
    }

    class Developer : Employee                                                                  //Developer inheriting class Employee
    {
        public Developer(string id, string name, string skype)
            : base(id, name)
        {
            SkypeId = skype;
        }
        ~Developer()                                                                            //Developer Destructor
        {
            Console.WriteLine("Developer Destructor");
        }
    }

    interface IMethods                                                                          //Interface
    {
        Employee Find(List<Employee> list, string id);
        //Branch 2
        //Branch 2 (1)
        //Branch 2 (2)
        //Branch 2 (3)
    }

    public abstract class Variables
    {
        public abstract string Id
        {
            get;
            set;
        }
        public abstract string Name
        {
            get;
            set;
        }
        public abstract string Email
        {
            get;
            set;
        }
        public abstract string SkypeId
        {
            get;
            set;
        }
    }
}
