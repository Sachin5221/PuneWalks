using Microsoft.AspNetCore.Mvc;
using PunkeWalks.UI.Models.DTO;

namespace PunkeWalks.UI.Controllers
{
    public class WalksController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public WalksController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<WalksDTO>response = new List<WalksDTO>();
            try
            {
                //Get All Regions from Web API
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7135/api/Walks");

                httpResponseMessage.EnsureSuccessStatusCode();

               response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<WalksDTO>>());

              

            }
            catch (Exception ex) 
            {

                throw;
            }
            return View(response);
        }
    }
}
