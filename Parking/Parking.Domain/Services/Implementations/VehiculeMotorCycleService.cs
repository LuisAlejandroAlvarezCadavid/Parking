﻿using Parking.Domain.Entities;
using Parking.Domain.Services.Contractors;

namespace Parking.Domain.Services.Implementations
{
    public abstract class VehiculeMotorCycleService : IVehicleEnterStrategyService
    {
        public virtual string VehiculeType { get; set; } = "NO";

        public virtual async Task<TResult> InsertEnterVehiculeAsync<TResult>(string plate, CancellationToken cancellationToken) where TResult : DomainEntity
        {
            return await Task.Run(() => (TResult)new DomainEntity(Guid.NewGuid(), DateTime.Now, DateTime.Now));
        }
    }
}