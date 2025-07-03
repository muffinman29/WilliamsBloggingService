using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public string DbPath { get; }

        public BloggingContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Console.WriteLine(path);
            DbPath = Path.Join(path, "blogging.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}").UseSeeding((context, _) =>
            {
                var testUser = context.Set<User>().FirstOrDefault(u => u.Username == "muffinman");
                if (testUser == null)
                {
                    context.Set<User>().Add(new User { UserId = 1, FirstName = "Steven", LastName = "Williams", Username = "muffinman", Password = "test" });
                    context.SaveChanges();
                }
            });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(b => b.Blog)
                .WithMany(a => a.Comments)
                .HasForeignKey(b => b.BlogId);

            modelBuilder.Entity<Blog>()
                .HasOne(b => b.User)
                .WithMany(a => a.Blogs)
                .HasForeignKey(b => b.UserId);
        }
    }
}
