using System.Collections.Generic;

namespace CuberiteClr.Generator;

public class Hook
{
	public string Return { get; set; }

	public Dictionary<string, string> Args { get; set; } = new();
}
