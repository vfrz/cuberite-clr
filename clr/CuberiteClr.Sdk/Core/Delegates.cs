using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Sdk.Core;

public delegate bool CommandCallback(string command, string[] split, IPlayer player);

public delegate bool ForEachWorldCallback(IWorld world);

public delegate bool ForEachPlayerCallback(IPlayer world);
