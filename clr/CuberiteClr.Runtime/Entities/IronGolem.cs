using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class IronGolem : PassiveAggressiveMonster, IIronGolem
{
	internal IronGolem(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
