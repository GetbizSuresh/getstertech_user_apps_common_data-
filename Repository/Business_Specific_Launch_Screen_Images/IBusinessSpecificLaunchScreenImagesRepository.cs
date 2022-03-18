using getstertech_user_apps_common_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getstertech_user_apps_common_data.Repository.Business_Specific_Launch_Screen_Images
{
    public interface IBusinessSpecificLaunchScreenImagesRepository
    {
        Response GetALLBusinessSpecificLaunchScreenImages();
        Response DeleteBusinessSpecificLaunchScreenImages(Int64 Business_Category_Image_Id);
        Response GetBusinessSpecificLaunchScreenImages(Int64 Business_Category_Image_Id);
        Response GetBusinessSpecificLaunchScreenImagesBy_Business_Category_Id(string User_App_Business_Category_Id);
        Response GetALLAuditTrailForBusinessSpecificLaunchScreenImages();
        Response UpdateBusinessSpecificLaunchScreenImages(update_vm_business_specific_launch_screen_images obj_update_vm_business_specific_launch_screen_images, update_vm_business_specific_launch_screen_images mainobj);
        Response AddBusinessSpecificLaunchScreenImages(business_specific_launch_screen_images obj_business_specific_launch_screen_images);

    }
}
