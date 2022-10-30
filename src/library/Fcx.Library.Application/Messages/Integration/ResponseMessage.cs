using Fcx.Library.Application.Envelope;
using FluentValidation.Results;

namespace Fcx.Library.Application.Messages.Integration
{
    public class ResponseMessage : MessageEnvelope
    {
        public ValidationResult ValidationResult { get; set; }

        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
