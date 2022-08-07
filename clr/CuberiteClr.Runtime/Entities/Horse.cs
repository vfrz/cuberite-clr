using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Horse : PassiveMonster, IHorse
{
	internal Horse(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
