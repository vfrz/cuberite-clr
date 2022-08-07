using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class WitherSkeleton : AggressiveMonster, IWitherSkeleton
{
	internal WitherSkeleton(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
