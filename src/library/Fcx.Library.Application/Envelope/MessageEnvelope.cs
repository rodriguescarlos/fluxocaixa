using System;

namespace Fcx.Library.Application.Envelope
{
    public abstract class MessageEnvelope
    {
        public string MessageType { get; protected set; }

        public Guid AggregateId { get; protected set; }

        public string Source { get; }

        public string? TraceId { get; set; }

        public DateTime CreationDateTime { get; set; }

        public IDictionary<string, string>? AdditionalHeaders { get; set; }

        protected MessageEnvelope()
        {
            MessageType = GetType().Name;
            CreationDateTime = DateTime.Now;
        }
    }
}