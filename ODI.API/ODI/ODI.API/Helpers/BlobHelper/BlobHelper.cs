using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ODI.API.Helpers.BlobHelper
{
    public class BlobHelper
    {
        public  string UploadImageToFolder(IFormFile uploadImage, IHostingEnvironment _hostingEnvironment)
        {
            string imagePath = string.Empty;
            if (uploadImage != null && uploadImage.Length > 0)
            {
                var upload = Path.Combine(_hostingEnvironment.WebRootPath, "Documents//");
                using (FileStream fs = new FileStream(Path.Combine(upload, uploadImage.FileName), FileMode.Create))
                {
                      uploadImage.CopyToAsync(fs);
                }
                imagePath = "/Documents/" + uploadImage.FileName;
            }

            return imagePath;
        }
    }
}
