using MediatR;
using Microsoft.AspNetCore.Mvc;
using Parking.Application.MotorCycles.Querys;
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
        public async Task<double> CalculateTimeTiPayMottorCicle(string plate, string vehiculeTipe) => await _mediator.Send(new GetVehiculeTimeToPayQuery(plate, vehiculeTipe));


        [HttpGet("vehicule/{plate}/{vehiculeTipe}")]
        public async Task<double> CalculateTimeToPayVehicule(string plate, string vehiculeTipe) => await _mediator.Send(new GetMotorCycleTimeToPayQuery(plate, vehiculeTipe));



    }
}
