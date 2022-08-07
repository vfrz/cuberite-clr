using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Witch : AggressiveMonster, IWitch
{
	internal Witch(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
