using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class EnderDragon : AggressiveMonster, IEnderDragon
{
	internal EnderDragon(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
