namespace AbstractClass
{
    public interface IChageable
    {
        void Clean();
        void Delete();
        void ReWrite(uint height, uint width);
        void ReWrite(Color[] colors);
        void ReWrite(uint height, uint width, Color[] colors);
    }
}