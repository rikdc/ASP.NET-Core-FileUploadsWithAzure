using Microsoft.AspNetCore.Http;
using Moq;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace AspNet_AzureUpload.Tests.Infrastructure
{
    public class AzureDocumentServiceTest
    {
        private IFormFile GetUploadedFile()
        {
            var fileMock = new Mock<IFormFile>();

            var s = "Hello World from a Fake File";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(s);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(m => m.OpenReadStream()).Returns(ms);

            return fileMock.Object;
        }

        [Fact (Skip = "Azure sealed classes prevent mocking")]
        public async Task UploadFromStreamAsync_Called()
        {
            /*
            var mockBlobUri = new Uri("http://bogus/myaccount/blob");
            var mockBlob = new Mock<CloudBlockBlob>(MockBehavior.Strict, mockBlobUri);
            
            var mockCloudContainer = new Mock<CloudBlobContainer>(MockBehavior.Strict, mockBlobUri);

            mockCloudContainer.Setup(container => container.CreateIfNotExistsAsync()).ReturnsAsync(true);

            mockCloudContainer.Setup(container => container.GetBlobReferenceFromServerAsync(It.IsAny<string>())).ReturnsAsync(mockBlob.Object);

            var mockCloudClient = new Mock<CloudBlobClient>();
            mockCloudClient.Setup(c => c.GetBlobReferenceFromServerAsync(mockBlobUri)).ReturnsAsync(mockBlob.Object);

            var mockCloudAccount = new Mock(classof(CloudStorageAccount>>();
            mockCloudAccount.Setup(a => a.CreateCloudBlobClient()).Returns(mockCloudClient.Object);


            var uploadService = new AzureDocumentService(mockCloudAccount.Object, null);

            var file = GetUploadedFile();

            await uploadService.UploadDocument("docs", file);
            */
        }
    }
}
