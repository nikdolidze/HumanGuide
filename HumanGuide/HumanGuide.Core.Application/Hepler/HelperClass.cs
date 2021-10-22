using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Hepler
{
    public class HelperClass
    {
        public static async Task<string> UploadImage(IFormFile imageFile)
        {
            var imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = $@"Images/{imageName}";
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imagePath;
        }
        public static List<ConnecteHuman> CreateListOfConnecteHuman(int humanId, List<SetConnecteHumanDto> connecteHumans)
        {
            List<ConnecteHuman> list = new();

            foreach (var connecteHuman in connecteHumans)
            {
                list.Add(new ConnecteHuman { HumanId = humanId, ConnecteHumanId = connecteHuman.ConnecteHumanId, ConnectionType = connecteHuman.ConnectionType });
            }
            return list;
        }

        public static List<Human2Phone> CreateListOfHuman2Phone(int humanId, List<int> phoneIds)
        {
            List<Human2Phone> list = new();


            foreach (var item in phoneIds)
            {
                list.Add(new Human2Phone { HumanId = humanId, PhoneId = item });
            }
            return list;
        }
    }
}
