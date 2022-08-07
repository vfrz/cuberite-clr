using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Monster : Pawn, IMonster
{
	internal Monster(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
