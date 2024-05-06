using Parking.Domain.Entities;

namespace Parking.Domain.Ports
{
    public interface IBrockerSenderRepository
    {
        Task<bool> ConfigAndSendMessageToBrocker(Logs logsMessage);
    }
}
