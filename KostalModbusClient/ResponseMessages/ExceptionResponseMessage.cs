public class ExceptionResponseMessage : ResponseMessage
{
    public ExceptionResponseMessage(byte[] bytes) : base(bytes) { }

    public ModbusExceptionCode Value => (ModbusExceptionCode)Bytes[9];

}