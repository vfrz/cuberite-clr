using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Bat : PassiveMonster, IBat
{
	internal Bat(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
