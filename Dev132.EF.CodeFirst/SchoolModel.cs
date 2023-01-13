using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Dev132.EF.CodeFirst
{
    public partial class SchoolModel : DbContext
    {
        public SchoolModel()
            : base("name=SchoolContext")
        {
        }

        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Lessons)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);
        }
    }
}
