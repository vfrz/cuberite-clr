using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Zombie : AggressiveMonster, IZombie
{
	internal Zombie(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
