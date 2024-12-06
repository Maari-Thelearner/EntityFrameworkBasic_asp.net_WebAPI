namespace EmployeeManagementSystemsln.Models;

public class Project
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    
    //many to many relationship
    //Here in many to many relationship both entities are dependent each other so we are using common entity called EmployeeProject

    public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    
    
    
}