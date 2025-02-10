using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopMicroservices.GatewayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GatewayController> logger;

        public GatewayController(IHttpClientFactory httpClientFactory, ILogger<GatewayController> logger)
        {
            _httpClient = httpClientFactory.CreateClient("IgnoreSSL");
            this.logger = logger;
        }

        [HttpGet("consul-conection-info")]
        public async Task<IActionResult> GetConsulConectionInfo()
        {
            return Ok("CHEGUEI NO ENDPOINT");
            var consulUrl = "http://localhost:8500/v1/agent/services";
            var response = await _httpClient.GetAsync(consulUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }

            return StatusCode((int)response.StatusCode, "Erro ao consultar o Consul");
        }
    }
}
