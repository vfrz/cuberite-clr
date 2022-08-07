using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Pig : PassiveMonster, IPig
{
	internal Pig(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
