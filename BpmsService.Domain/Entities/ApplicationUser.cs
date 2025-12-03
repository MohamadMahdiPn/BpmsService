using Microsoft.AspNetCore.Identity;

namespace BpmsService.Domain.Entities;

public class ApplicationUser:IdentityUser<Guid>
{
    
}
public class ApplicationRole : IdentityRole<Guid>
{

}