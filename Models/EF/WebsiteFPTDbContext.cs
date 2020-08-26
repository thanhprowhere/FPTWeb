namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebsiteFPTDbContext : DbContext
    {
        public WebsiteFPTDbContext()
            : base("name=WebsiteFPTDbContext2")
        {
        }

        public virtual DbSet<AcademicLevel> AcademicLevels { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseCategory> CourseCategories { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicLevel>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.AcademicLevel)
                .HasForeignKey(e => e.IdAcademicLevel);

            modelBuilder.Entity<Course>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Enrollments)
                .WithOptional(e => e.Course)
                .HasForeignKey(e => e.IdCourse);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Topics)
                .WithOptional(e => e.Course)
                .HasForeignKey(e => e.IdCourse);

            modelBuilder.Entity<CourseCategory>()
                .HasMany(e => e.Courses)
                .WithOptional(e => e.CourseCategory)
                .HasForeignKey(e => e.IdCategoryCourse);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.IdRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Enrollments)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IdUser);
        }
    }
}
