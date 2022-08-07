using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Cow : PassiveMonster, ICow
{
	internal Cow(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
