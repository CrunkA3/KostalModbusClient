public class UInt32ResponseMessage : ResponseMessage
{
    public UInt32ResponseMessage(byte[] bytes) : base(bytes) { }

    public float Value => BitConverter.ToUInt32(Bytes[9..11].Reverse().Concat(Bytes[11..13].Reverse()).ToArray());

}