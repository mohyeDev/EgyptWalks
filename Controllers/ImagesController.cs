using AutoMapper;
using EgyptWalks.Models.Domain;
using EgyptWalks.Models.DTo;
using EgyptWalks.Repositiory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgyptWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        [HttpPost("Upload")]

        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto imageUploadRequestDto)
        {
            ValidateFileUpload(imageUploadRequestDto);

            if(ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    File = imageUploadRequestDto.File,
                    FileExtenstion = Path.GetExtension(imageUploadRequestDto.File.Name),
                    FileSizeInBytes = imageUploadRequestDto.File.Length,
                    FileName = imageUploadRequestDto.FileName,
                    FileDescription = imageUploadRequestDto.FileDescription,
                    
                };

                await imageRepository.Upload(imageDomainModel);
                return Ok(imageDomainModel);

            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto imageUploadRequestDto)
        {

            var allwedExtension = new string[] { ".jpg", ".jpeg", ".png" };
            if(allwedExtension.Contains(Path.GetExtension(imageUploadRequestDto.File.FileName)) == false)
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
