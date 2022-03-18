
using getstertech_user_apps_common_data.GetsterTech_DbContext;
using getstertech_user_apps_common_data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getstertech_user_apps_common_data.Repository.Generic_Launch_Screen_Images
{
    public class GenericLaunchScreenImagesRepository : IGenericLaunchScreenImagesRepository
    {

        public readonly UserAppsCommonDataDb_DbContext _DBContext;

        public GenericLaunchScreenImagesRepository(UserAppsCommonDataDb_DbContext DBContext)
        {
            _DBContext = DBContext;
        }

        public  Response AddGenericLaunchScreenImages(generic_launch_screen_images obj_generic_launch_screen_images, generic_launch_screen_images mainobj )
        {
            Response response = new Response();
            try
            {
                generic_launch_screen_images _obj_generic_launch_screen_images = new generic_launch_screen_images();           

               string[] generic_launch_screen_images_Array = obj_generic_launch_screen_images.generic_image_name.Split(",");

                foreach (string result in generic_launch_screen_images_Array)
                {
                    _obj_generic_launch_screen_images.generic_image_id = obj_generic_launch_screen_images.generic_image_id;
                    _obj_generic_launch_screen_images.generic_image_name = obj_generic_launch_screen_images.generic_image_name;
                    _obj_generic_launch_screen_images.generic_image_storage_path = result;
                    _obj_generic_launch_screen_images.deleted_status = obj_generic_launch_screen_images.deleted_status;
                    _obj_generic_launch_screen_images.default_text_colour = obj_generic_launch_screen_images.default_text_colour;
                    _obj_generic_launch_screen_images.mobile_path = obj_generic_launch_screen_images.mobile_path;
                    _DBContext.Add(_obj_generic_launch_screen_images);
                    _DBContext.SaveChanges();
                }

                audit_trail_for_generic_launch_screen_images _obj_audit_trail_for_generic_launch_screen_images = new audit_trail_for_generic_launch_screen_images();

                _obj_audit_trail_for_generic_launch_screen_images.generic_image_id = _obj_generic_launch_screen_images.generic_image_id;
                _obj_audit_trail_for_generic_launch_screen_images.user_activity = "User App Business Bategories Added !!";
                _obj_audit_trail_for_generic_launch_screen_images.activity_by_user_id = obj_generic_launch_screen_images.user_id;
                _obj_audit_trail_for_generic_launch_screen_images.activity_timestamp = DateTime.UtcNow;

                _DBContext.Add(_obj_audit_trail_for_generic_launch_screen_images);
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

        public Response UpdateGenericLaunchScreenImages(update_vm_generic_launch_screen_images obj_update_vm_generic_launch_screen_images )
        {
            Response response = new Response();
            try
            {
                generic_launch_screen_images _obj_generic_launch_screen_images = new generic_launch_screen_images();

                _obj_generic_launch_screen_images.generic_image_id = obj_update_vm_generic_launch_screen_images.generic_image_id;
                _obj_generic_launch_screen_images.default_text_colour = obj_update_vm_generic_launch_screen_images.default_text_colour;
                _obj_generic_launch_screen_images.mobile_path = obj_update_vm_generic_launch_screen_images.mobile_path;

                _DBContext.Attach(_obj_generic_launch_screen_images);
                _DBContext.Entry(_obj_generic_launch_screen_images).Property(p => p.default_text_colour).IsModified = true;
                _DBContext.Entry(_obj_generic_launch_screen_images).Property(p => p.mobile_path).IsModified = true;
                _DBContext.SaveChanges();

                audit_trail_for_generic_launch_screen_images obj_audit_trail_for_generic_launch_screen_images = new audit_trail_for_generic_launch_screen_images();

                obj_audit_trail_for_generic_launch_screen_images.generic_image_id = obj_update_vm_generic_launch_screen_images.generic_image_id;
                obj_audit_trail_for_generic_launch_screen_images.user_activity = "User App Business Bategories Edited !!";
                obj_audit_trail_for_generic_launch_screen_images.activity_by_user_id = obj_update_vm_generic_launch_screen_images.user_id;
                obj_audit_trail_for_generic_launch_screen_images.activity_timestamp = DateTime.UtcNow;
                _DBContext.Add(obj_audit_trail_for_generic_launch_screen_images);
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


        public Response GetGenericLaunchScreenImages(Int64 Generic_Image_Id)
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DBContext.generic_launch_screen_images.Where(x => x.generic_image_id == Generic_Image_Id)
                                 select new
                                 {
                                     generic_image_id = master.generic_image_id,
                                     generic_image_name = master.generic_image_name,
                                     generic_image_storage_path = master.generic_image_storage_path,
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


        public Response GetALLGenericLaunchScreenImages()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DBContext.generic_launch_screen_images
                                 select new
                                 {
                                     generic_image_id = master.generic_image_id,
                                     generic_image_name = master.generic_image_name,
                                     generic_image_storage_path = master.generic_image_storage_path,
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


       

        public Response DeleteGenericLaunchScreenImages(Int64 Generic_Image_Id)
        {
            Response response = new Response();
            try
            {
                var generic_launch_screen_images = _DBContext.generic_launch_screen_images.Where(z => z.generic_image_id == Generic_Image_Id).FirstOrDefault();
                _DBContext.generic_launch_screen_images.Remove(generic_launch_screen_images);
                _DBContext.SaveChanges();

                audit_trail_for_generic_launch_screen_images obj_audit_trail_for_generic_launch_screen_images = new audit_trail_for_generic_launch_screen_images();

                obj_audit_trail_for_generic_launch_screen_images.generic_image_id = generic_launch_screen_images.generic_image_id;
                obj_audit_trail_for_generic_launch_screen_images.user_activity = "User App Business Bategories Deleted !!";
                obj_audit_trail_for_generic_launch_screen_images.activity_by_user_id = generic_launch_screen_images.user_id;
                obj_audit_trail_for_generic_launch_screen_images.activity_timestamp = DateTime.UtcNow;
                 _DBContext.Add(obj_audit_trail_for_generic_launch_screen_images);
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



        public  Response DeleteALLGenericLaunchScreenImages()
        {
            Response response = new Response();
            try
            {
                var generic_launch_screen_images = _DBContext.generic_launch_screen_images.FirstOrDefault();
                _DBContext.generic_launch_screen_images.RemoveRange(generic_launch_screen_images);
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

        public Response GetALLAuditTrailForGenericLaunchScreenImages()
        {
            Response response = new Response();
            try
            {


                response.Data = (from master in _DBContext.audit_trail_for_generic_launch_screen_images
                                 select new
                                 {
                                     generic_image_id = master.generic_image_id,
                                     user_activity = master.user_activity,
                                     activity_by_user_id = master.activity_by_user_id,
                                     activity_timestamp = master.activity_timestamp        
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

