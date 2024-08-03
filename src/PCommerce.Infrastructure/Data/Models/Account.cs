using Microsoft.AspNetCore.Identity;

namespace PCommerce.Infrastructure.Data.Models;

public class Account : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
}