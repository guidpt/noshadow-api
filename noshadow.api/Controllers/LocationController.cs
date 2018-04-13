using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using noshadow.api.Business;
using noshadow.api.Model.Payload;

namespace noshadow.api.Controllers
{
    [Route("api/location")]
    public class LocationController : BaseController
    {
        private readonly GeolocationBusiness _geolocationBusiness;

        public LocationController(GeolocationBusiness geolocationBusiness)
        {
            _geolocationBusiness = geolocationBusiness;
        }

        [HttpPost]
        public Task<IActionResult> Create([FromBody] GeoloacationPayload payload)
        {
            return RunDefaultAsync(async () =>
            {
                await _geolocationBusiness.CreateAsync(payload);
                return Ok();
            });
        }
        
        [HttpPost("list")]
        public Task<IActionResult> Get([FromBody] FilterPayload payload)
        {
            return RunDefaultAsync(async () =>
            {
                var logs = await _geolocationBusiness.Get(payload);
                return Ok(logs);
            });
        }
    }
}