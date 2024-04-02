namespace PriceState.Interfaces.Model;

public class PriceStateException: Exception
{
    public PriceStateException(string? message = null, EnumErrorCode errorCode = EnumErrorCode.Unknown) : base(message ?? errorCode.GetDescription())
    {
        ErrorCode = errorCode;
    }

    public PriceStateException(EnumErrorCode errorCode) : base(errorCode.GetDescription())
    {
        ErrorCode = errorCode;
    }

    public EnumErrorCode ErrorCode { get; set; }
}