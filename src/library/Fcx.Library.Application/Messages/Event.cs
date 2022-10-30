using System;
using Fcx.Library.Application.Envelope;
using MediatR;

namespace Fcx.Library.Application.Messages
{
    public class Event : MessageEnvelope, INotification
    {
        public DateTime CreateDateTime { get; private set; }

        protected Event()
        {
            CreateDateTime = DateTime.Now;
        }
    }
}