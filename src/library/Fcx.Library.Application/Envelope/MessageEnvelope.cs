using System;

namespace Fcx.Library.Application.Envelope
{
    public abstract class MessageEnvelope
    {
        public string MessageType { get; protected set; }

        public Guid TraceId { get; set; }

        public string? MessageId { get; set; }

        public string? Source { get; }

        public IDictionary<string, string>? AdditionalHeaders { get; set; }

        protected MessageEnvelope()
        {
            MessageType = GetType().Name;
            MessageId = Guid.NewGuid().ToString();
            AdditionalHeaders = new Dictionary<string, string>();
        }
    }
}