using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace AspNet_AzureUpload.Service.Infrastructure
{
    public class AzureDocumentService : IDocumentService
    {
        public Task<string> UploadDocument(IFormFile document)
        {
            throw new NotImplementedException();
        }
    }
}
