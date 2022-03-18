using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace getstertech_user_apps_common_data.Models
{
    public class business_specific_launch_screen_images
    {
        [Key]
        public int business_category_image_id { set; get; }
        public string user_app_business_category_id { set; get; }
        public string business_category_image_name { set; get; }
        public string business_category_image_storage_path { set; get; }

        //[NotMapped]

       // public IFormFile business_category_image_storage_paths { set; get; }
        public int uploaded_by_user_id { set; get; }
        public string upload_timestamp { set; get; }
        public bool deleted_status { set; get; }




        public string default_text_colour { set; get; }
        public string mobile_path { set; get; }

        [NotMapped]
        public string mobile_path_name { set; get; }
    }
}
