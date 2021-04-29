using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public DbSet<Activity> Activitys { get; set; }
        public DbSet<Helper> Helpers { get; set; }

        public DbSet<Round> Rounds { get; set; }
    }


}
