using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Creeper : AggressiveMonster, ICreeper
{
	internal Creeper(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
