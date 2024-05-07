using Parking.Domain.Entities;

namespace Parking.Domain.Ports
{
    public interface IBrockerSenderRepository
    {
        bool ConfigAndSendMessageToBrocker(Logs logsMessage);
    }
}
