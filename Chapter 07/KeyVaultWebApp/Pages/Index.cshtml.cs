using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KeyVaultWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string Message { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            try
            {
                SecretClientOptions options = new SecretClientOptions()
                {
                    Retry =
                    {
                        Delay= TimeSpan.FromSeconds(2),
                        MaxDelay = TimeSpan.FromSeconds(16),
                        MaxRetries = 5,
                        Mode = RetryMode.Exponential
                     }
                };
                var client = new SecretClient(new Uri("https://keyvaultthiago.vault.azure.net/"), new DefaultAzureCredential(), options);

                KeyVaultSecret secret = client.GetSecret("thiagosecret");

                Message = secret.Value;
            }
            catch (Exception ex)
            {
                
                Message = "An error ocurred while trying to retrieve the secret";
            }

        }
    }
}