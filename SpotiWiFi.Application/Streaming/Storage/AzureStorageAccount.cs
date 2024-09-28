using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Application.Streaming.Storage
{
    public class AzureStorageAccount
    {
        private string AccountName { get; set; }
        private string AccessKey { get; set; }

        public AzureStorageAccount(IConfiguration configuration)
        {
            this.AccountName = configuration["AzureStorageAccount:AccountName"];
            this.AccessKey = configuration["AzureStorageAccount:AccessKey"];
        }

        public async Task<string> UploadImage(string base64Image)
        {
            //Converte a imagem em base64 para memória
            byte[] imageByte = Convert.FromBase64String(base64Image);

            MemoryStream stream = new MemoryStream(imageByte);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(this.AccountName, this.AccessKey);

            string blobUri = String.Format($"https://{this.AccountName}.blob.core.windows.net");

            var blobServiceClient = new BlobServiceClient(new Uri(blobUri), sharedKeyCredential);

            string fileName = $"{Guid.NewGuid().ToString().Replace("-", "")}.jpg";

            var blobContainer = blobServiceClient.GetBlobContainerClient("backdrop-images");

            BlobClient blobClient = blobContainer.GetBlobClient(fileName);

            await blobClient.UploadAsync(stream, true);

            return String.Format($"https://{this.AccountName}.blob.core.windows.net/backdrop-images/{fileName}");
        }
    }
}
