using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Guardian : AggressiveMonster, IGuardian
{
	internal Guardian(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
