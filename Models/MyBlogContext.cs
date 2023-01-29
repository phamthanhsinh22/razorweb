
using Microsoft.EntityFrameworkCore;

namespace razorweb.models
{
    public class MyBlogContext : DbContext{
        public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
        {
            
        }
        //nạp chồng 2 phương thức OnConfiguring và Creating
        protected override void OnConfiguring(DbContextOptionsBuilder builder){
            base.OnConfiguring(builder);
        }  
        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
        }

        public DbSet<Article> articles{set;get;}

    }
}