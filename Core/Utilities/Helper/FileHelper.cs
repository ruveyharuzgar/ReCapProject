using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var ImagePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(ImagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var result = NewPath(file);
            File.Move(ImagePath, result);
            return result;
        }
        public static void Delete(string path)
        {
            File.Delete(path);
        }
        public static string Update(string ImagePath, IFormFile file)
        {
            var result = NewPath(file);
            if (ImagePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(ImagePath);
            return result;
        }
        public static string NewPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
            string path = Environment.CurrentDirectory + @"\wwwroot\Images";
            string result = $@"{path}\{newPath}";

            return result;
        }
    }
}
