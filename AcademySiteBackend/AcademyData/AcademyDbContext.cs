using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AcademyData
{
    public class AcademyDbContext : IdentityDbContext<IdentityUser<int>,IdentityRole<int>,int>
    {
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options)
            : base(options)
        {
        }
    }
}