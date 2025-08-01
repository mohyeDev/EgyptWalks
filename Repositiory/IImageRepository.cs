using EgyptWalks.Models.Domain;

namespace EgyptWalks.Repositiory
{
    public interface IImageRepository
    {

        public Task<Image> Upload(Image image);
    }
}
