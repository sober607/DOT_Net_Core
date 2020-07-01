using Infestation.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.Services.Implementations
{
    public class FileProcessingChannel: IFileProcessingChannel
    {
        private Channel<IFormFile> _channel { get; set; }

        public FileProcessingChannel()
        {
            _channel = Channel.CreateUnbounded<IFormFile>();
        }

        public async Task SetAsync(IFormFile file)
        {
            await _channel.Writer.WriteAsync(file);
        }

        public void Set(IFormFile file)
        {
            _channel.Writer.TryWrite(file);
        }

        public IAsyncEnumerable<IFormFile> GetAllAsync()
        {
            return _channel.Reader.ReadAllAsync();
        }

        public IFormFile? Get()
        {
            if (_channel.Reader.TryRead(out var item))
            {
                return item;
            }
            else
            {
                return null;
            }
        }

    }
}
