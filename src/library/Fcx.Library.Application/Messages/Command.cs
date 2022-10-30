using System;
using Fcx.Library.Application.Envelope;
using FluentValidation.Results;
using MediatR;

namespace Fcx.Library.Application.Messages
{
    public abstract class Command : MessageEnvelope, IRequest<ValidationResult>
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}