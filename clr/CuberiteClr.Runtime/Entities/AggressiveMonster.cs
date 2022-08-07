using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class AggressiveMonster : Monster, IAggressiveMonster
{
	internal AggressiveMonster(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
