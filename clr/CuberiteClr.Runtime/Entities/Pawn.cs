using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Pawn : Entity, IPawn
{
	internal Pawn(IntPtr handle) : base(handle)
	{
	}
}
