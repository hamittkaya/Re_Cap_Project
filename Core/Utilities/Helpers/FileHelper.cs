using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile formFile)
        {
            var sourcepath = Path.GetTempFileName();
            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            var result = NewPath(formFile);
            File.Move(sourcepath, result);
            return result;
        }
        public static string Update(string sourcePath, IFormFile formFile)
        {
            var result = NewPath(formFile).ToString();
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static IResult Delete(string path)
        {
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


        private static string NewPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            string fileExtension = fileInfo.Extension;

            string path = Environment.CurrentDirectory + @"\wwwroot\images";
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
