using EmployeeManagementSystemsln.Data;
using EmployeeManagementSystemsln.DTO.Employee;
using EmployeeManagementSystemsln.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemsln.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class EmployeeController : ControllerBase
{
   private readonly DataContext _context;
   public EmployeeController(DataContext context)
   {
      this._context = context;
   }

   [HttpPost]
   public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDTO dto)
   {
      if (ModelState.IsValid)
      {
         var employee = new Employee()
         {
            EmployeeFirstName = dto.EmployeeFirstName,
            EmployeeLastName = dto.EmployeeLastName,
            EmployeeSalary = dto.EmployeeSalary,
            ManagerId = dto.ManagerId,
            EmployeeDetailsRefNav = new EmployeeDetails()
            {
               Email = dto.Email,
               PhoneNumber = dto.PhoneNumber
            }
         };

         this._context.Employees.Add(employee);
         await this._context.SaveChangesAsync();
         
         return Ok(dto);
      }
      else
      {
         return BadRequest();
      }
   }
}