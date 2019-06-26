using MyApp.Areas.Admin.Models.Models;
using System.Data.Entity;
namespace MyApp.Areas.Admin.Models.Contexts
{
    public class BasicContext: DbContext
    {
        public DbSet<User> Users { get; set; } 

        public DbSet<Content> Contents { get; set; }
    }
}