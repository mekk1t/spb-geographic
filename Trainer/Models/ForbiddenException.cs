using System;

namespace SUAI.SpbGeographic.Trainer.Models
{
    public class ForbiddenException : Exception
    {
        public override string Message { get; }

        public ForbiddenException()
        {
            this.Message = "Отказано в доступе";
        }

        public ForbiddenException(string message) : base(message)
        {
            this.Message = message;
        }

        public ForbiddenException(string message, Exception innerException) : base(message, innerException)
        {
            this.Message = $"{message}. Внутреннее исключение: {innerException}";
        }
    }
}
