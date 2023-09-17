using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ContosoUniversityTARpe21.Data
{
    public class DesignTimeSchoolContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        public SchoolContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-KPKLE7Q;Database=ContosoUniversity;Trusted_Connection=True;MultipleActiveResultSets=True");
            return new SchoolContext(optionsBuilder.Options);
        }
    }
}