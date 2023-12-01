namespace EmployeeAppSecondGo.Interfaces
{
    public interface IEmployee
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Position { get; set; }
    }
}