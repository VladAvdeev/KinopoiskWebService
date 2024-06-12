using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Kinopoisk.Controllers
{
    public class TestController : ControllerBase
    {
        [HttpGet("currencies")]
        public async Task<IActionResult> GetCurreciesFromKinopoisk()
        {
            using(HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44345/currencies");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                //var definition = new { SomeProperty = "" };
                dynamic data = JsonConvert.DeserializeObject(responseBody);
                if (data != null)
                    return Ok(data);
                else return BadRequest();
            }
        }
    }
}
