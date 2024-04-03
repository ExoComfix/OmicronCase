namespace OmicronCase.Infrastructure.Errors
{
    public enum ErrorCode
    {
        DatabaseError = 101,
        ValidationError = 102,
        AuthorizationError = 103,
        RequiredFieldsMissing = 104,
        DuplicateRecord = 105,
    }
}
