
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace getstertech_user_apps_common_data.Models
{
 
    public class audit_trail_for_generic_launch_screen_images
    {
        [Key]
        public int id { set; get; }
        public int generic_image_id { set; get; }
        public string user_activity { set; get; }
        public int activity_by_user_id { set; get; }
        public DateTime activity_timestamp { set; get; }
    }
}
