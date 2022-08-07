using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class ZombieVillager : AggressiveMonster, IZombieVillager
{
	internal ZombieVillager(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
