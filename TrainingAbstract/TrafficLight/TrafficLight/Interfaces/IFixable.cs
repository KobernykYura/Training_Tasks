namespace TrafficLight
{
    interface IFixable
    {
        void FixBulbs(Bulb bulb);
        void FixLighter(Bulb bulb, Lighter lighter);
    }
}