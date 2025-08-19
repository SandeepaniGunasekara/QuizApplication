using Microsoft.EntityFrameworkCore;
using QuizApplication.Models.Entities;

namespace QuizApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //have to define the tables. here have to define 2 properties. one for question and the other one is for options
        public DbSet<Question> Questions { get; set; }//here the name should be the name which is inside the sql server relevant table
        public DbSet<Option> Options { get; set; }
    }
}
