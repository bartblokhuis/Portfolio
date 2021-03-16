using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Helpers
{
    public class UploadImageHelper : IUploadImageHelper
    {
        #region Fields

        private readonly IWebHostEnvironment _hostingEnvironment;
        private static string[] AllowedExtensions = new string[] { ".svg", "jpg", "jpeg", "png" };

        #endregion

        #region Constructor

        public UploadImageHelper(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        #endregion

        #region Methods

        public string ValidateImage(IFormFile image)
        {
            string errorMessage = string.Empty;

            var fileExtension = Path.GetExtension(image.FileName).ToLower();
            if (!AllowedExtensions.Contains(fileExtension))
                return $"The given file extension is not allowed, please use one of the following file extensions: {GetAllwedFileExtensions()}";

            return errorMessage;
        }

        public async Task<string> UploadImage(IFormFile image)
        {
            var imageName = Path.GetFileNameWithoutExtension(image.FileName);
            var fileExtension = Path.GetExtension(image.FileName);
            var uniqueFileName = imageName + "_" + Convert.ToBase64String(Guid.NewGuid().ToByteArray()) + fileExtension;

            var uploadPath = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads");

            var filePath = Path.Combine(uploadPath, uniqueFileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);

            await image.CopyToAsync(fileStream);
            return filePath;
        }

        #region Utils

        private static string GetAllwedFileExtensions()
        {
            var allowedFileExtensionBuilder = new StringBuilder();
            foreach (var allowedExtension in AllowedExtensions)
            {
                allowedFileExtensionBuilder.Append(allowedExtension + ", ");
            }

            var allowedExtensions = allowedFileExtensionBuilder.ToString();

            return allowedExtensions.Substring(0, allowedExtensions.Length - 3);
        }

        #endregion

        #endregion

    }
}
