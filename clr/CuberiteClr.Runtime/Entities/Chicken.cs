using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Chicken : PassiveMonster, IChicken
{
	internal Chicken(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
