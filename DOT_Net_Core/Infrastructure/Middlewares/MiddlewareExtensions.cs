using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSendRequestNotification(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SendRequestNotificationMiddleWare>();
        }
    }
}
