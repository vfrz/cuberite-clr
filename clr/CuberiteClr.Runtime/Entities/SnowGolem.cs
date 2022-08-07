using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class SnowGolem : PassiveAggressiveMonster, ISnowGolem
{
	internal SnowGolem(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
