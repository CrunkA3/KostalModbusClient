public class InverterStateResponseMessage : ResponseMessage
{
    public InverterStateResponseMessage(byte[] bytes) : base(bytes) { }

    public InverterState Value => (InverterState)BitConverter.ToUInt16(Bytes[9..11].Reverse().ToArray());

}