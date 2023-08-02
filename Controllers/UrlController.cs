using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Business.Interfaces;

/*
 Create the backend API for a URL-shortener. It should have two endpoints.
 One POST that accepts a URL and returns a UNIQUE shortURL.
One GET that returns a longURL based on the provided shortURL
*/

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlBusiness _urlBusiness;

        private readonly ILogger<UrlController> _logger;

        public UrlController(ILogger<UrlController> logger, IUrlBusiness urlBusiness)
        {
            _logger = logger;
            _urlBusiness = urlBusiness;
        }

        [HttpPost(Name = "shortUrl")]
        public IActionResult GetShortUrl([FromBody] string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    return StatusCode(404, "URL is empty or null");
                }

                var response = _urlBusiness.GetShortUrl(url);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error o get new URL");
            }
        }

        [HttpGet(Name = "LongUrl/{url}")]
        public IActionResult GetLongUrl([FromQuery] string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    return StatusCode(404, "URL is empty or null");
                }

                var response = _urlBusiness.GetLongUrl(url);

                if (string.IsNullOrEmpty(response))
                {
                    return Ok("Url not found");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error og get long url");
            }
        }

    }
}