namespace CloudAbstractCloud.Interfaces
{
    public interface IMoveable
    {
        Coordinate PreviousCoord { get; set; }
        bool Statical { get; }

        void MoveCloud(Direction direction);
        double DistanceTraveled();
        Coordinate FutureCoordinate();
        bool IsMove();
    }
}