using getstertech_user_apps_common_data.GetsterTech_DbContext;
using getstertech_user_apps_common_data.Models;
using getstertech_user_apps_common_data.Repository.Business_Specific_Launch_Screen_Images;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace getstertech_user_apps_common_data.Controllers
{
  //  [Route("api/[controller]")]
    [ApiController]
    public class BusinessSpecificLaunchScreenImagesController : ControllerBase
    {
        private IBusinessSpecificLaunchScreenImagesRepository _businessSpecificLaunchScreenImagesRepository;

        public  UserAppsCommonDataDb_DbContext _DBContext;

        private IConfiguration _configuration;
        public BusinessSpecificLaunchScreenImagesController(IBusinessSpecificLaunchScreenImagesRepository businessSpecificLaunchScreenImagesRepository, UserAppsCommonDataDb_DbContext DBContext, IConfiguration configuration)
        {
            _businessSpecificLaunchScreenImagesRepository = businessSpecificLaunchScreenImagesRepository;
            _DBContext = DBContext;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("api/AddBusinessSpecificLaunchScreenImages")]
        public async Task<IActionResult> AddBusinessSpecificLaunchScreenImages(List<IFormFile> business_category_image_storage_paths ,[FromForm]business_specific_launch_screen_images obj_business_specific_launch_screen_images)
        {
            try
            { 

                //  string Serverpath = _configuration.GetSection("Serverpath").Value;
                string LiveServerpath = _configuration.GetSection("LiveServerpath").Value;

                if (Convert.ToString(business_category_image_storage_paths) != null)
                {
                        var UserIdpath = LiveServerpath + obj_business_specific_launch_screen_images.uploaded_by_user_id;
                    if (!(Directory.Exists(UserIdpath)))
                    {
                        Directory.CreateDirectory(UserIdpath);

                        business_category_image_storage_paths.ForEach(async file =>
                        {
                            if (file.Length <= 0) return;
                            var filePath = Path.Combine(UserIdpath, file.FileName);                      
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        });

                        obj_business_specific_launch_screen_images.business_category_image_storage_path = obj_business_specific_launch_screen_images.business_category_image_name;
                    }
                    else
                    {
                        Directory.CreateDirectory(UserIdpath);

                        business_category_image_storage_paths.ForEach(async file =>
                        {
                            if (file.Length <= 0) return;
                            var filePath = Path.Combine(UserIdpath, file.FileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);

                            }
                        });
                        obj_business_specific_launch_screen_images.business_category_image_storage_path = obj_business_specific_launch_screen_images.business_category_image_name;
                    }
                }


                if (obj_business_specific_launch_screen_images.mobile_path != null)
                {
                    var UserIdpath = LiveServerpath + obj_business_specific_launch_screen_images.uploaded_by_user_id;

                    if (!(Directory.Exists(UserIdpath)))
                    {
                        byte[] imageBytes = Convert.FromBase64String(obj_business_specific_launch_screen_images.mobile_path);
                        string file_name = obj_business_specific_launch_screen_images.mobile_path_name;

                        Directory.CreateDirectory(UserIdpath);
                        //  if (obj_file_master.choose_photo.Length <= 0) return BadRequest();
                        var filePath = Path.Combine(UserIdpath, file_name);
                        System.IO.File.WriteAllBytes(filePath, imageBytes);
                        obj_business_specific_launch_screen_images.mobile_path = file_name; // assign filename
                    }
                    else
                    {
                        byte[] imageBytes = Convert.FromBase64String(obj_business_specific_launch_screen_images.mobile_path);
                        string file_name = obj_business_specific_launch_screen_images.mobile_path_name;

                        Directory.CreateDirectory(UserIdpath);
                        //  if (obj_file_master.choose_photo.Length <= 0) return BadRequest();
                        var filePath = Path.Combine(UserIdpath, file_name);
                        System.IO.File.WriteAllBytes(filePath, imageBytes);
                        obj_business_specific_launch_screen_images.mobile_path = file_name; // assign filename
                    }

                }








                var messages = _businessSpecificLaunchScreenImagesRepository.AddBusinessSpecificLaunchScreenImages(obj_business_specific_launch_screen_images);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/UpdateBusinessSpecificLaunchScreenImages")]
        public IActionResult UpdateBusinessSpecificLaunchScreenImages(update_vm_business_specific_launch_screen_images obj_update_vm_business_specific_launch_screen_images)
        {
            try
            {
                update_vm_business_specific_launch_screen_images mainobj = new update_vm_business_specific_launch_screen_images();

                string LiveServerpath = _configuration.GetSection("LiveServerpath").Value;

                if (obj_update_vm_business_specific_launch_screen_images.mobile_path != null)
                {
                    var UserIdpath = LiveServerpath + obj_update_vm_business_specific_launch_screen_images.uploaded_by_user_id;

                    if (!(Directory.Exists(UserIdpath)))
                    {
                        byte[] imageBytes = Convert.FromBase64String(obj_update_vm_business_specific_launch_screen_images.mobile_path);
                        string file_name = obj_update_vm_business_specific_launch_screen_images.mobile_path_name;

                        Directory.CreateDirectory(UserIdpath);
                        //  if (obj_file_master.choose_photo.Length <= 0) return BadRequest();
                        var filePath = Path.Combine(UserIdpath, file_name);
                        System.IO.File.WriteAllBytes(filePath, imageBytes);
                        obj_update_vm_business_specific_launch_screen_images.mobile_path = file_name; // assign filename
                    }
                    else
                    {
                        byte[] imageBytes = Convert.FromBase64String(obj_update_vm_business_specific_launch_screen_images.mobile_path);
                        string file_name = obj_update_vm_business_specific_launch_screen_images.mobile_path_name;

                        Directory.CreateDirectory(UserIdpath);
                        //  if (obj_file_master.choose_photo.Length <= 0) return BadRequest();
                        var filePath = Path.Combine(UserIdpath, file_name);
                        System.IO.File.WriteAllBytes(filePath, imageBytes);
                        obj_update_vm_business_specific_launch_screen_images.mobile_path = file_name; // assign filename
                    }

                }














                var messages = _businessSpecificLaunchScreenImagesRepository.UpdateBusinessSpecificLaunchScreenImages(obj_update_vm_business_specific_launch_screen_images, mainobj);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("api/GetBusinessSpecificLaunchScreenImages")]
        public IActionResult GetBusinessSpecificLaunchScreenImages(Int64 Business_Category_Image_Id)
        {
            try
            {
                var messages = _businessSpecificLaunchScreenImagesRepository.GetBusinessSpecificLaunchScreenImages(Business_Category_Image_Id);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        [HttpGet]
        [Route("api/GetBusinessSpecificLaunchScreenImagesBy_Business_Category_Id")]
        public IActionResult GetBusinessSpecificLaunchScreenImagesBy_Business_Category_Id(string User_App_Business_Category_Id)
        {
            try
            {
                var messages = _businessSpecificLaunchScreenImagesRepository.GetBusinessSpecificLaunchScreenImagesBy_Business_Category_Id(User_App_Business_Category_Id);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        [HttpGet]
        [Route("api/GetALLBusinessSpecificLaunchScreenImages")]
        public IActionResult  GetALLBusinessSpecificLaunchScreenImages()
        {
            try
            {
                var messages = _businessSpecificLaunchScreenImagesRepository.GetALLBusinessSpecificLaunchScreenImages();
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("api/DeleteBusinessSpecificLaunchScreenImages")]
        public IActionResult DeleteBusinessSpecificLaunchScreenImages(Int64 Business_Category_Image_Id)
        {
            try
            {
                var messages = _businessSpecificLaunchScreenImagesRepository.DeleteBusinessSpecificLaunchScreenImages( Business_Category_Image_Id);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }













        [HttpDelete]
        [Route("api/DeleteALLBusinessSpecificLaunchScreenImages")]
        public async Task<IActionResult> DeleteALLBusinessSpecificLaunchScreenImages()
        {
            try
            {
                var business_specific_launch_screen_images = _DBContext.business_specific_launch_screen_images.ToList();
                _DBContext.RemoveRange(business_specific_launch_screen_images);
                await _DBContext.SaveChangesAsync();
      
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return new JsonResult("All Data's Deleted Successfully !!");

        }










        [HttpGet]
        [Route("api/GetALLAuditTrailForBusinessSpecificLaunchScreenImages")]
        public IActionResult GetALLAuditTrailForBusinessSpecificLaunchScreenImages( )
        {
            try
            {
                var messages = _businessSpecificLaunchScreenImagesRepository.GetALLAuditTrailForBusinessSpecificLaunchScreenImages();
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }




    }
}
