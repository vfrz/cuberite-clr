using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Squid : PassiveMonster, ISquid
{
	internal Squid(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
