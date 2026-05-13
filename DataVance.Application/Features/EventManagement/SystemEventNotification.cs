using MediatR;

namespace DataVance.Application.Common.Events
{

    public class SystemEventNotification : INotification
    {
        public string EventCode { get; }
        public string PayloadJson { get; }
        public Guid? UserId { get; }
        public string UserEmail { get; }

        public SystemEventNotification(string eventCode, string payloadJson, Guid? userId, string userEmail)
        {

            EventCode = eventCode;
            PayloadJson = payloadJson;
            UserId = userId;
            UserEmail = userEmail;
        }
    }
}
