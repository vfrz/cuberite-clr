using System;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public class CaveSpider : AggressiveMonster, ICaveSpider
{
	internal CaveSpider(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}
}
