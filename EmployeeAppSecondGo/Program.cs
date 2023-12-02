using EmployeeAppSecondGo.Services;
using EmployeeAppSecondGo.ServicesM;

public class Program
{
    static void Main()
    {
        var myReader = new Read();
        var employeeService = new EmployeeService();
        var menu = new Menu(employeeService, myReader);
        menu.MenuOptions();
    }
}