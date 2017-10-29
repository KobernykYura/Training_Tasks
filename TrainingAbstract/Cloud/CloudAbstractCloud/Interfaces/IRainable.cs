namespace CloudAbstractCloud.Interfaces
{
    public interface IRainable
    {
        void ItsHailing(uint minuts);
        void ItsRaining(uint minuts);
        void ItsSnowing(uint minuts);
    }
}