using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class PassiveMonster : Monster, IPassiveMonster
{
	internal PassiveMonster(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
