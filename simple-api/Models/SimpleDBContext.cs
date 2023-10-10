using Microsoft.EntityFrameworkCore;

namespace simple_api.Models
{
    public class SimpleDBContext : DbContext
    {
        public SimpleDBContext(DbContextOptions<SimpleDBContext> options) : base(options)
        {

        }

        public DbSet<DCandidate> DCandidates { get; set; }
    }
}
