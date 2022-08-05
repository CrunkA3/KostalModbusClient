public class StringResponseMessage : ResponseMessage
{
    private byte _length;
    public StringResponseMessage(byte[] bytes, byte length) : base(bytes) { _length = length; }
    public string Value => System.Text.Encoding.UTF8.GetString(Bytes[9..(_length * 2 + 9)].TakeWhile(m => m > 0).ToArray());

}