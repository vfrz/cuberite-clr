using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class Spider : AggressiveMonster, ISpider
{
	internal Spider(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
