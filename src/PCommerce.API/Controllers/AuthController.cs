using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<Account> _userManager;

    public AuthController(RoleManager<IdentityRole> roleManager,
        UserManager<Account> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    // TO DO
    
    [HttpPost("sign-up")]
    public async Task<OkResult> SignUpAsync()
    {
        return Ok();
    }
    
    [HttpPost("sign-in")]
    public async Task<OkResult> SignInAsync()
    {
        return Ok();
    }
}