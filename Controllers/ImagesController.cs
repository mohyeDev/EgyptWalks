using EgyptWalks.Models.DTo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgyptWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpPost("Upload")]

        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto imageUploadRequestDto)
        {
            ValidateFileUpload(imageUploadRequestDto);

            if(ModelState.IsValid)
            {

            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto imageUploadRequestDto)
        {

            var allwedExtension = new string[] { ".jpg", ".jpeg", ".png" };
            if(!allwedExtension.Contains(Path.GetExtension(imageUploadRequestDto.File.FileName)) == false)
            {
                ModelState.AddModelError("file","unsupported File Extension!");

            }

            if(imageUploadRequestDto.File.Length> 10485760)
            {
                ModelState.AddModelError("File", "FIle Size More Than 10MB");
            }
        }
    }
}
