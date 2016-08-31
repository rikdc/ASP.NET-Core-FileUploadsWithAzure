using Microsoft.AspNetCore.Mvc;

namespace AspNet_AzureUpload.Controllers
{
    [Route("api/[controller]")]
    public class UploadsController
    {
        public UploadsController()
        {

        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
