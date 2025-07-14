using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EgyptWalks.Data
{
    public class EgyptWalksAuthDbContext : IdentityDbContext
    {


        public EgyptWalksAuthDbContext(DbContextOptions<EgyptWalksAuthDbContext> options) : base(options) 
        {
            
        }
    }
}
