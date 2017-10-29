namespace PartialClass
{
    public interface IProfitable
    {
        ulong AtHome(byte months);
        ulong InBank(byte years, byte coefficient);
    }
}