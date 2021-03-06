using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Images
{
    public class ImageCRUD
    {
        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName();
            if (file.Length>0)
            {
                using (var stream=new FileStream(sourcePath,FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var result = NewPath(file);
            File.Move(sourcePath, result);
            return result;
        }
        public static string Update(IFormFile file,string sourcePath)
        {
            var updatedPath = NewPath(file);
            if (sourcePath.Length>0)
            {
                using (var stream=new FileStream(updatedPath,FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return updatedPath;
        }

        public static void Delete(string imagePath)
        {
            File.Delete(imagePath);
        }
        public static string NewPath(IFormFile file) 
        {
            FileInfo fileInfo = new FileInfo(file.FileName); 
            string fileExtension = fileInfo.Extension;
            var newImageName = Guid.NewGuid().ToString() + "_" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + fileExtension;
            string newPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\WebAPI\Images");
            string result = $@"{newPath}\{newImageName}";
            return result;
        }
    }
}
