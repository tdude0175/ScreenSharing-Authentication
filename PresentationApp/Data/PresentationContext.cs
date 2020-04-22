using Microsoft.EntityFrameworkCore;
using PresentationApp.Models;

namespace PresentationApp.Data
{
    public class PresentationContext : DbContext
    {
        public PresentationContext (DbContextOptions<PresentationContext> options) : base(options)
        {
        }

        public DbSet<Presentation> Presentation {get;set;}
        public DbSet<Slide> Slide {get;set;}
    }
}