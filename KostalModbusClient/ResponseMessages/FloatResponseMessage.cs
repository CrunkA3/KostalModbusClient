public class FloatResponseMessage : ResponseMessage
{
    public FloatResponseMessage(byte[] bytes) : base(bytes) { }

    public float Value => BitConverter.ToSingle(Bytes[9..11].Reverse().Concat(Bytes[11..13].Reverse()).ToArray());

}