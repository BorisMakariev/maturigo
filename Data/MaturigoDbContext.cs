using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace maturigo.Data
{
    public class MaturigoDbContext : IdentityDbContext
    {
        public MaturigoDbContext(DbContextOptions<MaturigoDbContext> options)
            : base(options)
        {
        }
    }
}
