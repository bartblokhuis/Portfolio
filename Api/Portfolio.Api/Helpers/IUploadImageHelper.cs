using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Portfolio.Helpers
{
    public interface IUploadImageHelper
    {
        string ValidateImage(IFormFile image);

        Task<string> UploadImage(IFormFile image);
    }
}
