using Core.Utilities.Results;
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
            File.Move(ImagePath, result.newPath);
            return result.Path2.Replace("\\", "/");
        }
        public static IResult Delete(string path)
        {
            path = path.Replace("/", "\\");

            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static string Update(string ImagePath, IFormFile file)
        {
            var result = NewPath(file);
            if (ImagePath.Length > 0)
            {
                using (var stream = new FileStream(result.newPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(ImagePath);
            return result.Path2.Replace("\\", "/");
        }
        public static (string newPath, string Path2) NewPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            var path = Guid.NewGuid().ToString()+ fileExtension;
            string newPath = Environment.CurrentDirectory + @"\wwwroot\Images";
            string result = $@"{newPath }\{path}";
            string imageName = @"Images\" + path;

            return (result, imageName);
        }
    }
}
