using Infestation.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.Services.Implementations
{
    public class ExampleRestClient : IExampleRestClient
    {
        public string FileName { get; set; }

        public string GetFileName()
        {
            var client = new RestClient("http://localhost:50080");
            var request = new RestRequest("FileName", Method.GET);
            var result = client.Execute(request);
            if (result != null)
            {
                FileName = (client.Execute(request)).Headers.FirstOrDefault(header => header.Name == "File-Name").Value.ToString();
            }

            return FileName;
        }

        public byte[] GetFile()
        {
            var client = new RestClient("http://localhost:50080");
            var request = new RestRequest("File", Method.GET);
            var result = client.Execute(request).RawBytes;
            if (result != null)
            {
                FileName = (client.Execute(request)).Headers.FirstOrDefault(header => header.Name == "File-Name").Value.ToString();
            }
            return result;
        }

        public void UploadFile(IFormFile file)
        {
            var client = new RestClient("http://localhost:50080");
            var request = new RestRequest("File", Method.POST);
            if (file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var imageBytes = ms.ToArray();
                    request.AddJsonBody(Convert.ToBase64String(imageBytes));
                }

                request.AddQueryParameter("fileName", file.FileName);
                client.Execute(request);
            }
        }

    }
}
