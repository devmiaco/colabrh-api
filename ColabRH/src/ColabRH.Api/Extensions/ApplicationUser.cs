using Microsoft.AspNetCore.Identity;

namespace ColabRH.Api.Extensions;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
}
