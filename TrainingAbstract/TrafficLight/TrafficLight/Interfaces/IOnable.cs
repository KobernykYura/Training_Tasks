namespace TrafficLight
{
    public interface IOnable
    {
        bool Burns { get; set; }

        bool IsOn();
        bool OnOffBulb();
        void Working(uint time);
    }
}