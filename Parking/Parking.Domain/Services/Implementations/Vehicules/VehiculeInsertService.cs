using Parking.Domain.Entities;
using Parking.Domain.Ports;
using Parking.Domain.Structs;

namespace Parking.Domain.Services.Implementations.Vehicules
{
    [DomainService]
    public class VehiculeInsertService : VehiculeMotorCycleService
    {
        public override string VehiculeType { get; set; } = Texts.VEHICULE;

        readonly IVehiculeRepository _vehiculeEnterRepository;
        readonly IBrockerSenderRepository _brockerSenderRepository;

        public VehiculeInsertService(IVehiculeRepository vehiculeEnterRepository, IBrockerSenderRepository brockerSenderRepository)
        {
            _vehiculeEnterRepository = vehiculeEnterRepository;
            _brockerSenderRepository = brockerSenderRepository;
        }

        public override async Task<TResult> InsertVehiculeOrMotorCycleAsync<TResult>(string plate, CancellationToken cancellationToken)
        {
            var vehicule = new Vehicule(Guid.NewGuid(), DateTime.Now, DateTime.Now, plate, DateTime.Now);
            var result = await _vehiculeEnterRepository.InsertVehiculeAsync(vehicule, cancellationToken);
            if (result != null)
            {
                SharedTasks.SendBrockerMessge(_brockerSenderRepository, plate);
                return (TResult)(DomainEntity)result;

            }
            return (TResult)new DomainEntity(Guid.NewGuid(), DateTime.Now, DateTime.Now);
        }
    }
}
