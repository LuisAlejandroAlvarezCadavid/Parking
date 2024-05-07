using Parking.Domain.Entities;
using Parking.Domain.Ports;

namespace Parking.Domain.Services.Implementations
{
    [DomainService]
    public class VehiculeInsertService : VehiculeMotorCycleService
    {
        public override string VehiculeType { get; set; } = "VH";

        readonly IVehiculeInsertRepository _vehiculeEnterRepository;
        readonly IBrockerSenderRepository _brockerSenderRepository;

        public VehiculeInsertService(IVehiculeInsertRepository vehiculeEnterRepository, IBrockerSenderRepository brockerSenderRepository)
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
                var log = new Logs(Guid.NewGuid(), DateTime.Now, DateTime.Now, plate, DateTime.Now);
                log.SetLeaveTime(DateTime.Now);
                _brockerSenderRepository.ConfigAndSendMessageToBrocker(log);
                return (TResult)(DomainEntity)result;

            }
            return (TResult)new DomainEntity(Guid.NewGuid(), DateTime.Now, DateTime.Now);
        }
    }
}
