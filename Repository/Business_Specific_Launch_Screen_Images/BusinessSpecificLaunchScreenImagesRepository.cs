using getstertech_user_apps_common_data.GetsterTech_DbContext;
using getstertech_user_apps_common_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getstertech_user_apps_common_data.Repository.Business_Specific_Launch_Screen_Images
{
    public class BusinessSpecificLaunchScreenImagesRepository : IBusinessSpecificLaunchScreenImagesRepository
    {
        public readonly UserAppsCommonDataDb_DbContext _DBContext;
        public BusinessSpecificLaunchScreenImagesRepository(UserAppsCommonDataDb_DbContext DBContext)
        {
            _DBContext = DBContext;
        }
        public Response AddBusinessSpecificLaunchScreenImages(business_specific_launch_screen_images obj_business_specific_launch_screen_images)
        {
            Response response = new Response();
            try
            {
                business_specific_launch_screen_images _obj_business_specific_launch_screen_images = new business_specific_launch_screen_images();

                string[] business_category_image_name_Array = obj_business_specific_launch_screen_images.business_category_image_name.Split(",");

                foreach(string result in business_category_image_name_Array)
                {
                    _obj_business_specific_launch_screen_images.business_category_image_id = obj_business_specific_launch_screen_images.business_category_image_id;
                    _obj_business_specific_launch_screen_images.user_app_business_category_id = obj_business_specific_launch_screen_images.user_app_business_category_id;
                    _obj_business_specific_launch_screen_images.business_category_image_name = result;
                    _obj_business_specific_launch_screen_images.uploaded_by_user_id = obj_business_specific_launch_screen_images.uploaded_by_user_id;
                    _obj_business_specific_launch_screen_images.business_category_image_storage_path = obj_business_specific_launch_screen_images.business_category_image_storage_path;
                    _obj_business_specific_launch_screen_images.upload_timestamp = obj_business_specific_launch_screen_images.upload_timestamp;
                    _obj_business_specific_launch_screen_images.deleted_status = obj_business_specific_launch_screen_images.deleted_status;
                    _obj_business_specific_launch_screen_images.default_text_colour = obj_business_specific_launch_screen_images.default_text_colour;
                    _obj_business_specific_launch_screen_images.mobile_path = obj_business_specific_launch_screen_images.mobile_path;
                    _DBContext.Add(_obj_business_specific_launch_screen_images);
                    _DBContext.SaveChanges();

                }




                audit_trail_for_business_specific_launch_screen_images _obj_audit_trail_for_business_specific_launch_screen_images = new audit_trail_for_business_specific_launch_screen_images();

                _obj_audit_trail_for_business_specific_launch_screen_images.business_category_image_id = _obj_business_specific_launch_screen_images.business_category_image_id;
                _obj_audit_trail_for_business_specific_launch_screen_images.user_activity = "Business Specific Launch Screen Images Added!!";
                _obj_audit_trail_for_business_specific_launch_screen_images.activity_by_user_id = obj_business_specific_launch_screen_images.uploaded_by_user_id;
                _obj_audit_trail_for_business_specific_launch_screen_images.activity_local_timestamp = DateTime.UtcNow;
                _DBContext.Add(_obj_audit_trail_for_business_specific_launch_screen_images);
                _DBContext.SaveChanges();

                response.Message = "Data Saved successfully !!";
                response.Status = true;
            }

            catch (Exception ex)
            {
                response.Message = "Data Added failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response UpdateBusinessSpecificLaunchScreenImages(update_vm_business_specific_launch_screen_images obj_update_vm_business_specific_launch_screen_images, update_vm_business_specific_launch_screen_images mainobj)
        {
            Response response = new Response();
            try
            {
                business_specific_launch_screen_images _obj_business_specific_launch_screen_images = new business_specific_launch_screen_images();

                _obj_business_specific_launch_screen_images.business_category_image_id = obj_update_vm_business_specific_launch_screen_images.business_category_image_id;
                _obj_business_specific_launch_screen_images.default_text_colour = obj_update_vm_business_specific_launch_screen_images.default_text_colour;
                _obj_business_specific_launch_screen_images.mobile_path = obj_update_vm_business_specific_launch_screen_images.mobile_path;

                _DBContext.Attach(_obj_business_specific_launch_screen_images);
                _DBContext.Entry(_obj_business_specific_launch_screen_images).Property(p => p.default_text_colour).IsModified = true;
                _DBContext.Entry(_obj_business_specific_launch_screen_images).Property(p => p.mobile_path).IsModified = true;
                _DBContext.SaveChanges();


                audit_trail_for_business_specific_launch_screen_images obj_audit_trail_for_business_specific_launch_screen_images = new audit_trail_for_business_specific_launch_screen_images();

                obj_audit_trail_for_business_specific_launch_screen_images.business_category_image_id = obj_update_vm_business_specific_launch_screen_images.business_category_image_id;
                obj_audit_trail_for_business_specific_launch_screen_images.user_activity = "Business Specific Launch Screen Images Edited !!";
                obj_audit_trail_for_business_specific_launch_screen_images.activity_by_user_id = obj_update_vm_business_specific_launch_screen_images.uploaded_by_user_id;
                obj_audit_trail_for_business_specific_launch_screen_images.activity_local_timestamp = DateTime.UtcNow;
                _DBContext.Add(obj_audit_trail_for_business_specific_launch_screen_images);
                _DBContext.SaveChanges();

                response.Message = "Data updated successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Data updation failed !!";
                response.Status = false;
            }
            return response;
        }


        public Response GetBusinessSpecificLaunchScreenImages(Int64 Business_Category_Image_Id)
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DBContext.business_specific_launch_screen_images.Where(x=> x.business_category_image_id == Business_Category_Image_Id)
                                 select new
                                 {
                                     business_category_image_id = master.business_category_image_id,
                                     user_app_business_category_id = master.user_app_business_category_id,
                                     business_category_image_name = master.business_category_image_name,
                                     business_category_image_storage_path = master.business_category_image_storage_path,
                                     uploaded_by_user_id = master.uploaded_by_user_id,
                                     upload_timestamp = master.upload_timestamp,
                                     deleted_status = master.deleted_status,
                                     default_text_colour = master.default_text_colour,
                                     mobile_path = master.mobile_path
                                  
                                 }).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }



        public Response GetBusinessSpecificLaunchScreenImagesBy_Business_Category_Id(string User_App_Business_Category_Id)
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DBContext.business_specific_launch_screen_images.Where(x => x.user_app_business_category_id == User_App_Business_Category_Id)
                                 select new
                                 {
                                     business_category_image_id = master.business_category_image_id,
                                     user_app_business_category_id = master.user_app_business_category_id,
                                     business_category_image_name = master.business_category_image_name,
                                     business_category_image_storage_path = master.business_category_image_storage_path,
                                     uploaded_by_user_id = master.uploaded_by_user_id,
                                     upload_timestamp = master.upload_timestamp,
                                     deleted_status = master.deleted_status,
                                     default_text_colour = master.default_text_colour,
                                     mobile_path = master.mobile_path

                                 }).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }



















        public Response GetALLBusinessSpecificLaunchScreenImages()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DBContext.business_specific_launch_screen_images
                                 select new
                                 {
                                     business_category_image_id = master.business_category_image_id,
                                     user_app_business_category_id = master.user_app_business_category_id,
                                     business_category_image_name = master.business_category_image_name,
                                     business_category_image_storage_path = master.business_category_image_storage_path,
                                     uploaded_by_user_id = master.uploaded_by_user_id,
                                     upload_timestamp = master.upload_timestamp,
                                     deleted_status = master.deleted_status,
                                     default_text_colour = master.default_text_colour,
                                     mobile_path = master.mobile_path



                                 }).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }

        public Response DeleteBusinessSpecificLaunchScreenImages(Int64 Business_Category_Image_Id)
        {
            Response response = new Response();
            try
            {
                var business_specific_launch_screen_images = _DBContext.business_specific_launch_screen_images.Where(x => x.business_category_image_id == Business_Category_Image_Id).FirstOrDefault();
                _DBContext.business_specific_launch_screen_images.Remove(business_specific_launch_screen_images);
                _DBContext.SaveChanges();

                audit_trail_for_business_specific_launch_screen_images obj_audit_trail_for_business_specific_launch_screen_images = new audit_trail_for_business_specific_launch_screen_images();

                obj_audit_trail_for_business_specific_launch_screen_images.business_category_image_id = business_specific_launch_screen_images.business_category_image_id;
                obj_audit_trail_for_business_specific_launch_screen_images.user_activity = "Business Specific Launch Screen Images Deleted !!";
                obj_audit_trail_for_business_specific_launch_screen_images.activity_by_user_id = business_specific_launch_screen_images.uploaded_by_user_id;
                obj_audit_trail_for_business_specific_launch_screen_images.activity_local_timestamp = DateTime.UtcNow;
                _DBContext.Add(obj_audit_trail_for_business_specific_launch_screen_images);
                _DBContext.SaveChanges();

                response.Message = "Data Deleted successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Deleting the data !!";
                response.Status = false;
            }
            return response;
        }

        public Response GetALLAuditTrailForBusinessSpecificLaunchScreenImages()
        {

            Response response = new Response();
            try
            {

                response.Data = (from master in _DBContext.audit_trail_for_business_specific_launch_screen_images
                                 select new
                                 {
                                     business_category_image_id = master.business_category_image_id,
                                     user_activity = master.user_activity,
                                     activity_by_user_id = master.activity_by_user_id,
                                     activity_local_timestamp = master.activity_local_timestamp                            
                                 }).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }
    }
}
