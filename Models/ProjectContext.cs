using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace mvcproject.Models
{
    public class ProjectContext: IdentityDbContext<ApplicationUser>
    {
            public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
            {

            }
        
    }
}
