using Business.Abstract;
using Core.Helpers;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UploadManager : IUploadService
    {
        public IDataResult<string> ImageUpload(IFormFile file)
        {
            return FileHelper.ImageUpload(file);
        }
    }
}
