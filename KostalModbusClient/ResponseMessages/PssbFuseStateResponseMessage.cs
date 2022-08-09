public class PssbFuseStateResponseMessage : ResponseMessage
{
    public PssbFuseStateResponseMessage(byte[] bytes) : base(bytes) { }

    public PssbFuseState Value => (PssbFuseState)BitConverter.ToUInt16(Bytes[9..11].Reverse().ToArray());

}