public class StringResponseMessage : ResponseMessage
{
    public StringResponseMessage(byte[] bytes) : base(bytes) { }
    public string Value => System.Text.Encoding.UTF8.GetString(Bytes[9..25].TakeWhile(m => m > 0).ToArray());

}