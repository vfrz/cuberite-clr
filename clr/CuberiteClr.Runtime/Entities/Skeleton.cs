using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Skeleton : AggressiveMonster, ISkeleton
{
	internal Skeleton(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
