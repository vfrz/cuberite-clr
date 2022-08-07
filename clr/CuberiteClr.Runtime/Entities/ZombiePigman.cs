using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class ZombiePigman : PassiveAggressiveMonster, IZombiePigman
{
	internal ZombiePigman(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
