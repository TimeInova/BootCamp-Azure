namespace API.Data
{
    public class IntegrationSettings {
        public IntegrationSettings(string endpoint, string apikey)
        {
            Endpoint = endpoint;
            ApiKey = apikey;
        }
        
        public string Endpoint { get; set; }
        public string ApiKey { get; set; }
    }
}