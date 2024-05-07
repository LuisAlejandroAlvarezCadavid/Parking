using Parking.Domain.Entities;
using Parking.Domain.Ports;

namespace Parking.Domain.Services
{
    internal static class SharedTasks
    {
        internal static void SendBrockerMessge(IBrockerSenderRepository brockerSenderRepository, string plate)
        {
            var log = new Logs(Guid.NewGuid(), DateTime.Now, DateTime.Now, plate, DateTime.Now);
            log.SetLeaveTime(DateTime.Now);
            brockerSenderRepository.ConfigAndSendMessageToBrocker(log);
        }

        internal static double CalculateValueToPay(DateTime enterTime, DateTime leaveTime, double valueByHour)
        {

        }
    }
}
