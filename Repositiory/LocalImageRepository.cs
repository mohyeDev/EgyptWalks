using EgyptWalks.Data;
using EgyptWalks.Models.Domain;

namespace EgyptWalks.Repositiory
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly EgypWalksDbContext egypWalksDbContext;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor,EgypWalksDbContext egypWalksDbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.egypWalksDbContext = egypWalksDbContext;
        }
        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", image.FileName,image.FileExtenstion);

            using var stream = new FileStream(localFilePath,FileMode.Create);
            await image.File.CopyToAsync(stream);


            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtenstion}";
            image.FilePath = urlFilePath;

            await egypWalksDbContext.AddAsync(image);
            await egypWalksDbContext.SaveChangesAsync();


            return image; 
            
        }
    }
}
