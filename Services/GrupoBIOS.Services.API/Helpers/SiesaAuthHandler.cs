namespace GrupoBIOS.Services.API.Helpers
{
    public class SiesaAuthHandler : DelegatingHandler
    {
        private readonly string _conniKey;
        private readonly string _conniToken;

        public SiesaAuthHandler(IConfiguration config)
        {
            _conniKey = config["ConfigSiesa:ConniKey"]!;
            _conniToken = config["ConfigSiesa:ConniToken"]!;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Agrega los headers a todas las requests
            request.Headers.Add("conniKey", _conniKey);
            request.Headers.Add("conniToken", _conniToken);

            return await base.SendAsync(request, cancellationToken);
        }

    }
}
