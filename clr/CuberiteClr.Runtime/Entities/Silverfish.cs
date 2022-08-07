using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Silverfish : AggressiveMonster, ISilverfish
{
	internal Silverfish(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
