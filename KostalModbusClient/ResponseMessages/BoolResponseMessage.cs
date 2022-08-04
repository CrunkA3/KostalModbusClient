public class BoolResponseMessage : ResponseMessage
{
    public BoolResponseMessage(byte[] bytes) : base(bytes) { }

    public bool Value => Bytes[10] == 1;

}