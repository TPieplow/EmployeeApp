namespace EmployeeAppSecondGo.Interfaces
{
    public interface IEmployeeService
    {
        List<IEmployee> EmployeeList { get; }
        void AddEmployee();
        void DeleteEmployee();
        void GetEmployee();
        void GetEmployees();
        void UpdateEmployee();
    }
}