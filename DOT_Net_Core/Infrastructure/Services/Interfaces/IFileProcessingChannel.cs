using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.Services.Interfaces
{
    public interface IFileProcessingChannel
    {

        public  Task SetAsync(IFormFile file);

        public void Set(IFormFile file);

        public IAsyncEnumerable<IFormFile> GetAllAsync();

    }
}
