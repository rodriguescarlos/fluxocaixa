using System;

namespace Fcx.Library.Application.Envelope
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }

        public Guid TraceId { get; set; }

        public string? MessageId { get; set; }

        public IDictionary<string, string>? additionalHeaders { get; set; }

        protected Message()
        {
            MessageType = this.GetType().Name;
            MessageId = Guid.NewGuid().ToString();
            additionalHeaders = new Dictionary<string, string>();
        }
        protected Message(Guid traceId, IDictionary<string, string> additionalHeaders = null)
        {
            MessageType = this.GetType().Name;
            MessageId = Guid.NewGuid().ToString();
            this.TraceId = traceId;
            this.additionalHeaders = additionalHeaders ?? this.additionalHeaders;
        }
    }
}