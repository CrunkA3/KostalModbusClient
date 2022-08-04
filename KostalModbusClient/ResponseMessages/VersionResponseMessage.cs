public class VersionResponseMessage : ResponseMessage
{
    public VersionResponseMessage(byte[] bytes) : base(bytes) { }

    public string Value => $"{Bytes[9]}.{Bytes[10]}";

}