using LiteDB;

namespace CuberiteClr.Sdk;

public interface IDatabase<T> : ILiteDatabase where T : IClrPlugin
{
}
