using getstertech_user_apps_common_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getstertech_user_apps_common_data.Repository.Generic_Launch_Screen_Images
{
   public  interface IGenericLaunchScreenImagesRepository
    {

        Response AddGenericLaunchScreenImages(generic_launch_screen_images obj_generic_launch_screen_images, generic_launch_screen_images mainobj);
        Response UpdateGenericLaunchScreenImages(update_vm_generic_launch_screen_images obj_update_vm_generic_launch_screen_images);
        Response GetALLGenericLaunchScreenImages();
        Response GetGenericLaunchScreenImages(Int64 Generic_Image_Id);
        Response DeleteGenericLaunchScreenImages(Int64 Generic_Image_Id );
        Response GetALLAuditTrailForGenericLaunchScreenImages();
    }
}
