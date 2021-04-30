using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public class ActivityHelpersContext : DbContext
    {
        public ActivityHelpersContext(DbContextOptions<ActivityHelpersContext> options)
            : base(options)
        { }

        public DbSet<Activity> Activitys { get; set; }
        public DbSet<Helper> Helpers { get; set; }

        public DbSet<Round> Rounds { get; set; }
    }


}
