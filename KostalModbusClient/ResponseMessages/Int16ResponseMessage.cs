public class Int16ResponseMessage : ResponseMessage
{
    public Int16ResponseMessage(byte[] bytes) : base(bytes) { }

    public short Value => BitConverter.ToInt16(Bytes[9..11].Reverse().ToArray());

}