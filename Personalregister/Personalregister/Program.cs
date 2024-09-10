
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;



class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }

    public Employee(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }

    public void PrintEmployee()
    {
        Console.WriteLine($"Name: {Name}, Salary: {Salary:C}");
    }
}

class EmployeeRegister
{
    private List<Employee> EmployeeList = new List<Employee>();

    public void AddEmployee(string name, decimal salary)
    {
        Employee newEmployee = new Employee(name, salary);
        EmployeeList.Add(newEmployee);
    }

    public void PrintRegister()
    {
        if (EmployeeList.Count == 0)
        {
            Console.WriteLine("No employees in the register.");
        }
        else
        {
            Console.WriteLine("\nEmployee Register:");
            foreach (Employee employee in EmployeeList)
            {
                employee.PrintEmployee();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        EmployeeRegister register = new EmployeeRegister();

        while (true)
        {
            Console.Write("Enter employee name (or type 'exit' to finish): ");
            string name = Console.ReadLine().Trim(); 

            if (name.ToLower() == "exit")
            {
                break;
            }

            Console.Write("Enter employee salary: ");
            decimal salary;
            while (!decimal.TryParse(Console.ReadLine(), out salary))
            {
                Console.Write("Invalid salary. Please try again: ");
            }

            register.AddEmployee(name, salary);
        }

        register.PrintRegister(); // Print the register after exiting the loop
    }
}
