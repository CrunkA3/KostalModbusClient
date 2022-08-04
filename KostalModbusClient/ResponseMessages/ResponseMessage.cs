public abstract class ResponseMessage
{
    public byte[] Bytes { get; set; }

    public ResponseMessage(byte[] bytes)
    {
        Bytes = bytes;
    }


    public short Id => BitConverter.ToInt16(Bytes[0..2].Reverse().ToArray());
    public short ProtocolIdentifier => BitConverter.ToInt16(Bytes[2..4].Reverse().ToArray());

    public short DataType => BitConverter.ToInt16(Bytes[4..6].Reverse().ToArray());

    public byte UnitId => Bytes[6];
    public byte FunctionCode => Bytes[7];

    public byte Length => Bytes[8];
}