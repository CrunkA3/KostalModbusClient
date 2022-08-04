public class EnergyManagerStateResponseMessage : ResponseMessage
{
    public EnergyManagerStateResponseMessage(byte[] bytes) : base(bytes) { }

    public EnergyManagerState Value => (EnergyManagerState)BitConverter.ToUInt32(Bytes[9..11].Reverse().Concat(Bytes[11..13].Reverse()).ToArray());

}