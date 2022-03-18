using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace getstertech_user_apps_common_data.Models
{
    public class generic_launch_screen_images
    {
        [Key]
        public int generic_image_id { set; get; }
        public string generic_image_name { set; get; }
        public string generic_image_storage_path { set; get; }
        public bool deleted_status { set; get; }
        public int user_id { set; get; }
        public string default_text_colour { set; get; }
        public string mobile_path { set; get; }
        [NotMapped]
        public string mobile_path_name { set; get; }

      //  [NotMapped]

       // public IFormFile generic_image_storage_paths { set; get; }
    }
}
