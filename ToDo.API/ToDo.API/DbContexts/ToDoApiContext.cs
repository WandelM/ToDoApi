using Microsoft.EntityFrameworkCore;
using ToDo.API.Models;

namespace ToDo.API.DbContexts
{
    public class ToDoApiContext: DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<UserModel> UserModels { get; set; }

        public ToDoApiContext(DbContextOptions<ToDoApiContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ToDoItem configuration
            modelBuilder.Entity<ToDoItem>().HasKey(i => i.Id);

            modelBuilder.Entity<ToDoItem>().HasIndex(i => i.UserId);

            modelBuilder.Entity<ToDoItem>().Property(i => i.Id)
                                           .IsRequired()
                                           .HasDefaultValue(Guid.NewGuid());

            modelBuilder.Entity<ToDoItem>().Property(i => i.UserId).IsRequired();
            
            modelBuilder.Entity<ToDoItem>().Property(i => i.Name)
                                           .IsRequired()
                                           .HasMaxLength(100);

            modelBuilder.Entity<ToDoItem>().Property(i => i.Description)
                                           .HasMaxLength(1000);

            modelBuilder.Entity<ToDoItem>().Property(i => i.Finished)
                                           .HasDefaultValue(false);

            modelBuilder.Entity<ToDoItem>().Property(i => i.CreatedDate)
                                           .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<ToDoItem>().Property(i => i.DueDate)
                                           .HasDefaultValue(DateTime.UtcNow.AddDays(30));

            //User
            modelBuilder.Entity<UserModel>().HasKey(u => u.Id);

            modelBuilder.Entity<UserModel>().HasIndex(u => u.UserName);

            modelBuilder.Entity<UserModel>().Property(u => u.Id)
                                            .IsRequired()
                                            .HasDefaultValue(Guid.NewGuid());

            modelBuilder.Entity<UserModel>().Property(u => u.UserName)
                                            .IsRequired()
                                            .HasMaxLength(100);

            modelBuilder.Entity<UserModel>().Property(u => u.Password)
                                            .IsRequired()
                                            .HasMaxLength(50);

            modelBuilder.Entity<UserModel>().Property(u => u.CreatedDate)
                                            .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<UserModel>().Property(u => u.LastLogIn)
                                            .HasDefaultValue(null);
        }
    }
}
