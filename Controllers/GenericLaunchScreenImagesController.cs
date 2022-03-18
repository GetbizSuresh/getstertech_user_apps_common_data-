using getstertech_user_apps_common_data.GetsterTech_DbContext;
using getstertech_user_apps_common_data.Models;
using getstertech_user_apps_common_data.Repository.Generic_Launch_Screen_Images;
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
   // [Route("api/[controller]")]
    [ApiController]
    public class GenericLaunchScreenImagesController : ControllerBase
    {

        private IGenericLaunchScreenImagesRepository _genericLaunchScreenImagesRepository;

        public UserAppsCommonDataDb_DbContext _DBContext;

        private IConfiguration _configuration;

        public GenericLaunchScreenImagesController(IGenericLaunchScreenImagesRepository genericLaunchScreenImagesRepository, UserAppsCommonDataDb_DbContext DBContext, IConfiguration configuration)
        {
            _genericLaunchScreenImagesRepository = genericLaunchScreenImagesRepository;

            _DBContext = DBContext;

            _configuration = configuration;
        }


        [HttpPost]
        [Route("api/AddGenericLaunchScreenImages")]
        public async Task<IActionResult> AddGenericLaunchScreenImages(List<IFormFile> generic_image_storage_paths ,[FromForm] generic_launch_screen_images obj_generic_launch_screen_images)
        {
            try
            {
                generic_launch_screen_images mainobj = new generic_launch_screen_images();

                string Serverpath = _configuration.GetSection("Serverpath").Value;
                string LiveServerpath = _configuration.GetSection("LiveServerpath").Value;

                if (Convert.ToString(generic_image_storage_paths) != null )
                {
                    var UserIdpath = LiveServerpath + obj_generic_launch_screen_images.user_id;

                    if (!(Directory.Exists(UserIdpath)))
                    {
                        Directory.CreateDirectory(UserIdpath);

                        generic_image_storage_paths.ForEach(async file =>
                        {
                            if (file.Length <= 0) return;
                            var filePath = Path.Combine(UserIdpath, file.FileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        });

                        obj_generic_launch_screen_images.generic_image_storage_path = obj_generic_launch_screen_images.generic_image_name; // assign filename
                    }                      
                    else
                    {
                        generic_image_storage_paths.ForEach(async file =>
                        {
                            if (file.Length <= 0) return;
                            var filePath = Path.Combine(UserIdpath, file.FileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        });

                        obj_generic_launch_screen_images.generic_image_storage_path = obj_generic_launch_screen_images.generic_image_name; // assign filename  
                    }
                }

                if (obj_generic_launch_screen_images.mobile_path != null)
                {
                    var UserIdpath = LiveServerpath + obj_generic_launch_screen_images.user_id;

                    if (!(Directory.Exists(UserIdpath)))
                    {
                        byte[] imageBytes = Convert.FromBase64String(obj_generic_launch_screen_images.mobile_path);
                        string file_name = obj_generic_launch_screen_images.mobile_path_name;

                        Directory.CreateDirectory(UserIdpath);
                        //  if (obj_file_master.choose_photo.Length <= 0) return BadRequest();
                        var filePath = Path.Combine(UserIdpath, file_name);
                        System.IO.File.WriteAllBytes(filePath, imageBytes);
                        obj_generic_launch_screen_images.mobile_path = file_name; // assign filename
                    }
                    else
                    {
                        byte[] imageBytes = Convert.FromBase64String(obj_generic_launch_screen_images.mobile_path);
                        string file_name = obj_generic_launch_screen_images.mobile_path_name;

                        Directory.CreateDirectory(UserIdpath);
                        //  if (obj_file_master.choose_photo.Length <= 0) return BadRequest();
                        var filePath = Path.Combine(UserIdpath, file_name);
                        System.IO.File.WriteAllBytes(filePath, imageBytes);
                        obj_generic_launch_screen_images.mobile_path = file_name; // assign filename
                    }
                }





                var messages = _genericLaunchScreenImagesRepository.AddGenericLaunchScreenImages(obj_generic_launch_screen_images, mainobj);
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
        [Route("api/UpdateGenericLaunchScreenImages")]
        public IActionResult UpdateGenericLaunchScreenImages(update_vm_generic_launch_screen_images obj_update_vm_generic_launch_screen_images)
        {
            try
            {

                string LiveServerpath = _configuration.GetSection("LiveServerpath").Value;


                if (obj_update_vm_generic_launch_screen_images.mobile_path != null)
                {
                    var UserIdpath = LiveServerpath + obj_update_vm_generic_launch_screen_images.user_id;

                    if (!(Directory.Exists(UserIdpath)))
                    {
                        byte[] imageBytes = Convert.FromBase64String(obj_update_vm_generic_launch_screen_images.mobile_path);
                        string file_name = obj_update_vm_generic_launch_screen_images.mobile_path_name;

                        Directory.CreateDirectory(UserIdpath);
                        //  if (obj_file_master.choose_photo.Length <= 0) return BadRequest();
                        var filePath = Path.Combine(UserIdpath, file_name);
                        System.IO.File.WriteAllBytes(filePath, imageBytes);
                        obj_update_vm_generic_launch_screen_images.mobile_path = file_name; // assign filename
                    }
                    else
                    {
                        byte[] imageBytes = Convert.FromBase64String(obj_update_vm_generic_launch_screen_images.mobile_path);
                        string file_name = obj_update_vm_generic_launch_screen_images.mobile_path_name;

                        Directory.CreateDirectory(UserIdpath);
                        //  if (obj_file_master.choose_photo.Length <= 0) return BadRequest();
                        var filePath = Path.Combine(UserIdpath, file_name);
                        System.IO.File.WriteAllBytes(filePath, imageBytes);
                        obj_update_vm_generic_launch_screen_images.mobile_path = file_name; // assign filename
                    }
                }










                var messages = _genericLaunchScreenImagesRepository.UpdateGenericLaunchScreenImages(obj_update_vm_generic_launch_screen_images);
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
        [Route("api/GetGenericLaunchScreenImages")]
        public IActionResult GetALLGenericLaunchScreenImages(Int64 Generic_Image_Id)
        {
            try
            {
                var messages = _genericLaunchScreenImagesRepository.GetGenericLaunchScreenImages(Generic_Image_Id);
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
        [Route("api/GetALLGenericLaunchScreenImages")]
        public IActionResult GetALLGenericLaunchScreenImages( )
        {
            try
            {
                var messages = _genericLaunchScreenImagesRepository.GetALLGenericLaunchScreenImages();
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
        [Route("api/DeleteGenericLaunchScreenImages")]
        public IActionResult DeleteALLGenericLaunchScreenImages(Int64 Generic_Image_Id )
        {
            try
            {
                var messages = _genericLaunchScreenImagesRepository.DeleteGenericLaunchScreenImages(Generic_Image_Id);
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
        [Route("api/DeleteALLGenericLaunchScreenImages")]
        public  async Task<IActionResult> DeleteALLGenericLaunchScreenImages()
        {
            Response response = new Response();
            try
            {
                var generic_launch_screen_images = _DBContext.generic_launch_screen_images.ToList();
                 _DBContext.RemoveRange(generic_launch_screen_images);
                await _DBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return new JsonResult(" All Data's Deleted Successfully !!");

        }






        [HttpGet]
        [Route("api/GetALLAuditTrailForGenericLaunchScreenImages")]
        public IActionResult GetALLAuditTrailForGenericLaunchScreenImages( )
        {
            try
            {
                var messages = _genericLaunchScreenImagesRepository.GetALLAuditTrailForGenericLaunchScreenImages();
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
