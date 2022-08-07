using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Sheep : PassiveMonster, ISheep
{
	internal Sheep(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
