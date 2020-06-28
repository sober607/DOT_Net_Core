using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    public class FileController: ControllerBase
    {
        [HttpGet("File")]
        public FileContentResult GetFile()
        {
            var path = "wwwroot/photo51.jpg";
            var fileBytes = System.IO.File.ReadAllBytes(path);
            HttpContext.Response.Headers.Add("File-Name", System.IO.Path.GetFileName(path));
            return new FileContentResult(fileBytes, "image/jpeg");
        }

        [HttpPost("File")]
        public void UploadFile([FromBody]string file, [FromQuery]string fileName, [FromServices]IWebHostEnvironment webHost)
        {
            var fileBytes = Convert.FromBase64String(file);
            var filePath = Path.Combine(webHost.WebRootPath, fileName);
            System.IO.File.WriteAllBytes(filePath, fileBytes);
        }
    }
}
