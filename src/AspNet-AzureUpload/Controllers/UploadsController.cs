using AspNet_AzureUpload.Service;
using AspNet_AzureUpload.Service.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNet_AzureUpload.Controllers
{
    [Route("api/[controller]")]
    public class UploadsController
    {
        private readonly IDocumentService _documentService;

        public UploadsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost]
        public async Task Post([FromForm] IFormFile upload)
        {
            await _documentService.UploadDocument("docs", upload);
        }
    }
}
