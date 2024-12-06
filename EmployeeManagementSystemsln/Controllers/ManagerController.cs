using EmployeeManagementSystemsln.Data;
using EmployeeManagementSystemsln.DTO;
using EmployeeManagementSystemsln.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EmployeeManagementSystemsln.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ManagerController: ControllerBase
{
    private readonly DataContext _context;
    public ManagerController(DataContext dataContext)
    {
        this._context = dataContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateManager([FromBody] CreateManagerDTO dto)
    {
        if (ModelState.IsValid)
        {
            var manager = new Manager()
            {
                ManagerFirstName = dto.FirstName,
                ManagerLastName = dto.LastName
            };
            this._context.Managers.Add(manager);
            await this._context.SaveChangesAsync();
            return Ok(manager);
        }
        else
        {
            return BadRequest();
        }
    }
}