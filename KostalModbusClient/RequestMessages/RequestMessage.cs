public class RequestMessage
{
    private static short _currentMessageId = 0;

    public short Id { get; set; }
    public short ProtocolIdentifier { get; set; }

    public short Length { get; set; }

    public byte UnitId { get; set; }

    public byte FunctionCode { get; set; }

    public short Address { get; set; }

    public short Quantity { get; set; }


    public RequestMessage(short id, short protocolIdentifier, short length, byte unitId, byte functionCode, short address, short quantity)
    {
        Id = id;
        ProtocolIdentifier = protocolIdentifier;
        Length = length;
        UnitId = unitId;
        FunctionCode = functionCode;
        Address = address;
        Quantity = quantity;
    }


    public static RequestMessage CreateReadMessage(byte unitId, short address, short quantity)
    {
        _currentMessageId++;
        return new RequestMessage(_currentMessageId, 0, 6, unitId, 3, address, quantity);
    }

    public byte[] GetBytes()
    {
        var bytes = new List<byte>();

        bytes.AddRange(BitConverter.GetBytes(Id).Reverse());
        bytes.AddRange(BitConverter.GetBytes(ProtocolIdentifier).Reverse());
        bytes.AddRange(BitConverter.GetBytes(Length).Reverse());
        bytes.Add(UnitId);
        bytes.Add(FunctionCode);
        bytes.AddRange(BitConverter.GetBytes(Address).Reverse());
        bytes.AddRange(BitConverter.GetBytes(Quantity).Reverse());


        return bytes.ToArray();
    }
}