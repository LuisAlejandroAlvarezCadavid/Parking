using MediatR;
using Microsoft.AspNetCore.Mvc;
using Parking.Application.Dtos;
using Parking.Application.MotorCycles.Commands;
using Parking.Application.MotorCycles.Querys;
using Parking.Application.Vehicules.Commands;
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

        [HttpPost]
        public async Task<VehiculeDto> InsertVehicule(InsertVehicleCommand insertVehicleQuery) => await _mediator.Send(insertVehicleQuery);

        [HttpPost("motorCycle/")]
        public async Task<VehiculeDto> InsertMotorCycle(InsertMotorCycleCommand insertMotorCycleCommand) => await _mediator.Send(insertMotorCycleCommand);



    }
}
