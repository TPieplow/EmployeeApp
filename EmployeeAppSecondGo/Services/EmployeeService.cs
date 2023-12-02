using EmployeeAppSecondGo.Interfaces;
using EmployeeAppSecondGo.Models;
using EmployeeAppSecondGo.Services;

namespace EmployeeAppSecondGo.ServicesM
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<IEmployee> employeeList;

        public EmployeeService()
        {
            employeeList = new List<IEmployee>();
        }

        public List<IEmployee> EmployeeList => employeeList;

        public void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("### ADD EMPLOYEE ###");
            Console.Write("Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Position: ");
            string position = Console.ReadLine()!;

            Guid id = Guid.NewGuid();

            IEmployee employee = new Employee(id, name, position);
            employeeList.Add(employee);

            DisplayMessage.Message("Employee successfully added");
        }

        public void UpdateEmployee()
        {
            Console.Clear();
            Console.WriteLine("### UPDATE EMPLOYEE ###");
            Console.Write("Enter name of the employee you want to update: ");
            string name = Console.ReadLine()!;

            try
            {
                if (name != null)
                {
                    IEmployee employeeToUpdate = employeeList.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase))!;

                    if (employeeToUpdate != null)
                    {
                        Console.Write("New name: ");
                        string newName = Console.ReadLine()!;
                        Console.Write("New Position: ");
                        string newPosition = Console.ReadLine()?.Trim()!;

                        employeeToUpdate.Name = newName;
                        employeeToUpdate.Position = newPosition;

                        DisplayMessage.Message($"Updated {newPosition} - {newName}");
                    }
                    else
                    {
                        DisplayMessage.Message("An error occured while updating employee.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void GetEmployee()
        {
            Console.Clear();
            Console.WriteLine("### GET EMPLOYEE ###");
            Console.Write("Enter name of the employee you want to display: ");
            string name = Console.ReadLine()!;

            IEmployee getEmployee = employeeList.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase))!;
            if (getEmployee != null)
            {
                Console.WriteLine($"Name: {getEmployee.Name} \nPosition: {getEmployee.Position} \nID: {getEmployee.Id}");
                Console.ReadKey();
            }
            else
            {
                DisplayMessage.Message("An error occured while processing employees");
            }
        }

        public void GetEmployees()
        {
            Console.Clear();
            if (employeeList.Count == 0)
            {
                DisplayMessage.Message("List is empty");
            }
            else
            {
                foreach (IEmployee employee in employeeList)
                {
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine($"Name: {employee.Name} \nPosition: {employee.Position} \nID: {employee.Id}");
                }
            }
            Console.ReadKey();
        }

        public void DeleteEmployee()
        {
            Console.Clear();
            Console.WriteLine("### DELETE EMPLOYEE ###");
            Console.Write("Enter the name of the employee to DELETE");
            string name = Console.ReadLine()!;

            IEmployee deleteEmployee = employeeList.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase))!;

            if (deleteEmployee != null)
            {
                Console.WriteLine("Are you sure you want to delete this employee? (y/n)");
                string yesOrNo = Console.ReadLine()!;
                if (string.Equals(yesOrNo, "y", StringComparison.OrdinalIgnoreCase))
                {
                    employeeList.Remove(deleteEmployee);
                    DisplayMessage.Message($"Employee {deleteEmployee} successfully removed.");
                }
                else
                {
                    DisplayMessage.Message("No delete was made, employee still in system.");
                }
            }
            else
            {
                DisplayMessage.Message("An error occured, please try again.");
            }
        }
    }
}
