namespace TrafficLight
{
    public interface IChangeable
    {
        string Company { get; }
        ushort Power { get; }

        void ChangeBulb(string company, ushort power, uint duration, string captype);
        bool IsBroken();
    }
}