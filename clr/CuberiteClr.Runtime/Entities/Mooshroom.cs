using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Mooshroom : PassiveMonster, IMooshroom
{
	internal Mooshroom(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
