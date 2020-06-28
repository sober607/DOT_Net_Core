using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.ViewModels
{
    public class TerrainUploadViewModel
    {
        public IFormFile File { get; set; }
        public UploadStage Stage { get; set; }
    }

    public enum UploadStage
    {
        Upload,
        Completed
    }
}
