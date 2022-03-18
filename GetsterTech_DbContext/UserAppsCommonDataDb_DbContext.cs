using getstertech_user_apps_common_data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getstertech_user_apps_common_data.GetsterTech_DbContext
{
    public class UserAppsCommonDataDb_DbContext : DbContext
    {



        public UserAppsCommonDataDb_DbContext(DbContextOptions<UserAppsCommonDataDb_DbContext> dbContext) : base(dbContext)
        {

        }


       public DbSet<generic_launch_screen_images> generic_launch_screen_images { get; set; }
       public DbSet<business_specific_launch_screen_images> business_specific_launch_screen_images { get; set; }


       public DbSet<audit_trail_for_generic_launch_screen_images> audit_trail_for_generic_launch_screen_images { get; set; }
       public DbSet<audit_trail_for_business_specific_launch_screen_images> audit_trail_for_business_specific_launch_screen_images { get; set; }
       public DbSet<update_vm_business_specific_launch_screen_images> update_vm_business_specific_launch_screen_images { get; set; }
    }
}
