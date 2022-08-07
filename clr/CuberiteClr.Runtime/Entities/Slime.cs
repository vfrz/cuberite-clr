using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Slime : AggressiveMonster, ISlime
{
	internal Slime(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
