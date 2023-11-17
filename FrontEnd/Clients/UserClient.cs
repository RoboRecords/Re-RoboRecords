using FrontEnd.Models;

namespace FrontEnd.Data
{
    public class UserClient
    {
        private HttpClient _httpClient;
        private ILogger<UserClient> _logger;

        public UserClient(HttpClient httpClient, ILogger<UserClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        
    }
}