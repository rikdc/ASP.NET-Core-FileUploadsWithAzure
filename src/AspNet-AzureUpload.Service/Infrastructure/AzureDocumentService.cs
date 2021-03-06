﻿using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace AspNet_AzureUpload.Service.Infrastructure
{
    public class AzureDocumentService : IDocumentService
    {
        private readonly IOptions<AzureSettings> _options;
        private readonly CloudStorageAccount _storageAccount;

        public AzureDocumentService(CloudStorageAccount storageAccount, IOptions<AzureSettings> options)
        {
            _storageAccount = storageAccount;
            _options = options;
        }

        public async Task<string> UploadDocument(string path, IFormFile document)
        {
            var container = _storageAccount.CreateCloudBlobClient().GetContainerReference(_options.Value.ContainerName);
            
            await container.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Container, new BlobRequestOptions(), new OperationContext());

            var fileName = (ContentDispositionHeaderValue.Parse(document.ContentDisposition).FileName).Trim('"').ToLower();
            var blob = path + "/" + fileName;

            var blockBlob = await container.GetBlobReferenceFromServerAsync(blob);
            
            blockBlob.Properties.ContentType = document.ContentType;

            using (var imageStream = document.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(imageStream);
            }
            
            return blockBlob.Uri.ToString();
        }
    }
}
