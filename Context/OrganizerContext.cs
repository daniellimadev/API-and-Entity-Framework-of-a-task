using Microsoft.EntityFrameworkCore;
using API_and_Entity_Framework_of_a_task.Models;

namespace API_and_Entity_Framework_of_a_task.Context
{
    public class OrganizerContext : DbContext
    {
        public OrganizerContext(DbContextOptions<OrganizerContext> options) : base(options)
        {
            
        }

        public DbSet<Taske> Tasks { get; set; }
    }
}