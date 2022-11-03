using System;
using Fcx.Library.Application.Envelope;
using FluentValidation.Results;
using MediatR;

namespace Fcx.Library.Application.Messages
{
    public abstract class CommandBase : Message, IRequest<ValidationResult>
    {
        public ValidationResult ValidationResult { get; set; }

        public DateTime CreationDateTime { get; set; }


        protected CommandBase()
        {
            CreationDateTime = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}