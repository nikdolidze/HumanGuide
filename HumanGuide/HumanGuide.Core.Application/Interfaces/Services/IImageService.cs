using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Interfaces.Services
{
    public interface IImageService
    {
        Task<string> UploadImage(IFormFile imageFile);
    }
}
