using System;
using Fcx.Library.Application.Envelope;
using MediatR;

namespace Fcx.Library.Application.Messages
{
    public abstract class EventBase : Message, INotification
    {
        public DateTime CreateDateTime { get; private set; }

        protected EventBase()
        {
            CreateDateTime = DateTime.Now;
        }

        protected EventBase(Guid traceId, IDictionary<string, string> additionalHeaders) 
            : base(traceId, additionalHeaders)
        {
            CreateDateTime = DateTime.Now;
        }
    }
}