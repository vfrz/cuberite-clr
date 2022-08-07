using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Ghast : AggressiveMonster, IGhast
{
	internal Ghast(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
