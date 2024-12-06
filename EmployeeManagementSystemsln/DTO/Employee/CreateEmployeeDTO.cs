using EmployeeManagementSystemsln.Models;

namespace EmployeeManagementSystemsln.DTO.Employee;

public class CreateEmployeeDTO
{
    public int EmployeeId { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeeLastName { get; set; }
    public long EmployeeSalary { get; set; }
    
    public int ManagerId { get; set; }
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
}