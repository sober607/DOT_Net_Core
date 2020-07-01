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
        private string _path { get; set; } = "wwwroot/photo51.jpg";

        [HttpGet("File")]
        public FileContentResult GetFile()
        {
            var fileBytes = System.IO.File.ReadAllBytes(_path);
            HttpContext.Response.Headers.Add("File-Name", System.IO.Path.GetFileName(_path));
            return new FileContentResult(fileBytes, "image/jpeg");
        }

        [HttpGet("FileName")] // for cache and optimisation on client side, check of filename without downloading file
        public void GetFileName()
        {
            HttpContext.Response.Headers.Add("File-Name", System.IO.Path.GetFileName(_path));
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
