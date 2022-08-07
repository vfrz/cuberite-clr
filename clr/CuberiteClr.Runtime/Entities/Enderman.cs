using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Enderman : PassiveAggressiveMonster, IEnderman
{
	internal Enderman(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
