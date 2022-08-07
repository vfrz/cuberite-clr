using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Rabbit : PassiveMonster, IRabbit
{
	internal Rabbit(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
