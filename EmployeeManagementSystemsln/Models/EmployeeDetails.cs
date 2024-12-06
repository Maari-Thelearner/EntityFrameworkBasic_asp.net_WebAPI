namespace EmployeeManagementSystemsln.Models;

public class EmployeeDetails
{
    public int EmployeeDetailsId { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    //One-OneRelationship
    //EmployeeDetails is a Dependent Entity
    
    public int EmployeeId { get; set; }
    
    public Employee Employee { get; set; } //reference Navigation Property
    
}