public class PowerResponseMessage : ResponseMessage
{
    private readonly short _offsetActive;
    private readonly short _offsetReactive;
    private readonly short _offsetApparent;

    public PowerResponseMessage(byte[] bytes) : base(bytes)
    {
        _offsetActive = 0;
        _offsetReactive = 4;
        _offsetApparent = 8;
    }
    public PowerResponseMessage(byte[] bytes, short offsetActive, short offsetReactive, short offsetApparent) : base(bytes)
    {
        _offsetActive = offsetActive;
        _offsetReactive = offsetReactive;
        _offsetApparent = offsetApparent;
    }

    public float ActivePower => GetFloatAt(_offsetActive);
    public float ReactivePower => GetFloatAt(_offsetReactive);
    public float ApparentPower => GetFloatAt(_offsetApparent);


    private float GetFloatAt(short offset) => BitConverter.ToSingle(Bytes[(9 + offset)..(11 + offset)].Reverse().Concat(Bytes[(11 + offset)..(13 + offset)].Reverse()).ToArray());

}