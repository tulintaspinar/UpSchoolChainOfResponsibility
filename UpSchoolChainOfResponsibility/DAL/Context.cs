using Microsoft.EntityFrameworkCore;
using UpSchoolChainOfResponsibility.DAL.Entities;

namespace UpSchoolChainOfResponsibility.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5CE3LGO;initial catalog=UpSchoolDbChainOfResponsibility;Integrated Security=true;");
        }
        public DbSet<BankProcess> BankProcesses { get; set; }
    }
}
