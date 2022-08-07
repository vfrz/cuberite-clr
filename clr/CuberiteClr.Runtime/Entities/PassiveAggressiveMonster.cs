using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class PassiveAggressiveMonster : AggressiveMonster, IPassiveAggressiveMonster
{
	internal PassiveAggressiveMonster(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
