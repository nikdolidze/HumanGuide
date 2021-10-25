using HumanGuide.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> UploadImage(IFormFile imageFile)
        {
            var imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var folderName = "Images";
            var imagePath = $@"{folderName}/{imageName}";
            Directory.CreateDirectory(folderName);

            await using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imagePath;
        }
    }
}
