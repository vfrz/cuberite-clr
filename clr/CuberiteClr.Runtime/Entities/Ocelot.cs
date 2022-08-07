using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Ocelot : PassiveMonster, IOcelot
{
	internal Ocelot(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
