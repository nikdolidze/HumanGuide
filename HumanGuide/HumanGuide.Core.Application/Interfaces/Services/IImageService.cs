using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Interfaces.Services
{
    public interface IImageService
    {
        Task<string> UploadImage(IFormFile imageFile);
    }
}
