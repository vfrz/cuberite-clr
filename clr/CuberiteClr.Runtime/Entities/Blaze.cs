using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Blaze : AggressiveMonster, IBlaze
{
	internal Blaze(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
