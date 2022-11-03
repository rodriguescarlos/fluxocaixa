using Fcx.Library.Application.Envelope;
using FluentValidation.Results;

namespace Fcx.Library.Application.Messages
{
    public class ResponseMessage : Message
    {
        public ValidationResult ValidationResult { get; set; }

        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
