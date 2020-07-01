using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.Services.Interfaces
{
    public interface IExampleRestClient
    {
        public string FileName { get; set; }
        string GetFileName();
        byte[] GetFile();
        void UploadFile(IFormFile file);
    }
}
