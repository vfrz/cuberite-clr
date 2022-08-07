using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Giant : AggressiveMonster, IGiant
{
	internal Giant(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
