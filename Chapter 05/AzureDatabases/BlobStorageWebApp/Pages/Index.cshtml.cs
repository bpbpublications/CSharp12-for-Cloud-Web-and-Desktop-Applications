using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlobStorageWebApp.Database;

namespace BlobStorageWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async void OnGet()
        {
            await CreateBlobAsync();
        }
        public async Task CreateBlobAsync()
        {
            // Get a reference to the container
            BlobContainerClient container = new BlobContainerClient("DefaultEndpointsProtocol=https;AccountName=samplethiagostorage;AccountKey=beSfcQhP9KcDeznMNlyLXgEJyDMXrgjaF9+AmmPksHgQvftuUbdMcUQp5yQutGWm7tKjBIm33o4G+AStn05yfA==;EndpointSuffix=core.windows.net", "sampleblobcontainer");

            await container.UploadBlobAsync("sampleBlob", BinaryData.FromObjectAsJson<SampleBlob>(new SampleBlob
            { Id = 0, Description = "testing description", CreationDate = DateTime.Now }));
        }
    }
}