using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.Services.Interfaces
{
    public interface IMessageService
    {
        void SendMessage(string type, string text);
    }
}
