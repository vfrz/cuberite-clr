using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class MagmaCube : AggressiveMonster, IMagmaCube
{
	internal MagmaCube(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
