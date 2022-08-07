using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Villager : PassiveMonster, IVillager
{
	internal Villager(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
