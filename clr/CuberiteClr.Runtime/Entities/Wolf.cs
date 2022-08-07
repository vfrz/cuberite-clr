using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Wolf : PassiveAggressiveMonster, IWolf
{
	internal Wolf(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
