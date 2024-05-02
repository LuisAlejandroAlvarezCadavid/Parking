using MediatR;
using Microsoft.AspNetCore.Mvc;
using Parking.Application.Vehicules.Querys;

namespace Parking.Api.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("v1/apis")]
    public class ParkingController : ControllerBase
    {

        readonly IMediator _mediator;

        public ParkingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<double> CalculateTimeTiPayMottorCicle(string vehiculeTipe) => await _mediator.Send(new GetVehiculeTimeToPayQuery(vehiculeTipe));


        [HttpGet("vehicule/{vehiculeTipe}")]
        public async Task<bool> CalculateTimeToPayVehicule(string vehiculeTipe)
        {
            return true;
        }

    }
}
