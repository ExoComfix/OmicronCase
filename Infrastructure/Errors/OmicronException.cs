namespace OmicronCase.Infrastructure.Errors
{
    public class OmicronException : Exception
    {
        public ErrorCode ErrorCode { get; }

        public OmicronException(ErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
