using System;

namespace KSR.Common
{
    public interface IProduct
    {
        int ID { get; }
        string Name { get; set; }
        DateTime ReleaseDate { get; set; }
        uint Value { get; }
    }
}