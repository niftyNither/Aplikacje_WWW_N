using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        //Table properties e.g
        //public virual DbSet<Entity> TableName { get; set; }
        
        public virtual DbSet<Grade> Grades { get; set; }
        //mre prop to be added

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //config command
            optionsBuilder.UseLazyLoadingProxies(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Fluent API commands
            modelBuilder.Entity<User>()
                .ToTable("AspNetUsers")
                .HasDiscriminator<int>("UserType")
                .HasValue<User>((int)RoleValue.User)
                .HasValue<Student>((int)RoleValue.Student)
                .HasValue<Parent>((int)RoleValue.Parent)
                .HasValue<Teacher>((int)RoleValue.Teacher);

            modelBuilder.Entity<SubjectGroup>()
            .HasKey(sg => new {sg.GroupId, sg.SubjectId});

            modelBuilder.Entity<SubjectGroup>()
            .HasOne(g => g.Group)
            .WithMany(sg => sg.SubjectGroups)
            .HasForeignKey(g => g.GroupId);

            modelBuilder.Entity<SubjectGroup>()
            .HasOne(s => s.Subject)
            .WithMany(sg => sg.SubjectGroups)
            .HasForeignKey(s => s.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);
        }

        
    }
}