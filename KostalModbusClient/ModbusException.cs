public class ModbusException : Exception
{
    public ExceptionResponseMessage ExceptionResponseMessage { get; }

    public ModbusException(ExceptionResponseMessage exceptionResponseMessage) : base(exceptionResponseMessage.Value.ToString())
    {
        ExceptionResponseMessage = exceptionResponseMessage;
    }

}