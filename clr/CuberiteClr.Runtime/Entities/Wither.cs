using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Wither : AggressiveMonster, IWither
{
	internal Wither(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
