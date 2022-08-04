public class UInt16ResponseMessage : ResponseMessage
{
    public UInt16ResponseMessage(byte[] bytes) : base(bytes) { }

    public ushort Value => BitConverter.ToUInt16(Bytes[9..11].Reverse().ToArray());

}