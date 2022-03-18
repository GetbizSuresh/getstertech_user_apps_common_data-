using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getstertech_user_apps_common_data.Models
{
    public class update_vm_business_specific_launch_screen_images
    {

        [Key]
        public int business_category_image_id { set; get; }
        public int uploaded_by_user_id { set; get; }
        public string default_text_colour { set; get; }
        public string mobile_path { set; get; }
        public string mobile_path_name { set; get; }

    }
}
