using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNet_AzureUpload.Service
{
    public interface IDocumentService
    {
        Task<string> UploadDocument(string path, IFormFile document);
    }
}
