using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Pawn : Entity, IPawn
{
	public Pawn(IntPtr handle) : base(handle)
	{
	}
}
