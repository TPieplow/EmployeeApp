using EmployeeAppSecondGo.Interfaces;
using EmployeeAppSecondGo.ServicesM;

namespace EmployeeAppSecondGo.Services;

public class Menu
{
    public void MenuOptions()
    {
        IEmployeeService employeeService = new EmployeeService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("### HANDLE EMPLOYEE MENU ###");
            string[] menu =
            {
                "1. Add Employee",
                "2. Update Employee",
                "3. Get Employee",
                "4. Get ALL Employees",
                "5. Delete Employee",
                "6. Create New File",
                "7. Load File",
                "8. Delete File",
                "9. Exit"
            };

            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine(menu[i]);
            }

            string choice = Console.ReadLine()?.Trim()!;

            switch (choice)
            {
                case "1":
                    employeeService.AddEmployee();
                    break;
                case "2":
                    employeeService.UpdateEmployee();
                    break;
                case "3":
                    employeeService.GetEmployee();
                    break;
                case "4":
                    employeeService.GetEmployees();
                    break;
                case "5":
                    employeeService.DeleteEmployee();
                    break;
                case "6":
                    Read myWriter = new Read();
                    Console.WriteLine("Enter file name: ");
                    string fileName = Console.ReadLine()?.Trim()!;
                    myWriter.ToFile(fileName, employeeService.EmployeeList);
                    break;
                case "7":
                    Read myReader = new Read();
                    myReader.FromFile(employeeService.EmployeeList);
                    break;
                case "8":
                    Read delete = new Read();
                    delete.DeleteFile();
                    break;
                case "9":
                    ExitApplication.Exit();
                    break;
            }
        }
    }
}
