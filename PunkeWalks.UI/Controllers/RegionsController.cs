﻿using Microsoft.AspNetCore.Mvc;
using PunkeWalks.UI.Models;
using PunkeWalks.UI.Models.DTO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;

namespace PunkeWalks.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionDTO> response = new List<RegionDTO>();
            try
            {
                // Get All Regions from Web API
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7135/api/regions");

                httpResponseMessage.EnsureSuccessStatusCode();

                var regions = await httpResponseMessage.Content.ReadFromJsonAsync<List<RegionDTO>>();
                if (regions != null)
                {
                    response.AddRange(regions);
                }
            }
            catch (Exception)
            {
                // Log the Exception
                throw;
            }
            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel model)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7135/api/regions/"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var respose = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDTO>();

            if (respose is not null)
            {
                return RedirectToAction("Index", "Regions");
            }

            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            
 
                var client = httpClientFactory.CreateClient();

                var response = await client.GetFromJsonAsync<RegionDTO>($"https://localhost:7135/api/regions/{id.ToString()}");

                if (response != null)
                {
                    return View(response);
                }
                return View(null);
   
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RegionDTO request)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7135/api/regions/{request.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var respose = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDTO>();

            if (respose is not null)
            {
                return RedirectToAction("Edit", "Regions");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(RegionDTO request)
        {
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.DeleteAsync($"https://localhost:7135/api/regions/{request.Id}");

                httpResponseMessage.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Regions");
            }
            catch (Exception ex)
            {
                // Console
            }

            return View("Edit");
        }
    }

}
