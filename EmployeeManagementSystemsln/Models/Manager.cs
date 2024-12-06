namespace EmployeeManagementSystemsln.Models;

public class Manager
{
    public int ManagerId { get; set; }
    public string ManagerFirstName { get; set; }
    public string ManagerLastName { get; set; }
    
    // one to many relationship
    //Manager is the principal Entity with employees
    public ICollection<Employee> Employees { get; set; } //reference Collection navigation property
}