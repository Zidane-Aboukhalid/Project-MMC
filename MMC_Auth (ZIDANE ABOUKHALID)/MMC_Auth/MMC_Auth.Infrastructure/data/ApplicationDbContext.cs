using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MMC_Auth.Domain.Entitys;


namespace MMC_Auth.Infrastructure.data;

public class ApplicationDbContext :IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions)
    {
        
    }
}
