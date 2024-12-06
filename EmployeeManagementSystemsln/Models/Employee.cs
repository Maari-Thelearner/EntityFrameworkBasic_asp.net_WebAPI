namespace EmployeeManagementSystemsln.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeeLastName { get; set; }
    public long EmployeeSalary { get; set; }
    
    //One-One Relationship
    //Employee is principal entity for EmployeeDetails
    
    public EmployeeDetails EmployeeDetailsRefNav { get; set; }
    
    //one to many Relationship
    //Employee is Dependent entity here with manager, One Manager , Many Employees
    public int ManagerId { get; set; }
    public Manager ManagerRefNav { get; set; }
    
    
    //many to many relationship
    //Here in many to many relationship both entities are dependent each other so we are using common entity called EmployeeProject
    
    public ICollection<EmployeeProject> EmployeeProjects { get; set; }
}